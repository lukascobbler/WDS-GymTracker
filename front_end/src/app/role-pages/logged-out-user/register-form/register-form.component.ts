import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {MatSelectModule} from '@angular/material/select';
import {Gender} from '../../../models/users/Gender';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  ValidationErrors,
  ValidatorFn,
  Validators
} from '@angular/forms';
import {RegistrationRequestDTO} from '../../../models/users/RegistrationRequestDTO';

@Component({
  selector: 'app-register-form',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    ReactiveFormsModule
  ],
  templateUrl: './register-form.component.html',
  styleUrl: './register-form.component.scss'
})
export class RegisterFormComponent implements OnInit {
  @Output() registerButtonPressed = new EventEmitter<RegistrationRequestDTO>();
  registrationForm: FormGroup;

  constructor(private formBuilder: FormBuilder) {
  }

  matchPassword(passwordControl: AbstractControl): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
      const match = control.value === passwordControl.value;
      return match ? null : { passwordsMismatch: true };
    };
  }

  ngOnInit() {
    this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      repeatPassword: ['', Validators.required],
      gender: ['', Validators.required],
      name: ['', Validators.required],
      surname: ['', Validators.required]
    });

    this.registrationForm.get('repeatPassword')?.setValidators([
      Validators.required,
      this.matchPassword(this.registrationForm.get('password')!)
    ]);
  }

  register() {
    this.registerButtonPressed.emit({
      name: this.registrationForm.get('name')?.value,
      email: this.registrationForm.get('email')?.value,
      password: this.registrationForm.get('password')?.value,
      repeatPassword: this.registrationForm.get('repeatPassword')?.value,
      gender: this.registrationForm.get('gender')?.value,
      surname: this.registrationForm.get('surname')?.value,
    })
  }

  protected readonly Gender = Gender;
}
