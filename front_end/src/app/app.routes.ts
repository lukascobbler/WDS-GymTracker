import { Routes } from '@angular/router';
import {LoginRegisterScreenComponent} from './role-pages/logged-out-user/login-register-screen.component';
import {HomeComponent} from './role-pages/regular-user/home/home.component';
import {homeAuthGuard, loginAuthGuard} from './guards/auth-guards';
import {PageNotFoundComponent} from './role-pages/common/page-not-found/page-not-found.component';

export const routes: Routes = [
  { path: "", canActivate: [loginAuthGuard], component: LoginRegisterScreenComponent, pathMatch: 'full' },
  { path: "home", canActivate: [homeAuthGuard], component: HomeComponent },
  { path: "**", component: PageNotFoundComponent }
];
