import { SaveVehicle } from './../models/vehicle';
import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

@Injectable()
export class VehicleService {

  constructor(public http:Http) {
   } 
   getMakes(){
     return this.http.get('http://localhost:5000/api/makes')
     .map( res => res.json());
   }
    getFeatures(){
    return this.http.get('http://localhost:5000/api/features')
    .map(res => res.json());
    }
    create(vehicle) {
        return this.http.post('/api/vehicles', vehicle)
            .map(res => res.json());
    }
    getVehicle(id){
      return this.http.get('api/vehicles/'+id)
      .map( res => res.json());
    }
    getVehicles(){
      return this.http.get('api/vehicles')
      .map( res => res.json());
    }

    update(vehicle:SaveVehicle){
   
      return this.http.put('/api/vehicles/'+vehicle.id, vehicle)
      .map(res=> res.json());
    }
    delete(id) {
        return this.http.delete('/api/vehicles/' + id)
            .map(res => res.json());
    }
  
}
