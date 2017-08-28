import { MakeService } from './../../services/make.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from "@angular/forms";

@Component({
  selector: 'app-make-form',
  templateUrl: './make-form.component.html',
  styleUrls: ['./make-form.component.css']
})
export class MakeFormComponent implements OnInit {
  make:any;

  constructor(
    private makeService:MakeService
  ) { }

  ngOnInit() {
  }

  onSubmit(){

  }
  logForm(form: NgForm) {
    console.log('FORM', form);
    this.makeService.create(form.value.name)
    .subscribe( result =>{
      console.log('result',result);
    });
  }


}
