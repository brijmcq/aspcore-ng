import { NgForm } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { VehicleService } from "../../services/vehicle.service";
import { ModelService } from "../../services/model.service";

@Component({
  selector: 'app-model-form',
  templateUrl: './model-form.component.html',
  styleUrls: ['./model-form.component.css']
})
export class ModelFormComponent implements OnInit {

  constructor(private vehicleService: VehicleService,
              private modelService: ModelService) { }

  makes:any[];
  selectedMake:any;
  models:any[];
  ngOnInit() {
    this.vehicleService.getMakes().subscribe( data =>{
      this.makes = data;
    });
    
  }

  onAddModel( form :NgForm){

    console.log('submit', form);
    const makeId = form.controls['makeId'].value;
    const modelName = form.controls['modelName'].value;
    this.modelService.addModel(makeId,modelName)
    .subscribe( res =>{
      console.log('res');
    });
  }

  onMakeChange(){
    var selectedMake = this.makes.find( x => x.id == this.selectedMake.id);
    this.models = selectedMake? selectedMake.models : [];
  }

}
