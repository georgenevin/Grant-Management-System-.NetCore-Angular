import { Component, OnInit,EventEmitter,Output } from '@angular/core';
import {AccountserviceService} from '../../services/accountservice.service';
import { UserModel } from 'src/app/models/user-model';
import { GrantprgmserviceService } from 'src/app/services/grantprgmservice.service';
import { FormBuilder, FormGroup,FormControl, FormArray ,ReactiveFormsModule,Validators } from '@angular/forms';
import { ApplicantserviceService } from 'src/app/services/applicantservice.service';
import { ToastrService } from 'ngx-toastr';



@Component({
  selector: 'app-application',
  templateUrl: './application.component.html',
  styleUrls: ['./application.component.css']
})
export class ApplicationComponent implements OnInit {

  @Output() userLoggedOut:EventEmitter<UserModel> =new EventEmitter();
  userModel:UserModel={Email:"",UserType:"",Token:""};

  applicantForm!:FormGroup;
  tstModel=7;
  
  constructor(private accountservice:AccountserviceService,private grantService:GrantprgmserviceService,private fb:FormBuilder,
    private applicantSerive:ApplicantserviceService,private toaster:ToastrService ) { }

  ngOnInit(): void {
   
    this.applicantForm=this.fb.group({
    
     applicationDetail:this.fb.group({
      
      FirstName:[{disabled: true}],
      LastName :[{disabled: true}],
      Email:[{disabled: true}],
      DateofBirth:["",[Validators.required]],
      Country:["",[Validators.required]],
      State:["",[Validators.required]],
      PhysicallyDisabled:[false,[Validators.required]],
      GrantProgram:["",[Validators.required]],
      



     }),
     contactDetail:this.fb.group({
      Address:["",[Validators.required]],
      City:["",[Validators.required]],
      PostalCode:["",[Validators.required,Validators.pattern("^[0-9]*$")]],
      Mobile:["",[Validators.required,Validators.pattern("^[0-9]*$")]],
      Phone:["",[Validators.required,Validators.pattern("^[0-9]*$")]]

     }),

     educationDetail:this.fb.group({
      education: this.fb.array([  ]) 
     })


  })
  





   

  }

  



  submitForm()
  {
  
    var formData:any=this.applicantForm.value;
   
    formData.applicationDetail.PhysicallyDisabled ==="true" ? formData.applicationDetail.PhysicallyDisabled=true:formData.applicationDetail.PhysicallyDisabled=false;
    this.applicantSerive.submitFormData(this.applicantForm.value).subscribe(response =>
           this.toaster.info("Application Submitter")
      ,error=>{
        this.toaster.info(error.error);
        

      });
      
   
    console.log( JSON.stringify(this.applicantForm.value));
  }

  getApplicationDetailForm()
  {
    return this.applicantForm?.get('applicationDetail') as FormGroup;
  }

 

}
