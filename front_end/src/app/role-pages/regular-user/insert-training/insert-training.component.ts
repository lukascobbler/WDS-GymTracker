import {Component, OnInit} from '@angular/core';
import {MatDialogRef} from '@angular/material/dialog';
import {TrainingDTO} from '../../../models/TrainingDTO';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatInput} from '@angular/material/input';
import {MatOption} from '@angular/material/core';
import {MatSelect} from '@angular/material/select';
import {MatSlider, MatSliderThumb} from '@angular/material/slider';
import {Gender} from '../../../models/Gender';
import {MatDatepicker, MatDatepickerInput, MatDatepickerToggle} from '@angular/material/datepicker';

@Component({
  selector: 'app-insert-training',
  standalone: true,
  imports: [
    MatFormField,
    MatInput,
    MatOption,
    MatSelect,
    MatSlider,
    MatSliderThumb,
    MatLabel,
    MatDatepickerInput,
    MatDatepickerToggle,
    MatDatepicker,
  ],
  templateUrl: './insert-training.component.html',
  styleUrl: './insert-training.component.scss'
})
export class InsertTrainingComponent implements OnInit {
  constructor(public dialogRef: MatDialogRef<InsertTrainingComponent, TrainingDTO | null>) {
  }

  ngOnInit(): void {
  }

  closeDialog() {
    this.dialogRef.close({});
  }

  onNoClick() {
    this.dialogRef.close(null);
  }

  validateNumber(event: Event): void {
    const input = event.target as HTMLInputElement;
    const value = input.value;

    input.value = value.replace(/[^0-9]/g, '');
  }

  protected readonly Gender = Gender;
}
