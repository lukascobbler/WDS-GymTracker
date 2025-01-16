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
import {TrainingTypeService} from '../../../services/training-types/training-type.service';
import {TrainingTypeDTO} from '../../../models/trainings/TrainingTypeDTO';
import {NgForOf, NgIf} from '@angular/common';
import {MatProgressSpinner} from '@angular/material/progress-spinner';

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
    NgForOf,
    NgIf,
    MatProgressSpinner,
  ],
  providers: [provideNativeDateAdapter()],
  templateUrl: './insert-training.component.html',
  styleUrl: './insert-training.component.scss'
})
export class InsertTrainingComponent implements OnInit {
  trainingFormGroup: FormGroup;
  loadingTrainingTypes = true;
  trainingTypes: TrainingTypeDTO[] = [];
  today: Date = new Date();

  constructor(public dialogRef: MatDialogRef<InsertTrainingComponent, CreateTrainingDTO | null>,
              private formBuilder: FormBuilder,
              private trainingTypeService: TrainingTypeService) {
  }

  ngOnInit(): void {
    this.trainingTypeService.getAllTrainingTypes().subscribe({
      next: value => {
        this.trainingTypes = value;
        this.loadingTrainingTypes = false;

        this.trainingFormGroup = this.formBuilder.group({
          caloriesBurned: [null, Validators.required],
          duration: [null, Validators.required],
          notes: [''],
          tiredness: [5, Validators.required],
          trainingDate: [null, Validators.required],
          trainingDifficulty: [5, Validators.required],
          trainingType: ['', Validators.required]
        });
      },
      error: err => {
        // todo
      }
    })
  }

  closeDialog() {
    this.dialogRef.close({
      caloriesBurned: this.trainingFormGroup.get('caloriesBurned')?.value,
      duration: this.trainingFormGroup.get('duration')?.value,
      notes: this.trainingFormGroup.get('notes')?.value,
      tiredness: this.trainingFormGroup.get('tiredness')?.value,
      year: this.trainingFormGroup.get('trainingDate')?.value.getFullYear(),
      month: this.trainingFormGroup.get('trainingDate')?.value.getMonth() + 1,
      day: this.trainingFormGroup.get('trainingDate')?.value.getDate(),
      trainingDifficulty: this.trainingFormGroup.get('trainingDifficulty')?.value,
      trainingTypeId: this.trainingFormGroup.get('trainingType')?.value,
      gymMemberId: Number(localStorage.getItem('gymMemberId'))
    });
  }

  onNoClick() {
    this.dialogRef.close(null);
  }

  validateNumber(event: Event): void {
    const input = event.target as HTMLInputElement;
    const value = input.value;

    input.value = value.replace(/[^0-9]/g, '');
  }
}
