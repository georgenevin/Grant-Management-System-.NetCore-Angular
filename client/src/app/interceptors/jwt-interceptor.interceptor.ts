import { Injectable } from '@angular/core';
import { AccountserviceService } from '../services/accountservice.service';


import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable()
export class JwtInterceptorInterceptor implements HttpInterceptor {

  constructor(private accountService:AccountserviceService) {



  }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
 
    const user=this.accountService.userValue();
    const isLoggedIn=user && user.Token;
    const isApiUrl=request.url.startsWith('http://localhost:54413/');

     if(isLoggedIn && isApiUrl)
     {
       request=request.clone({
         setHeaders:{
           Authorization:`Bearer ${user.Token}`
         }
       })
     }

     return next.handle(request);
  }
}
