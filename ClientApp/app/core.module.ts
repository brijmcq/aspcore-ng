
import { VehicleService } from './services/vehicle.service';

import { NgModule, ErrorHandler } from "@angular/core";
import { AppErrorHandler } from "./app.error-handler";

@NgModule({
    providers: [
     VehicleService,
       {provide: ErrorHandler, useClass:AppErrorHandler}
    ]
})  
export class CoreModule {
}
