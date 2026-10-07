import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TaskBoard } from './task-board/task-board';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, TaskBoard],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Front');
}
