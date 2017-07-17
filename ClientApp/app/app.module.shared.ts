import { FormsModule } from '@angular/forms';
import { CoreModule } from './core.module';
import { VehicleFormComponent } from './components/vehicle-form/vehicle-form.component';
import { VehicleListComponent } from './components/vehicle-list/vehicle-list.component';
import { NgModule, ErrorHandler } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import {ToastyModule} from 'ng2-toasty';
import { AppErrorHandler } from "./app.error-handler";
import * as Raven from 'raven-js';
import { FeatureResolver } from "./shared/feature.resolver";
import { PaginationComponent } from "./shared/pagination.component";
import { ViewVehicleComponent } from "./components/view-vehicle/view-vehicle.component";

Raven
  .config('https://6af4991b0e4d41a58a845963d9d86407@sentry.io/180651')
  .install();



export const sharedConfig: NgModule = {
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        VehicleFormComponent,
        VehicleListComponent,
        PaginationComponent,
        ViewVehicleComponent
    ],
    imports: [
        CoreModule,
        ToastyModule.forRoot(),
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'vehicles', pathMatch: 'full' },
            { path: 'vehicles/new', component:VehicleFormComponent,
              resolve:{
                  feature:FeatureResolver
              }
             },
            { path: 'vehicles/edit/:id', component: VehicleFormComponent},
            { path: 'vehicles/:id', component: ViewVehicleComponent },
            { path: 'vehicles', component: VehicleListComponent },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
};
