import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Task } from './task.model';  // Define this model

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private apiUrl = 'https://your-api-url/api/tasks';  // Replace with your actual API URL

  constructor(private http: HttpClient) { }

  // Create Task
  createTask(task: Task): Observable<Task> {
    return this.http.post<Task>(this.apiUrl, task);
  }

  // Get All Tasks
  getTasks(): Observable<Task[]> {
    return this.http.get<Task[]>(this.apiUrl);
  }

  // Edit Task
  editTask(id: number, task: Task): Observable<Task> {
    return this.http.put<Task>(`${this.apiUrl}/${id}`, task);
  }

  // Delete Task
  deleteTask(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  // Mark Task as Favorite
  favoriteTask(id: number): Observable<Task> {
    return this.http.post<Task>(`${this.apiUrl}/${id}/favorite`, {});
  }
}
