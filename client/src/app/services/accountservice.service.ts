import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import {LoginModel} from '../models/loginModel'
import { UserModel } from '../models/user-model';
import { RegisterModel } from '../models/register-model';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { JwtHelperService } from '@auth0/angular-jwt';

const HttpOptions={
  headers:new HttpHeaders({
  
    'Content-Type':'application/json'
  
  })
  
  }
@Injectable({
  providedIn: 'root'
})
export class AccountserviceService {

   private url:string ="http://localhost:54413/api/Account/";
   user:LoginModel={Email:"",Token:"",Password:""};
   currentUser:UserModel={Email:"",Token:"",UserType:""}
  constructor(private http:HttpClient,private router:Router,private toasterService:ToastrService,private jwtServices:JwtHelperService) { }

  login(login:any){
 
   var loginUser=  this.http.post(this.url +'Login',login,HttpOptions);
  
   return loginUser;

  }


  logout()
  {
    
    localStorage.removeItem('user');
    this.router.navigateByUrl("");
    this.toasterService.info('Succesfully Logged Out');
  }

   getCurrentUser():boolean
   {
  
     const tokens=localStorage.getItem("user") as string;
     var userModel=false;
     if(tokens)
     {
      const clientData:UserModel=JSON.parse(tokens);
      if(!this.jwtServices.isTokenExpired(clientData.Token))
      {
       userModel=true;
      }

    }
    
    
     return userModel;
   }


   Register(registerUser:any)
   {

      var registeredUser=this.http.post(this.url + 'Register',registerUser,HttpOptions);
      return registeredUser;

   }

   userValue()
   {
     const user =localStorage.getItem("user") as string;
     var userModel=null;
     if(user)
     {
      userModel=JSON.parse(user);
      

     }
     return userModel;
   }


}
