import { Component, OnInit } from '@angular/core';
import { MakeService } from "../../services/make.service";

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: any[];
  models:any[];
  vehicle:any={};

  constructor( public makeService:MakeService) { }

  ngOnInit() {
   this.makeService.getMakes().subscribe( item =>{
      this.makes = item;
      }
    );
  }
  onMakeChange(){
  var selectedMake = this.makes.find( item => item.id ==this.vehicle.make);
  this.models = selectedMake?selectedMake.models:[];
  }

}
