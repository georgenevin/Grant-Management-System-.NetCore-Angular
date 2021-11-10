import { Component, OnInit } from '@angular/core';
import { UiserviceService } from '../../services/uiservice.service';
import { Subscription } from 'rxjs';
import {UserModel } from '../../models/user-model';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  showApplicationPage:boolean=false;
   subscription:Subscription=new Subscription();

  ngOnInit(): void {

        this.userRedirectOnStart();
  }


   constructor(private uiService:UiserviceService,private jwthelper:JwtHelperService,private router:Router)
   {
   this.subscription=this.uiService.onLogged().subscribe(value => this.showApplicationPage =value) ;
   }

  togglePages(loggedUser:UserModel):void
  {

    

    var decodeToken=this.jwthelper.decodeToken(loggedUser.Token);

    if(decodeToken.role.toLowerCase() =="applicants")
    {
      
       this.uiService.loggingHandler();
       this.router.navigateByUrl("/Application");
     
      

   
    }
   else if(decodeToken.role.toLowerCase() =="admin")
    {

      this.uiService.loggingHandler();
      this.router.navigateByUrl("/admin-home");


    }

    else
    {
      
      this.router.navigateByUrl("");

    }

    
    // if(loggedUser.Email !=="")
    // {
    //   if(loggedUser.UserType == "Applicants")
    //   {
     
    //     this.uiService.showGantRegistrPage(true);
    //   }
    //   else
    //   {
    //     this.uiService.showGantRegistrPage(false);
    //   }
    // }
  
   
    
   
 
  }

 userRedirectOnStart():void
 {
  
           var token:any=localStorage.getItem("user");
           if(token)
           {
             var tokenJson=JSON.parse(token);
            var decodeToken=this.jwthelper.decodeToken(tokenJson.Token);

            if(decodeToken.role.toLowerCase() =="applicants")
            {
              
               this.uiService.loggingHandler();
               this.router.navigateByUrl("/Application");
             
              
        
           
            }
           else if(decodeToken.role.toLowerCase() =="admin")
            {
              this.uiService.loggingHandler();
              this.router.navigateByUrl("/admin-home");
            }
           }
           else
           {
            this.router.navigateByUrl("");
           }

 }

}
