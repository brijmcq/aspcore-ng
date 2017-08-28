import { Injectable } from '@angular/core';
import { Http, Response, BrowserXhr } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Subject } from "rxjs/Subject";


@Injectable()
export class ProgressService {
  private uploadProgress: Subject<any>;
  private downloadProgress: Subject<any>;
   startTracking() { 
    this.uploadProgress = new Subject();
    return this.uploadProgress;
  }

  notify(progress) {
    if (this.uploadProgress)
      this.uploadProgress.next(progress);
  }

  endTracking() {
    if (this.uploadProgress)
      this.uploadProgress.complete();
  }

}



@Injectable()
export class BrowserXhrWithProgress extends BrowserXhr {

  constructor(private service: ProgressService) { super(); }

  build(): XMLHttpRequest {
    var xhr: XMLHttpRequest = super.build();

  //   //for downloads
  //   xhr.onprogress = (event) => {
  //     this.service.downloadProgress.next(this.createProgress(event));
  // }
  
  xhr.upload.onprogress = (event:ProgressEvent) => {
  this.service.notify(this.createProgress(event));
    };

  xhr.upload.onloadend = () => {
    this.service.endTracking();
  }
  return xhr; 
  
}

  private createProgress(event : ProgressEvent) {
    return {
        total: event.total,
        percentage: Math.round(event.loaded / event.total * 100)
    };
  }
}
