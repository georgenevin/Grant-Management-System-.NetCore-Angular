import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ReviewModel } from '../models/review-model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReviewserviceService {

   url ="http://localhost:54413/api/Review/"
  constructor(private http:HttpClient) { }



  getAllReviews():Observable<ReviewModel[]>{

   var reviews=this.http.get<ReviewModel[]>(this.url+'GetReviews');
   return reviews

  }

  saveReview(review:any):Observable<ReviewModel>{
  
      review.reviewerStatus=="true"?review.reviewerStatus=true:review.reviewerStatus=false;
     var savedReview=this.http.post<ReviewModel>(this.url+'SaveReview',review);
     return savedReview;



  }

   getReviewByUsername(user: any):Observable<ReviewModel[]>
   {

       var userReview=this.http.get<ReviewModel[]>(this.url+'GetAdminReview'+user);
       return userReview;
   }

}
