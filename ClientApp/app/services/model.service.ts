import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class ModelService {
    private readonly serverUrl = '/api/makes/models';
    constructor(private http: Http) { }

    addModel(makeId:number, modelName:string){
        var data = {id: makeId, name:modelName};
        return this.http.post(this.serverUrl, data)
        .map(res => res);
    }  
    
}