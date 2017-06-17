
import { ErrorHandler, Inject, NgZone } from "@angular/core";
import { ToastyService } from "ng2-toasty";
import * as Raven from 'raven-js';
export class AppErrorHandler implements ErrorHandler{
    constructor(@Inject(ToastyService) private toastyService:ToastyService,
    private ngZone:NgZone
    ){}
    handleError(error: any): void {
        Raven.captureMessage(error.originalError||error);
        this.ngZone.run(()=>{
             this.toastyService.error({
                title:'Error',
                msg:'Contact admin',
                theme:'bootstrap',
                showClose:true,
                timeout:4000
                });
        });

       
    }

}