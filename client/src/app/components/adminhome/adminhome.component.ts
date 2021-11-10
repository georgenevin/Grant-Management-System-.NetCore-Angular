import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-adminhome',
  templateUrl: './adminhome.component.html',
  styleUrls: ['./adminhome.component.css']
})
export class AdminhomeComponent implements OnInit {

   adminHomeActive:boolean=true;
   adminGrantActive:boolean=false;
   adminReviewActive:boolean=false;
   
  constructor() { }

  ngOnInit(): void {

     

  }

  grantHandler():void{

    this.adminHomeActive=false;
    this.adminReviewActive=false;
    this.adminGrantActive=true;
   

  }

  grantAdminHome():void{

    this.adminHomeActive=true;
    this.adminReviewActive=false;
    this.adminGrantActive=false;
  }

  grantAdminReview():void{

     
    this.adminHomeActive=false;
    this.adminReviewActive=true;
    this.adminGrantActive=false;
  }

}
