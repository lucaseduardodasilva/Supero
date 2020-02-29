import { Component, OnInit } from '@angular/core';
import { TaskDetailService } from 'src/app/shared/task-detail.service';
import { TaskDetail } from 'src/app/shared/task-detail.model';
import { ToastrService } from 'ngx-toastr';
import { IfStmt } from '@angular/compiler';

@Component({
  selector: 'app-task-detail-list',
  templateUrl: './task-detail-list.component.html',
  styles: []
})
export class TaskDetailListComponent implements OnInit {

  constructor(public service: TaskDetailService,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.service.refreshList();
  }

  populateForm(td: TaskDetail) {
    this.service.formData = Object.assign({}, td);
  }

  onDelete(TaskId) {
    if (confirm('Deseja realmente deletar a Task?')) {
    this.service.deleteTask(TaskId)
    .subscribe(res => {
      this.service.refreshList();
      this.toastr.warning('Task deletada.', 'SUPERO');
    },
      err => {
        console.log(err);
      });
    }
  }

}
