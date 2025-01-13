import { Component } from '@angular/core';
import {LoginFormComponent} from './login-form/login-form.component';
import {RegisterFormComponent} from './register-form/register-form.component';
import {NgIf} from '@angular/common';
import {UsersService} from '../../services/users/users.service';
import {LoginRequestDTO} from '../../models/users/LoginRequestDTO';
import {RegistrationRequestDTO} from '../../models/users/RegistrationRequestDTO';
import {Router} from '@angular/router';

@Component({
  selector: 'app-login-register-screen',
  standalone: true,
  imports: [
    LoginFormComponent,
    RegisterFormComponent,
    NgIf
  ],
  templateUrl: './login-register-screen.component.html',
  styleUrl: './login-register-screen.component.scss'
})
export class LoginRegisterScreenComponent {
  protected isLogin: boolean = true;

  constructor(private userService: UsersService,
              private router: Router) {
  }

  login(loginRequestDTO: LoginRequestDTO) {
    this.userService.login(loginRequestDTO).subscribe({
      next: value => {
        localStorage.setItem('userId', String(value.id));
        this.router.navigate(['home']);
      },
      error: err => {

      }
    })
  }

  register(registrationRequestDTO: RegistrationRequestDTO) {
    this.userService.register(registrationRequestDTO).subscribe({
      next: value => {
        localStorage.setItem('userId', String(value.id));
        this.router.navigate(['home']);
      },
      error: err => {

      }
    })
  }
}
