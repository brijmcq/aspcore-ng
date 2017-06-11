import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

@Injectable()
export class MakeService {

  constructor(public http:Http) {
   } 
   getMakes(){
     return this.http.get('http://localhost:5000/api/makes')
     .map( res => res.json());
   }
}
