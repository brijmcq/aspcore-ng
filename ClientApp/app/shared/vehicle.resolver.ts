import { Vehicle } from './../models/vehicle';
import { VehicleService } from './../services/vehicle.service';

import { Injectable } from '@angular/core'; 
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";

@Injectable()
export class VehicleResolver implements Resolve<Vehicle> {

    constructor(private vehicleService:VehicleService) {}
    resolve(route: ActivatedRouteSnapshot): Observable<any> {
    return this.vehicleService.getVehicle(route.params.id);
  }

}