import { FeatureService } from './services/feature.service';
import { MakeService } from './services/make.service';

import { NgModule } from "@angular/core";

@NgModule({
    providers: [
     MakeService,
     FeatureService
    ]
})  
export class CoreModule {
}
