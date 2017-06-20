import { FeatureResolver } from './shared/feature.resolver';

import { VehicleService } from './services/vehicle.service';

import { NgModule, ErrorHandler } from "@angular/core";
import { AppErrorHandler } from "./app.error-handler";
import { VehicleResolver } from "./shared/vehicle.resolver";

@NgModule({
    providers: [
     VehicleService,
     VehicleResolver,
     FeatureResolver,
       {provide: ErrorHandler, useClass:AppErrorHandler}
    ]
})  
export class CoreModule {
}
