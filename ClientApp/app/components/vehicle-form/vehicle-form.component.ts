import { SaveVehicle, Vehicle } from './../../models/vehicle';
import { isDevMode } from '@angular/core';
import { VehicleService } from './../../services/vehicle.service';
import { Component, OnInit } from '@angular/core';
import { ToastyService } from "ng2-toasty";
import { ActivatedRoute, Router } from "@angular/router";
import { Observable } from "rxjs/Observable";
import 'rxjs/add/Observable/forkJoin';
import * as _ from 'underscore';



@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  features: any;
  makes: any[];
  models:any[];
  vehicle: SaveVehicle = {
      id:0,
      makeId:0,
      modelId:0,
      isRegistered:false,
      features: [],
      contact: {
          name:'',
          email:'',
          phone:''
      }
  };

  constructor( public vehicleService:VehicleService,
    private route:ActivatedRoute,
    private router:Router,
    private toastyService:ToastyService
    ) { 
  
        route.params.subscribe( x=>{
            this.vehicle.id = +x['id']|| 0;
          console.log('may id');
        }, error =>{
            if(error.status==404)
            this.router.navigate(['/home']);
        });

    }

  ngOnInit() {
      this.features = this.route.snapshot.data['feature'];
   
      var sources = [
        this.vehicleService.getMakes(),
      //  this.vehicleService.getFeatures()
      ];
      if(this.vehicle.id){
          sources.push(  this.vehicleService.getVehicle(this.vehicle.id));
      }
       Observable.forkJoin( sources)
       .subscribe( data =>{
           console.log('datas',data);
            this.makes = data[0];
          //  this.features = data[1];
            if(this.vehicle.id){
                   this.setVehicle(data[1]);
                   this.populateModels();
            }
             
       }, error =>{
            if(error.status==404)
            this.router.navigate(['/home']);
       });
  }

  private setVehicle(v:Vehicle){
   this.vehicle.id = v.id;
   this.vehicle.makeId = v.make.id;
   this.vehicle.modelId = v.model.id;
   this.vehicle.isRegistered=v.isRegistered;
   this.vehicle.contact = v.contact;
   this.vehicle.features = _.pluck(v.features, 'id');
  }
  onMakeChange(){
    this.populateModels();
  delete this.vehicle.modelId;
}
    private populateModels(){
    var selectedMake = this.makes.find( item => item.id ==this.vehicle.makeId);
    this.models = selectedMake ? selectedMake.models : [];
    }
  onFeatureToggle(featureId,$event) {
      if ($event.target.checked) {
          this.vehicle.features.push(featureId);
      } else {
         var index = this.vehicle.features.indexOf(featureId);
         this.vehicle.features.splice(index, 1);
      }
    }
  onDelete() {
      if (confirm("Do you really want to delete this data?")) {
          this.vehicleService.delete(this.vehicle.id)
              .subscribe(x => {
                  this.router.navigate(['/home']);
              });
      }
  }
  onSubmit() {
     
        if(this.vehicle.id){
          
            this.vehicleService.update(this.vehicle)
            .subscribe(x=> {
                console.log('update success?');
                this.toastyService.success({
                    title:'Success',
                    msg:'Data updated',
                    theme:'bootstrap',
                    showClose:true,
                    timeout:3000
                })
            })
        }
        else{
         this.vehicleService.create(this.vehicle)
          .subscribe(x => {
            this.router.navigate(['/vehicles']);
        });
        }
  }
}
