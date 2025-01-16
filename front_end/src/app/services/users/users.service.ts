import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {LoginRequestDTO} from '../../models/users/LoginRequestDTO';
import {Observable} from 'rxjs';
import {RegistrationRequestDTO} from '../../models/users/RegistrationRequestDTO';
import {UserDTO} from '../../models/users/UserDTO';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  baseUrl: string = "http://localhost:8080/api/v1/users";

  constructor(private httpClient: HttpClient) { }

  login(request: LoginRequestDTO): Observable<UserDTO> {
    return this.httpClient.post<UserDTO>(`${this.baseUrl}/login`, request);
  }

  register(request: RegistrationRequestDTO): Observable<UserDTO> {
    return this.httpClient.post<UserDTO>(`${this.baseUrl}/registration`, request);
  }
}
