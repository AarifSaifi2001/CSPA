import { HttpErrorResponse, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, throwError } from "rxjs";
import { AlertifyService } from "./alertify.service";

@Injectable({
  providedIn: 'root'
})
export class HttpErrorInterceptorService implements HttpInterceptor{

  constructor(private alertify: AlertifyService){}

  intercept(request: HttpRequest<any>, next: HttpHandler ){
    console.log("Http request start");
    return next.handle(request)
    .pipe(catchError((error: HttpErrorResponse) => {
      const errorMessage = this.setError(error);
      console.log(errorMessage);
      this.alertify.error(errorMessage);
      return throwError(errorMessage);
    })
    );
  }

  setError(error: HttpErrorResponse): string{

    let errorMessage = "Unknown Error Occured";

    if(error.error instanceof ErrorEvent){
      // Client Side error
      errorMessage = error.error.message;
    }else{
      // Server side error
      if(error.status === 401){
        return "Unauthorize User Please Login before listing the Car";
      }

      if(error.status !== 0)
      errorMessage = error.error;
    }

    return errorMessage;
  }
}
