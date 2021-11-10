import { Component, OnInit } from '@angular/core';
import {AccountserviceService} from '../../services/accountservice.service'
import { ToastrService } from 'ngx-toastr';
import { FormControl, FormGroup, Validators,ValidatorFn, AbstractControl } from '@angular/forms';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {


  RegisterForm:FormGroup=new FormGroup({
    Email:new FormControl('',[Validators.required,Validators.email,Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$')]),
    FirstName:new FormControl('',[Validators.required]),
    LastName:new FormControl('',[Validators.required]),
    Password:new FormControl('',[Validators.required]),
    ConfirmPassword:new FormControl('',[Validators.required,this.matchPassword('Password')]),
   

   });

  

  constructor(private accountService:AccountserviceService,private toasterService:ToastrService) { 

    this.RegisterForm.controls.Password?.valueChanges.subscribe(() => {
       
       this.RegisterForm.controls.ConfirmPassword?.updateValueAndValidity();

    });

  }


  ngOnInit(): void {

  
  }

  Register():void
  {
    if(this.RegisterForm.valid)
    {
      this.accountService.Register(this.RegisterForm.value).subscribe((value)=>{
       
         console.log(value);

         this.toasterService.info("Registered Sucessfully");

      },error => {

        
        this.toasterService.error(error.error);
        
        
        
        
      });
      
    }
    else
    {
      this.toasterService.error("Data is Invalid");
    }

     
  }

  matchPassword(matchTo:string):ValidatorFn
  {
       
      

       return(control:AbstractControl): {[key: string]: any} | null=> {

        return control.value === (control?.parent?.controls as { [key: string]: AbstractControl })?.[matchTo]?.value ? null : { isMatching: true };

       }
  }


 

}
