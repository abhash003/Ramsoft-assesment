import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TaskService } from './task.service';
import { TaskListComponent } from './task-list/task-list.component';

import { AppComponent } from './app.component';
import { TaskCreateComponent } from './task-create/task-create.component';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent,         // Your main app component
    TaskListComponent,    // Component for listing tasks
    TaskCreateComponent,  // Component for creating tasks
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,     // Routing configuration
  ],
  providers: [TaskService], // Service for making HTTP requests
  bootstrap: [AppComponent],  // Root component to bootstrap
})
export class AppModule {}
