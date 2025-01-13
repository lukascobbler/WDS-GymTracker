import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {TrainingDTO} from '../../models/trainings/TrainingDTO';
import {CreateTrainingDTO} from '../../models/trainings/CreateTrainingDTO';
import {WeeklyTrainingStatisticsDTO} from '../../models/trainings/WeeklyTrainingStatisticsDTO';

@Injectable({
  providedIn: 'root'
})
export class TrainingsService {
  baseUrl: string = "http://localhost:8080/api/v1/trainings";

  constructor(private httpClient: HttpClient) { }

  getAllTrainingsForUser(userId: number): Observable<TrainingDTO[]> {
    return this.httpClient.get<TrainingDTO[]>(`${this.baseUrl}/${userId}`);
  }

  getTrainingStatisticsForUserForMonthAndYear(date: Date, userId: number): Observable<WeeklyTrainingStatisticsDTO[]> {
    return this.httpClient.get<WeeklyTrainingStatisticsDTO[]>(`${this.baseUrl}/${userId}/statistics/${date}/}`);
  }

  documentTrainingForUser(createTrainingDTO: CreateTrainingDTO, userId: number): Observable<TrainingDTO> {
    return this.httpClient.post<TrainingDTO>(`${this.baseUrl}/${userId}`, createTrainingDTO);
  }
}
