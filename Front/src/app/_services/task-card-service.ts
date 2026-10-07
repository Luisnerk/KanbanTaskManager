import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Observable } from 'rxjs';
import { TaskCardModel } from '../_models/task-card-model';

@Injectable({
  providedIn: 'root',
})
export class TaskCardService {
  http = inject(HttpClient);
  apiUrl = environment.apiUrl;

  getAllTasks(): Observable<TaskCardModel[]> {
    return this.http.get<TaskCardModel[]>(this.apiUrl + "getAllTasks");
  }
}
