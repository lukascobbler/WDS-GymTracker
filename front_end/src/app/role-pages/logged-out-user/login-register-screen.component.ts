import { Component } from '@angular/core';
import {LoginFormComponent} from './login-form/login-form.component';
import {RegisterFormComponent} from './register-form/register-form.component';
import {NgIf} from '@angular/common';
import {UsersService} from '../../services/users/users.service';
import {LoginRequestDTO} from '../../models/users/LoginRequestDTO';
import {RegistrationRequestDTO} from '../../models/users/RegistrationRequestDTO';
import {Router} from '@angular/router';
import {ToastrService} from 'ngx-toastr';

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
              private router: Router,
              private toastr: ToastrService) {
  }

  login(loginRequestDTO: LoginRequestDTO) {
    this.userService.login(loginRequestDTO).subscribe({
      next: value => {
        localStorage.setItem('gymMemberId', String(value.gymMemberId));
        this.router.navigate(['home']);
      },
      error: err => {
        this.toastr.error("Wrong credentials", "Login failure");
      }
    })
  }

  register(registrationRequestDTO: RegistrationRequestDTO) {
    this.userService.register(registrationRequestDTO).subscribe({
      next: value => {
        localStorage.setItem('gymMemberId', String(value.gymMemberId));
        this.router.navigate(['home']);
      },
      error: err => {
        this.toastr.error("Email already in use", "Registration failure");
      }
    })
  }
}
