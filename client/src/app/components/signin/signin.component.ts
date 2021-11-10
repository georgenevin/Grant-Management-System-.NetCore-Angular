import { Component, OnInit, Output,EventEmitter} from '@angular/core';
import {AccountserviceService} from '../../services/accountservice.service'
import {LoginModel} from '../../models/loginModel';
import {UserModel} from '../../models/user-model'
import { FormControl, FormGroup, Validators,ReactiveFormsModule  } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ToasterPostion } from 'src/app/enum/toaster-postion';
import { Router } from '@angular/router';
import { UiserviceService } from 'src/app/services/uiservice.service';



@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {

   @Output() userLogged:EventEmitter<UserModel> =new EventEmitter();
  User:LoginModel={Email:"",Token:"",Password:""};
  Login:UserModel={Email:"",Token:"",UserType:""};

  LoginForm:FormGroup=new FormGroup({
    Email:new FormControl('',[Validators.required,Validators.email,Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$')]),
    Password:new FormControl('',Validators.required,),

   });
   
  currentUser:UserModel={Email:"",Token:"",UserType:""};

  constructor(private accountService:AccountserviceService,private toasterServie:ToastrService,private router:Router,private uiservice:UiserviceService) { }

  ngOnInit(): void {

 
   
  }

  login(){
  
    if(this.LoginForm.valid)
    {

      this.accountService.login(this.LoginForm.value).subscribe((response:any) =>
      {
       
          this.Login.Email=response.email;
          this.Login.Token=response.token;
          localStorage.setItem('user',JSON.stringify(this.Login));
          this.userLogged.emit(this.Login);
      },error => {
        
      
          this.toasterServie.error(error.error,'Error',{positionClass : ToasterPostion.topRight});
          
        
  
      });
    }
    else
    {
          this.toasterServie.error("Invalid Form Data")
    }
 

      
  }

 

  logout(){

    this.accountService.logout();
    

  }

  loginFormhandler()
  {
    console.log("theee");
    console.log(this.LoginForm)
  }

 

}
