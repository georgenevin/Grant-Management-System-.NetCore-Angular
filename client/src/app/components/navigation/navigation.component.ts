import { Component, OnInit } from '@angular/core';
import { UiserviceService } from 'src/app/services/uiservice.service';
import { Subscription } from 'rxjs';
import { AccountserviceService } from 'src/app/services/accountservice.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {

   showCurrentuser:boolean=false;
   subscription:Subscription=new Subscription();
   showReviewPage:boolean=false;
   currentUrl:boolean=true;
  constructor(private uiservice:UiserviceService,private accountservice:AccountserviceService,private router:Router) { 
  
     this.subscription=this.uiservice.anyLoggedUser().subscribe(value=>
    
      this.showCurrentuser =value
      );
     this.subscription=this.uiservice.showReview.subscribe(value => this.showReviewPage =value);

  }

  ngOnInit(): void {

    
     this.uiservice.reviewPageHandler();
     this.uiservice.loggingHandler();
      
     this.currentUrl=this.router.url === "/Application/appliedprograms" ?false:true;
    

  
      
      

  }

  LogOut():void
  {

    this.accountservice.logout();
    this.uiservice.loggingHandler();

  }

 

}
