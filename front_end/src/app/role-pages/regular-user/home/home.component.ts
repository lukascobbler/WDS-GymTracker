import {Component, OnInit} from '@angular/core';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {
  MatDatepicker,
  MatDatepickerModule,
} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
import {
  MatCell,
  MatCellDef,
  MatColumnDef,
  MatHeaderCell,
  MatHeaderCellDef,
  MatHeaderRow, MatHeaderRowDef, MatRow, MatRowDef,
  MatTable, MatTableDataSource
} from '@angular/material/table';
import {MatDialog, MatDialogRef} from '@angular/material/dialog';
import {InsertTrainingComponent} from '../insert-training/insert-training.component';
import {TrainingDTO} from '../../../models/trainings/TrainingDTO';
import {DatePipe, DecimalPipe, NgClass, NgForOf, NgIf} from '@angular/common';
import {MatIcon} from '@angular/material/icon';
import _moment from 'moment';
import {default as _rollupMoment, Moment} from 'moment';
import {provideMomentDateAdapter} from '@angular/material-moment-adapter';
import {FormControl, ReactiveFormsModule} from '@angular/forms';
import {Router} from '@angular/router';
import {TrainingsService} from '../../../services/trainings/trainings.service';
import {MatProgressSpinner} from '@angular/material/progress-spinner';
import {CreateTrainingDTO} from '../../../models/trainings/CreateTrainingDTO';
import {WeeklyTrainingStatisticsDTO} from '../../../models/trainings/WeeklyTrainingStatisticsDTO';
import {ToastrService} from 'ngx-toastr';

const moment = _rollupMoment || _moment;

export const MY_FORMATS = {
  parse: {
    dateInput: 'MM/YYYY',
  },
  display: {
    dateInput: 'MM/YYYY',
    monthYearLabel: 'MMM YYYY',
    dateA11yLabel: 'LL',
    monthYearA11yLabel: 'MMMM YYYY',
  },
};

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatTable,
    MatHeaderCell,
    MatHeaderCellDef,
    MatCell,
    MatCellDef,
    MatColumnDef,
    MatHeaderRow,
    MatHeaderRowDef,
    MatRowDef,
    MatRow,
    NgClass,
    MatIcon,
    NgIf,
    NgForOf,
    ReactiveFormsModule,
    DatePipe,
    MatProgressSpinner,
    DecimalPipe,
  ],
  providers: [provideMomentDateAdapter(MY_FORMATS)],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {
  displayedColumns: string[] = ['date', 'type', 'difficulty', 'tiredness', 'duration', 'calories burned', 'additional notes'];
  trainings: TrainingDTO[];
  weeklyStatistics: WeeklyTrainingStatisticsDTO[];
  trainingsDataSource = new MatTableDataSource<TrainingDTO>();
  loadingTrainings: boolean = true;
  loggedInUserId: number;

  readonly formControlDate = new FormControl(moment());
  selectedDate: Date | null = null;
  today: Date = new Date();

  constructor(private dialog: MatDialog,
              private router: Router,
              private trainingService: TrainingsService,
              private toastr: ToastrService) {
  }

  resetMonthAndYear() {
    this.formControlDate.setValue(null);
    this.trainingsDataSource.data = this.trainings;
    this.selectedDate = null;
  }

  setMonthAndYear(normalizedMonthAndYear: Moment, datepicker: MatDatepicker<Moment>) {
    this.formControlDate.setValue(null);
    const ctrlValue = this.formControlDate.value ?? moment();
    ctrlValue.month(normalizedMonthAndYear.month());
    ctrlValue.year(normalizedMonthAndYear.year());
    this.formControlDate.setValue(ctrlValue);
    this.selectedDate = new Date(normalizedMonthAndYear.year(), normalizedMonthAndYear.month())
    datepicker.close();
    this.getWeeklyStatistics();
  }

  ngOnInit(): void {
    this.loggedInUserId = Number(localStorage.getItem('gymMemberId'));
    this.trainingService.getAllTrainingsForUser(this.loggedInUserId).subscribe({
      next: value => {
        this.trainings = value;
        console.log(value)
        this.trainingsDataSource.data = value;
        this.loadingTrainings = false;
      },
      error: err => {
        this.toastr.error("Error fetching trainings for user", "Fetch error");
      }
    });

    this.formControlDate.setValue(null);
  }

  binarySearch(arr: TrainingDTO[], value: TrainingDTO): number {
    let low = 0, high = arr.length;

    while (low < high) {
      const mid = Math.floor((low + high) / 2);
      let comparatorDate = new Date(arr[mid].year, arr[mid].month, arr[mid].day);
      let newDate = new Date(value.year, value.month, value.day);
      if (comparatorDate > newDate) {
        low = mid + 1;
      } else {
        high = mid;
      }
    }

    console.log(low)

    return low;
  }

  createDate(year: number, month: number, day: number) {
    return new Date(year, month, day);
  }

  createNewTraining() {
    const dialogRef: MatDialogRef<InsertTrainingComponent, CreateTrainingDTO | null> = this.dialog.open(InsertTrainingComponent, {
      width: '90vh'
    });

    dialogRef.afterClosed().subscribe({
      next: newTraining => {
        if (newTraining !== null && newTraining !== undefined) {
          this.loadingTrainings = true;
          this.trainingService.documentTrainingForUser(newTraining).subscribe({
            next: documentedTraining => {
              const index = this.binarySearch(this.trainings, documentedTraining);
              this.trainings.splice(index, 0, documentedTraining);
              if (this.selectedDate === null) {
                this.trainingsDataSource.data = this.trainings;
              } else {
                this.resetMonthAndYear();
              }
              this.loadingTrainings = false;
            },
            error: err => {
              this.toastr.error("Error documenting training", "Document training error");
            }
          })
        }
      }
    })
  }

  getWeeklyStatistics() {
    this.loadingTrainings = true;
    this.trainingService.getTrainingStatisticsForUserForMonthAndYear(this.selectedDate!.getFullYear(), this.selectedDate!.getMonth() + 1, this.loggedInUserId).subscribe({
      next: value => {
        this.weeklyStatistics = value;
        console.log(value);
        this.trainingsDataSource.data = this.trainings.filter(t =>
          t.month === this.selectedDate!.getMonth() + 1 &&
          t.year === this.selectedDate!.getFullYear())
        this.loadingTrainings = false;
      },
      error: err => {
        this.toastr.error("Error fetching weekly statistics for user", "Fetch error");
      }
    })
  }

  logout() {
    localStorage.removeItem('gymMemberId');
    this.router.navigate(['']);
  }

  expandedRow: number | null = null;

  toggleExpansion(index: number) {
    this.expandedRow = this.expandedRow === index ? null : index;
  }

  protected readonly Date = Date;
}
