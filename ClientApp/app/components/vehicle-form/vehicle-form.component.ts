import { FeatureService } from './../../services/feature.service';
import { Component, OnInit } from '@angular/core';
import { MakeService } from "../../services/make.service";

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

  constructor( public makeService:MakeService,
                private featureService:FeatureService
    ) { }

  ngOnInit() {
   this.makeService.getMakes().subscribe( item =>{
      this.makes = item;
      }
    );
  this.featureService.getFeatures().subscribe(item =>{
      this.features = item;
  });
  }
  onMakeChange(){
  var selectedMake = this.makes.find( item => item.id ==this.vehicle.make);
  this.models = selectedMake?selectedMake.models:[];
  }

}
