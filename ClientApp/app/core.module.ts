import { MakeService } from './services/make.service';
import { BrowserXhrWithProgress, ProgressService } from './services/progress.service';
import { BrowserXhr } from '@angular/http';
import { FeatureResolver } from './shared/feature.resolver';

import { VehicleService } from './services/vehicle.service';

import { NgModule, ErrorHandler } from "@angular/core";
import { AppErrorHandler } from "./app.error-handler";
import { VehicleResolver } from "./shared/vehicle.resolver";
import { PhotoService } from "./services/photo.service";
import { ModelService } from "./services/model.service";

@NgModule({
    providers: [
     VehicleService,
     VehicleResolver,
     FeatureResolver,
     PhotoService,
     MakeService,
     ModelService,
       {provide: ErrorHandler, useClass:AppErrorHandler}
    ]
})  
export class CoreModule {
}
