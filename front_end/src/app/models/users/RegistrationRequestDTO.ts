import {Gender} from './Gender';

export interface RegistrationRequestDTO {
  email: string;
  password: string;
  repeatPassword: string;
  gender: Gender;
  name: string;
  surname: string;
}
