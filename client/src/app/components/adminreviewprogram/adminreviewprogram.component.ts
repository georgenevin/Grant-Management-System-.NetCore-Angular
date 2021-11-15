import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ReviewserviceService } from 'src/app/services/reviewservice.service';
import { ReviewModel } from 'src/app/models/review-model';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-adminreviewprogram',
  templateUrl: './adminreviewprogram.component.html',
  styleUrls: ['./adminreviewprogram.component.css']
})
export class AdminreviewprogramComponent implements OnInit {


   applicantReviews:ReviewModel[]=[];
   reviews:ReviewModel[]=[];
   p: number = 1;
  constructor(private http:HttpClient,private reviewservice:ReviewserviceService,private toasterservice:ToastrService) { }

  ngOnInit(): void {

    this.getAllReviews();
    

  }

  getAllReviews()
  {

      this.reviewservice.getAllReviews().subscribe(response =>{

    
         this.applicantReviews=response;
         this.reviews=[...this.applicantReviews];


      })

  }

  saveReview(review:ReviewModel)
  {
     
      this.reviewservice.saveReview(review).subscribe(response =>{
        
         this.toasterservice.info("Review Saved Sucessfully");
         this.getAllReviews();

      },error=>{
        this.toasterservice.error(error.error);
        
      })
  }

  searchField(searchText:any)
  {

    
    let filterValue=searchText.target.value.toLowerCase();
    
    if(filterValue == "")
    {
      this.applicantReviews=this.reviews;
    }
    else
    {
      this.applicantReviews=this.reviews.filter((x:ReviewModel) => x.applicantName.toLowerCase().includes(filterValue) || x.programCode.toLowerCase().includes(filterValue)
      || x.country.toLowerCase().includes(filterValue));

    }

  }

}
