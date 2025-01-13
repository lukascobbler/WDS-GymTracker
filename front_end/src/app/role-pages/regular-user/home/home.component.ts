import {Component, OnInit} from '@angular/core';
import {MAT_FORM_FIELD, MatFormField, MatFormFieldModule, MatHint, MatLabel} from '@angular/material/form-field';
import {MatInput, MatInputModule} from '@angular/material/input';
import {
  MatDatepicker,
  MatDatepickerInput,
  MatDatepickerModule,
  MatDatepickerToggle
} from '@angular/material/datepicker';
import {MAT_RIPPLE_GLOBAL_OPTIONS, MatNativeDateModule} from '@angular/material/core';
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
import {DatePipe, NgClass, NgForOf, NgIf} from '@angular/common';
import {MatIcon} from '@angular/material/icon';
import _moment from 'moment';
import {default as _rollupMoment, Moment} from 'moment';
import {provideMomentDateAdapter} from '@angular/material-moment-adapter';
import {FormControl, ReactiveFormsModule} from '@angular/forms';
import {NoopAnimationsModule} from '@angular/platform-browser/animations';
import {Router} from '@angular/router';
import {TrainingsService} from '../../../services/trainings/trainings.service';
import {MatProgressSpinner} from '@angular/material/progress-spinner';
import {CreateTrainingDTO} from '../../../models/trainings/CreateTrainingDTO';
import {WeeklyTrainingStatisticsDTO} from '../../../models/trainings/WeeklyTrainingStatisticsDTO';

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
              private trainingService: TrainingsService) {
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
    this.loggedInUserId = Number(localStorage.getItem('userId'));
    this.trainingService.getAllTrainingsForUser(this.loggedInUserId).subscribe({
      next: value => {
        this.trainings = value;
        this.trainingsDataSource.data = value;
        this.loadingTrainings = false;
      },
      error: err => {
        // todo
      }
    });

    this.formControlDate.setValue(null);
  }

  binarySearch(arr: TrainingDTO[], value: TrainingDTO): number {
    let low = 0, high = arr.length;

    while (low < high) {
      const mid = Math.floor((low + high) / 2);
      if (arr[mid].trainingDate < value.trainingDate) {
        low = mid + 1;
      } else {
        high = mid;
      }
    }

    return low;
  }

  createNewTraining() {
    const dialogRef: MatDialogRef<InsertTrainingComponent, CreateTrainingDTO | null> = this.dialog.open(InsertTrainingComponent, {
      width: '90vh'
    });

    dialogRef.afterClosed().subscribe({
      next: newTraining => {
        if (newTraining !== null && newTraining !== undefined) {
          this.loadingTrainings = true;
          this.trainingService.documentTrainingForUser(newTraining, this.loggedInUserId).subscribe({
            next: documentedTraining => {
              const index = this.binarySearch(this.trainings, documentedTraining);
              this.trainings.splice(index, 0, documentedTraining);
              if (this.selectedDate === null) {
                this.trainingsDataSource.data = this.trainings;
              } else {
                // todo what if the weekly report mode is turned on
              }
              this.loadingTrainings = true;
            },
            error: err => {
              // todo
            }
          })
        }
      }
    })
  }

  getWeeklyStatistics() {
    this.loadingTrainings = true;
    this.trainingService.getTrainingStatisticsForUserForMonthAndYear(this.selectedDate!, this.loggedInUserId).subscribe({
      next: value => {
        this.weeklyStatistics = value;
        this.trainingsDataSource.data = this.trainings.filter(t =>
          t.trainingDate.getMonth() === this.selectedDate!.getMonth() &&
          t.trainingDate.getFullYear() === this.selectedDate!.getFullYear())
        this.loadingTrainings = false;
      },
      error: err => {
          //todo
      }
    })
  }

  logout() {
    localStorage.removeItem('userId');
    this.router.navigate(['']);
  }

  expandedRow: number | null = null;

  toggleExpansion(index: number) {
    this.expandedRow = this.expandedRow === index ? null : index;
  }
}
