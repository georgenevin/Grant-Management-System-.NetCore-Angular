import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormGroupDirective } from '@angular/forms';
import {ApplicationDetailModel} from '../../models/applicationdetail-model';
import {GrantprgmserviceService} from '../../services/grantprgmservice.service'
import {ApplicantserviceService} from '../../services/applicantservice.service'
import { CurrentapplicantModel } from 'src/app/models/currentapplicant-model';
import { CountryModel } from 'src/app/models/country-model';
import { StateModel } from 'src/app/models/state-model';

@Component({
  selector: 'app-applicationapplicantdetails',
  templateUrl: './applicationapplicantdetails.component.html',
  styleUrls: ['./applicationapplicantdetails.component.css']
})
export class ApplicationapplicantdetailsComponent implements OnInit {
  @Input() applicationDetailForm!:FormGroup
  @Input() formGroupName!:string
  grantDropDown:any=[];
  currenUserDetails:CurrentapplicantModel={firstName:"",lastName:"",email:""};
  countries:CountryModel[]=[];
  states:StateModel[]=[];
  statesList:StateModel[]=[];
  constructor(private rootFormGroup:FormGroupDirective,private formBuilder:FormBuilder,private grantService:GrantprgmserviceService,private applicantService:ApplicantserviceService) { 

 

  }

  ngOnInit(): void {

   this.applicationDetailForm=this.rootFormGroup.control.get(this.formGroupName) as FormGroup;
   this.getAllGrant();
   this.getCurrentUser();
   this.getCountries();
   
 
     
  }


  getAllGrant()
  {

       this.grantService.getAllGrantProgram().subscribe(response =>{
        
        this.grantDropDown=response.filter(x=>x.status==true);
      

       })


  }

  get grantProgram() {
    return this.applicationDetailForm.get('GrandProgram');
  }

  get FirstName(){
    return this.applicationDetailForm.get('FirstName');
  }

  get LastName(){

    return this.applicationDetailForm.get('LastName');
  }

  get Email(){

    return this.applicationDetailForm.get('Email');
  }

  get State(){
    return this.applicationDetailForm.get('State') as FormControl;
  }

 

  onSelect(program:any)
  {
      this.grantProgram?.setValue(program,{onlySelf:true});
  }

  getCurrentUser()
  {

    this.applicantService.getUserBasicDetails().subscribe(response => {
      this.currenUserDetails=response;
      console.log(response);
      this.FirstName?.setValue(this.currenUserDetails.firstName,{onlySelf:true});
      this.LastName?.setValue(this.currenUserDetails.lastName,{onlySelf:true});
      this.Email?.setValue(this.currenUserDetails.email,{onlySelf:true});
    });
   
 
     


  }

  getCountries()
  {
    this.applicantService.getCountryList().subscribe(response =>{
      this.countries=response;
    
    });
  }

  onCountryChange(countryId:any)
  {
   // this.states=this.statesList.filter(x=>x.countryId==countryId);
   
   this.applicantService.getStates(countryId).subscribe(
    response =>{
      this.states=response;
    }

   );
   

  }

  onStateChange(event:any)
  {
  
    var stateId =event.target.value;
     this.State?.setValue(stateId,{emitEvent: false})
  }







}
