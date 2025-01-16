import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {TrainingTypeDTO} from '../../models/trainings/TrainingTypeDTO';

@Injectable({
  providedIn: 'root'
})
export class TrainingTypeService {
  baseUrl: string = "http://localhost:8080/api/v1/trainingTypes";

  constructor(private httpClient: HttpClient) { }

  getAllTrainingTypes(): Observable<TrainingTypeDTO[]> {
    return this.httpClient.get<TrainingTypeDTO[]>(`${this.baseUrl}/getAll`);
  }
}
