import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  features: any;
  makes: any[];
  models:any[];
  vehicle:any={};

  constructor( public vehicleService:VehicleService
    ) { }

  ngOnInit() {
   this.vehicleService.getMakes().subscribe( item =>{
      this.makes = item;
      }
    );
  this.vehicleService.getFeatures().subscribe(item =>{
      this.features = item;
  });
  }
  onMakeChange(){
  var selectedMake = this.makes.find( item => item.id ==this.vehicle.make);
  this.models = selectedMake?selectedMake.models:[];
  }

}
