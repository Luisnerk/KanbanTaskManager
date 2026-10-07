import { Component, inject, OnInit, signal } from '@angular/core';
import { TaskCard } from '../task-card/task-card';
import { CdkDrag, CdkDragDrop, CdkDropList, transferArrayItem } from '@angular/cdk/drag-drop';
import { TaskCardModel } from '../_models/task-card-model';
import { TaskCardService } from '../_services/task-card-service';

@Component({
  selector: 'app-task-board',
  imports: [TaskCard, CdkDrag, CdkDropList],
  templateUrl: './task-board.html',
  styleUrl: './task-board.css',
})
export class TaskBoard {
  private readonly _taskCardService = inject(TaskCardService);

  newTasks = signal<TaskCardModel[]>([]);
  ongoingTasks = signal<TaskCardModel[]>([]);
  completedTasks = signal<TaskCardModel[]>([]);

  ngOnInit() {
    this.loadTaskCards();
  }

  loadTaskCards() {
    var tasks: TaskCardModel[] = [];
    this._taskCardService.getAllTasks().subscribe({
      next: (data) => {
        tasks.push(...data);
        this.newTasks.set(tasks.filter(task => task.status == 0));
        this.ongoingTasks.set(tasks.filter(task => task.status == 1));
        this.completedTasks.set(tasks.filter(task => task.status == 2));
      },
      error: err => {
        console.error("Error al cargar las actividades");
      }
    });

  }

  drop(event: CdkDragDrop<TaskCardModel[]>) {
    console.log(event.previousContainer.id);
    transferArrayItem(event.previousContainer.data,
                      event.container.data,
                      event.previousIndex,
                      event.currentIndex
    )
  }
}
