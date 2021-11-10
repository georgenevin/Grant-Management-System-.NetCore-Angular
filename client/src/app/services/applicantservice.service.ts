import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {AccountserviceService } from '../services/accountservice.service'
import { Observable } from 'rxjs';
import {CurrentapplicantModel} from '../models/currentapplicant-model'
import {CountryModel} from '../models/country-model'
import { StateModel } from '../models/state-model';

@Injectable({
  providedIn: 'root'
})
export class ApplicantserviceService {

  url="http://localhost:54413/api/Applicant/"
  constructor(private http:HttpClient,private accountService:AccountserviceService) { }

  getUserBasicDetails():Observable<CurrentapplicantModel>
  {
      var user=this.accountService.userValue();
      var userEmail=user.Email;
     var curretUser= this.http.get<CurrentapplicantModel>(this.url+userEmail);
     return curretUser;
  }

  getCountryList():Observable<CountryModel[]>
  {
    var counties=this.http.get<CountryModel[]>(this.url+'Country');
    return counties;
  }

  getStates(countryId:any):Observable<StateModel[]>{
    var states =this.http.get<StateModel[]>(this.url+'State'+countryId);
    return states;
  }

  submitFormData(formData:any){
   
    var result= this.http.post(this.url+'AddApplicant',formData);
    return result;

  }




}
