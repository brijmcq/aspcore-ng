import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class PhotoService {
    vehicleRoute = '/api/vehicles/';
    constructor(private http: Http) {}
    upload(vehicleId, photo) {
    var formData = new FormData();
    formData.append('file', photo);
    return this.http.post(`${this.vehicleRoute}${vehicleId}/photos`, formData)
      .map(res => res.json());
     }

    getPhotos(vehicleId) {
    return this.http.get(`${this.vehicleRoute}${vehicleId}/photos`)
      .map(res => res.json());
    }
    deletePhoto(vehicleId,photoId,fileName){
      console.log('deleting...');
      return this.http.delete(`${this.vehicleRoute}${vehicleId}/photos?photoId=${photoId}&fileName=${fileName}`,)
      .map(res => res);
    }

    


}