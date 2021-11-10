import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import {GrantModel} from '../models/grant-model'
import { Observable } from 'rxjs';


const HttpOptions={
  headers:new HttpHeaders({
  
    'Content-Type':'application/json'
  })
  
  }
@Injectable({
  providedIn: 'root'
})
export class GrantprgmserviceService {

   url:string="http://localhost:54413/api/GrantProgram/"
  constructor(private http:HttpClient) { }


  addGrantProgram(program:GrantModel){
  
     console.log(program,"Add Grant");
     var grantPrograms=this.http.post(this.url+'SaveGrant',program,HttpOptions);
     return grantPrograms;

  }


  getAllGrantProgram():Observable<any[]>{
    
    var allProgram=this.http.get<any[]>(this.url + 'GetGrant');
    return allProgram;

  }

  deleteGrantProgram(grant:any):Observable<GrantModel>{
  
    var deletedGrant=this.http.delete<GrantModel>(this.url+ grant.grantId)
    return deletedGrant;
  }

  updateGrantProgram(grant:any):Observable<GrantModel>{
    var deletedGrant=this.http.put<GrantModel>(this.url+ grant.grantId,grant)
    return deletedGrant;
  }


  
}
