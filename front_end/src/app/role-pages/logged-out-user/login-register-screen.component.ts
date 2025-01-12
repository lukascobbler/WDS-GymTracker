import { Component } from '@angular/core';
import {LoginFormComponent} from './login-form/login-form.component';
import {RegisterFormComponent} from './register-form/register-form.component';
import {NgIf} from '@angular/common';

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
}
