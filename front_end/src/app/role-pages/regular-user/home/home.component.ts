import {Component, OnInit} from '@angular/core';
import {MatFormField, MatFormFieldModule, MatHint, MatLabel} from '@angular/material/form-field';
import {MatInput, MatInputModule} from '@angular/material/input';
import {
  MatDatepicker,
  MatDatepickerInput,
  MatDatepickerModule,
  MatDatepickerToggle
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
import {TrainingDTO} from '../../../models/TrainingDTO';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    MatLabel,
    MatHint,
    MatFormField,
    MatInput,
    MatDatepickerInput,
    MatDatepickerToggle,
    MatDatepicker,
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
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit {
  displayedColumns: string[] = ['date', 'type', 'difficulty', 'tiredness', 'additional notes'];
  trainingsDataSource = new MatTableDataSource<{}>();

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
}
