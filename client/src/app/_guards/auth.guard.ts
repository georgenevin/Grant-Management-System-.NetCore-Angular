import { Injectable } from '@angular/core';
import { ActivatedRoute, CanActivate, Router, ActivatedRouteSnapshot, UrlTree } from '@angular/router';
import { Observable,Subscription } from 'rxjs';
import { UiserviceService } from '../services/uiservice.service';
import { ToastrService } from 'ngx-toastr';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserModel } from '../models/user-model';



@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  showCurrentuser:boolean=false;
  subscription:Subscription=new Subscription();

  constructor(private uiservice:UiserviceService,private toaster:ToastrService,
    private route:Router,private jwtHelper:JwtHelperService){
 
    this.subscription=this.uiservice.anyLoggedUser().subscribe(value=>this.showCurrentuser =value);
  }
 

  canActivate(routers:ActivatedRouteSnapshot):any
   {
      
         const tokens=localStorage.getItem("user") as string;
         if(tokens)
         {
          const clientData:UserModel=JSON.parse(tokens);
          const usetRoles=this.jwtHelper.decodeToken(clientData.Token);
          var route=routers.data.role.includes(usetRoles.role.toLowerCase());
          
          if( !this.jwtHelper.isTokenExpired(clientData.Token) && usetRoles.role &&  route)
          {
         
              return true;
          }
 
         }
       

         this.toaster.error("Please Login")
         this.route.navigateByUrl("");
        

    
   }

 
  
}
