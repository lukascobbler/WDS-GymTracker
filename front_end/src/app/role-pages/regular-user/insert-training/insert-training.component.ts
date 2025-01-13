import {Component, OnInit} from '@angular/core';
import {MatDialogRef} from '@angular/material/dialog';
import {TrainingDTO} from '../../../models/trainings/TrainingDTO';
import {MatFormField, MatFormFieldModule, MatLabel} from '@angular/material/form-field';
import {MatInput, MatInputModule} from '@angular/material/input';
import {MatOption, provideNativeDateAdapter} from '@angular/material/core';
import {MatSelect} from '@angular/material/select';
import {MatSlider, MatSliderThumb} from '@angular/material/slider';
import {Gender} from '../../../models/users/Gender';
import {
  MatDatepickerModule,
} from '@angular/material/datepicker';
import {Form, FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {today} from '@igniteui/material-icons-extended';
import {CreateTrainingDTO} from '../../../models/trainings/CreateTrainingDTO';

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
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    ReactiveFormsModule,
  ],
  providers: [provideNativeDateAdapter()],
  templateUrl: './insert-training.component.html',
  styleUrl: './insert-training.component.scss'
})
export class InsertTrainingComponent implements OnInit {
  trainingFormGroup: FormGroup;
  today: Date = new Date();

  constructor(public dialogRef: MatDialogRef<InsertTrainingComponent, CreateTrainingDTO | null>,
              private formBuilder: FormBuilder) {
  }

  ngOnInit(): void {
    this.trainingFormGroup = this.formBuilder.group({
      caloriesBurned: [null, Validators.required],
      duration: [null, Validators.required],
      notes: [''],
      tiredness: [5, Validators.required],
      trainingDate: [null, Validators.required],
      trainingDifficulty: [5, Validators.required],
    })
  }

  closeDialog() {
    console.log({
      caloriesBurned: this.trainingFormGroup.get('caloriesBurned')?.value,
      duration: this.trainingFormGroup.get('duration')?.value,
      notes: this.trainingFormGroup.get('notes')?.value,
      tiredness: this.trainingFormGroup.get('tiredness')?.value,
      trainingDate: this.trainingFormGroup.get('trainingDate')?.value,
      trainingDifficulty: this.trainingFormGroup.get('trainingDifficulty')?.value,
    })
    // this.dialogRef.close(this.newTraining); //todo
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
