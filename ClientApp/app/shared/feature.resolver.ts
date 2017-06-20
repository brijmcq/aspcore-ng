import { VehicleService } from './../services/vehicle.service';
import { Injectable } from '@angular/core'; 
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";

@Injectable()
export class FeatureResolver implements Resolve<any> {

    constructor(private vehicleService:VehicleService) {}
    resolve(route: ActivatedRouteSnapshot): Observable<any> {
    return this.vehicleService.getFeatures();
  }

}