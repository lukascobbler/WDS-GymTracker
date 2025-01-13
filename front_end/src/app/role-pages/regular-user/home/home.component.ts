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
import {TrainingDTO} from '../../../models/TrainingDTO';
import {DatePipe, NgClass, NgForOf, NgIf} from '@angular/common';
import {MatIcon} from '@angular/material/icon';
import _moment from 'moment';
import {default as _rollupMoment, Moment} from 'moment';
import {provideMomentDateAdapter} from '@angular/material-moment-adapter';
import {FormControl, ReactiveFormsModule} from '@angular/forms';
import {NoopAnimationsModule} from '@angular/platform-browser/animations';

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
  ],
  providers: [provideMomentDateAdapter(MY_FORMATS)],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {
  displayedColumns: string[] = ['date', 'type', 'difficulty', 'tiredness', 'duration', 'calories burned', 'additional notes'];
  trainingsDataSource = new MatTableDataSource<{}>();

  readonly date = new FormControl(moment());
  today: Date = new Date();

  setMonthAndYear(normalizedMonthAndYear: Moment, datepicker: MatDatepicker<Moment>) {
    const ctrlValue = this.date.value ?? moment();
    ctrlValue.month(normalizedMonthAndYear.month());
    ctrlValue.year(normalizedMonthAndYear.year());
    this.date.setValue(ctrlValue);
    datepicker.close();
  }

  constructor(private dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.trainingsDataSource.data = [{}, {}, {}, {}, {}, {}, {}, {}, {}, {}, {}, {}, {}, {}, {}, {},
      {}, {}, {}, {}, {}, {}, {}, {}, {}, {}, {}, {}, {}, {}, {}, {},
      {}, {}, {}, {}, {}, {}, {}, {}, {}, {}, {}, {}, {}, {}, {}, {}]
  }

  createNewTraining() {
    const dialogRef: MatDialogRef<InsertTrainingComponent, TrainingDTO | null> = this.dialog.open(InsertTrainingComponent, {
      width: '90vh'
    });
  }

  expandedRow: number | null = null;

  toggleExpansion(index: number) {
    this.expandedRow = this.expandedRow === index ? null : index;
  }
}
