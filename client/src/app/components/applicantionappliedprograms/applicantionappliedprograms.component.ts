import { Component, OnInit } from '@angular/core';
import { ReviewserviceService } from 'src/app/services/reviewservice.service';
import { AccountserviceService } from 'src/app/services/accountservice.service';



@Component({
  selector: 'app-applicantionappliedprograms',
  templateUrl: './applicantionappliedprograms.component.html',
  styleUrls: ['./applicantionappliedprograms.component.css']
})
export class ApplicantionappliedprogramsComponent implements OnInit {

  userReviews:any=[];
  currentUser:string="";
  p: number = 1;
  constructor(private reviewservice:ReviewserviceService,private accountservice:AccountserviceService) { }

  ngOnInit(): void {
   this.getCurrentUserReviews();

  }
  
  getCurrentUserReviews()
  {
       
     var user=this.accountservice.userValue();
 
    this.reviewservice.getReviewByUsername(user.Email).subscribe(
      value=>
      {
        this.userReviews=value;
      console.log(this.userReviews);
      }
     


    );
   
  }


}
