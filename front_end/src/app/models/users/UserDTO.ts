import {Gender} from './Gender';

export interface UserDTO {
  id: number;
  email: string;
  password: string;
  gender: Gender;
  name: string;
  surname: string;
}
