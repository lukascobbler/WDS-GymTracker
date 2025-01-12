import { Routes } from '@angular/router';
import {LoginRegisterScreenComponent} from './role-pages/logged-out-user/login-register-screen.component';
import {HomeComponent} from './role-pages/regular-user/home/home.component';

export const routes: Routes = [
  { path: "", component: LoginRegisterScreenComponent, pathMatch: 'full' },
  { path: "home", component: HomeComponent },
];
