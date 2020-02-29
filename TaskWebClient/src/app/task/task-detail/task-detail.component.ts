import { Component, OnInit } from '@angular/core';
import { TaskDetailService } from 'src/app/shared/task-detail.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-task-detail',
  templateUrl: './task-detail.component.html',
  styles: []
})
export class TaskDetailComponent implements OnInit {

  constructor(public service: TaskDetailService,
    private toastr: ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }


  resetForm(form?: NgForm) {
    if (form != null)
      form.resetForm();
    this.service.formData = {
      TaskId : 0,
      Title : '',
      Description : ''
    };
  }

  onSubmit(form: NgForm) {
    if (this.service.formData.TaskId == 0) {
      this.insertRecord(form);
    }
    else {
      this.updateRecord(form);
    }
  }

  insertRecord(form: NgForm){
    this.service.postTask()
    .subscribe(res => {
      this.resetForm(form);
      this.toastr.success('Task criada com sucesso!', 'SUPERO');
      this.service.refreshList();
    },
      err => {
        console.log(err);
        //this.toastr.error('Erro ao criar a Task.', 'Task Register');
      });
  }

  updateRecord(form: NgForm){
    this.service.putTask()
    .subscribe(res => {
      this.resetForm(form);
      this.toastr.info('Task atualizada com sucesso!', 'SUPERO');
      this.service.refreshList();
    },
      err => {
        console.log(err);
        //this.toastr.error('Erro ao criar a Task.', 'Task Register');
      });
  }


}
