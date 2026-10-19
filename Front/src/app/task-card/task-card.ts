import { Component, input, output } from '@angular/core';
import { TaskCardModel } from '../_models/task-card-model';

@Component({
  selector: 'app-task-card',
  imports: [],
  templateUrl: './task-card.html',
  styleUrl: './task-card.css',
})
export class TaskCard {
  deleteTaskEm = output<TaskCardModel>();
  task = input.required<TaskCardModel>();
  
  deleteTask() {
    this.deleteTaskEm.emit(this.task());
  }
}
