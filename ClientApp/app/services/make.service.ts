import { Injectable } from '@angular/core';
import { Http  } from "@angular/http";

@Injectable()
export class MakeService {

    private readonly serverUrl = '/api/makes/';
    constructor(public http:Http) {
     } 
      create(make) {
          console.log('creating make',make);

        // let headers = new Headers({ 'Content-Type': 'application/json' });
        // let options = new RequestOptions({ headers: headers });

        var data = {name:make};
          return this.http.post(this.serverUrl, data)
          .map(res => res);
      }

  
}