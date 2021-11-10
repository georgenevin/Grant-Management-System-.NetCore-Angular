import { Injectable } from '@angular/core';
import { Observable, Subject, ReplaySubject, BehaviorSubject } from 'rxjs';
import { UserModel } from '../models/user-model';
import { AccountserviceService } from '../services/accountservice.service'
import { JwtHelperService } from '@auth0/angular-jwt';


@Injectable({
  providedIn: 'root'
})
export class UiserviceService {

  private showApplicationPage: boolean = false;
  private subject = new ReplaySubject<any>(1);
  private reviewsource=new BehaviorSubject(false);
  showReview = this.reviewsource.asObservable();

   jwtServices: any;
  
  private isUserLoggedIn: boolean = false;
  private showReviewPage: boolean = false;


  constructor(private accountService: AccountserviceService, private jwtHelper: JwtHelperService) { }

  showGantRegistrPage(display: boolean): void {

    this.showApplicationPage = display;
    this.subject.next(this.showApplicationPage);

  }

  onLogged(): Observable<any> {
    return this.subject.asObservable();
  }


  loggingHandler() {

    const loggedUser = this.accountService.getCurrentUser();
    if (loggedUser) {
      this.isUserLoggedIn = true;
    }
    else {
      this.isUserLoggedIn = false;
    }

    this.subject.next(this.isUserLoggedIn);

  }


  anyLoggedUser() {
    return this.subject.asObservable();
  }


  reviewPageHandler() {
   
    const currentUser = this.accountService.userValue();
    this.showReviewPage=false;

    if (currentUser) {
   
     
      if (!this.jwtHelper.isTokenExpired(currentUser.Token)) {
        var decodeToken = this.jwtHelper.decodeToken(currentUser.Token);
        if (decodeToken.role.toLowerCase() == "applicants") {
        
            this.showReviewPage=true;
        }
        else if (decodeToken.role.toLowerCase() == "admin") {
              
              this.showReviewPage=false;
        }
      }

    }
   
    this.reviewsource.next(this.showReviewPage);

  }

  isshowReviewPage():Observable<any>{


    return this.subject.asObservable();

  }









}
