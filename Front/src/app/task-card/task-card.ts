import { Component, input } from '@angular/core';
import { TaskCardModel } from '../_models/task-card-model';

@Component({
  selector: 'app-task-card',
  imports: [],
  templateUrl: './task-card.html',
  styleUrl: './task-card.css',
})
export class TaskCard {
  task = input.required<TaskCardModel>();
  
}
