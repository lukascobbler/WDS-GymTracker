import {CanActivateFn, Router} from '@angular/router';
import {inject} from '@angular/core';
import {UsersService} from '../services/users/users.service';

export const homeAuthGuard: CanActivateFn = (route, state) => {
  const router = inject(Router);

  if (localStorage.getItem('userId') !== null) {
    return true;
  } else {
    router.navigate(['']);
    return false;
  }
};

export const loginAuthGuard: CanActivateFn = (route, state) => {
  const router = inject(Router);

  if (localStorage.getItem('userId') === null) {
    return true;
  } else {
    router.navigate(['home']);
    return false;
  }
};
