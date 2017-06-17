import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';
import { ToastyService } from "ng2-toasty";

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  features: any;
  makes: any[];
  models:any[];
  vehicle: any = {
      features: [],
      contact: {}
  };

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
  var selectedMake = this.makes.find( item => item.id ==this.vehicle.makeId);
  this.models = selectedMake ? selectedMake.models : [];
  delete this.vehicle.modelId;
  }
  onFeatureToggle(featureId,$event) {
      if ($event.target.checked) {
          this.vehicle.features.push(featureId);
      } else {
         var index = this.vehicle.features.indexOf(featureId);
         this.vehicle.features.splice(index, 1);
      }
  }
  onSubmit() {
      this.vehicleService.create(this.vehicle)
          .subscribe(x => console.log('success'));
        
          
  }

}
