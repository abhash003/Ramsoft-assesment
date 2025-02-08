import { Component } from '@angular/core';
import { TaskService } from '../task.service';
import { Task } from '../task.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-task-create',
  standalone: true,
  templateUrl: './task-create.component.html',
  styleUrls: ['./task-create.component.scss']
})
export class TaskCreateComponent {
  task: Task = {
    id: 0,
    name: '',
    description: '',
    deadline: '',
    isFavorite: false,
    status: 'ToDo'
  };

  constructor(private taskService: TaskService, private router: Router) {}

  createTask() {
    this.taskService.createTask(this.task).subscribe(() => {
      this.router.navigate(['/tasks']);
    });
  }
}
