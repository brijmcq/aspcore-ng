import { Component, OnInit } from '@angular/core';
import { KeyValuePair, Vehicle } from "../../models/vehicle";
import { VehicleService } from "../../services/vehicle.service";

@Component({
    selector: 'app-vehicle-list',
    templateUrl: './vehicle-list.component.html',
    styleUrls: ['./vehicle-list.component.css']
})
export class VehicleListComponent implements OnInit {
    private readonly PAGE_SIZE = 3;
    queryResult: any = {};
    makes: KeyValuePair[];
    query: any = {
        pageSize: this.PAGE_SIZE
    };
    columns = [
        { title: 'Id' },
        { title: 'Make', key: 'make', isSortable: true },
        { title: 'Model', key: 'model', isSortable: true },
        { title: 'Contact Name', key: 'contactName', isSortable: true },
        {}
    ];
    vehicles: Vehicle[];

    constructor(private vehicleService: VehicleService) { }
    ngOnInit() {

        this.vehicleService.getMakes()
            .subscribe(makes => this.makes = makes);

        this.populateVehicles();
    }

    private populateVehicles(): void {
        //  this.vehicleService.getVehicles(this.query)
        //     .subscribe( data =>{
        //         this.vehicles = data;
        //         // this.allVehicles=data;
        //         console.log('vehicles data', this.vehicles);
        //     });

        this.vehicleService.getVehicles(this.query)
            .subscribe(result => {
                this.queryResult = result;
                console.log('theresult', result);
            });
    }

    onFilterChange() {
        // var vehicles = this.allVehicles;
        // if(this.filter.makeId){
        //     vehicles = vehicles.filter(x=> x.make.id== this.filter.makeId);
        // }
        // if(this.filter.modelId){
        //      vehicles = vehicles.filter(x=> x.model.id== this.filter.modelId);
        // }    
        // this.vehicles = vehicles;

        this.query.page = 1;

        this.populateVehicles();
    }
    sortBy(columnName) {

        if (this.query.sortBy === columnName) {
            this.query.isSortAscending = !this.query.isSortAscending;
        } else {
            this.query.sortBy = columnName;
            this.query.isSortAscending = true;
        }
        this.populateVehicles();
    }
    onPageChange(page) {
        this.query.page = page;
        this.populateVehicles();
    }

    resetFilter() {

        this.query = {
            page: 1,
            pageSize: this.PAGE_SIZE
        };
        this.populateVehicles();
    }



}
