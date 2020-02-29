import { Injectable } from '@angular/core';
import { TaskDetail } from './task-detail.model';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class TaskDetailService {

  formData: TaskDetail;
  readonly rootURL = 'http://localhost:60492/api/task/';
  list: TaskDetail[];

  constructor(private http: HttpClient) { }

  postTask() {
    return this.http.post(this.rootURL + 'CreateTask', this.formData);
  }

  putTask() {
    return this.http.put(this.rootURL + 'UpdateTask/' + this.formData.TaskId, this.formData);
  }

  deleteTask(id) {
    return this.http.delete(this.rootURL + 'DeleteTask/' + id);
  }

  refreshList() {
    this.http.get(this.rootURL + 'GetTasks')
    .toPromise()
    .then(res => this.list = res as TaskDetail[]);
  }
}
