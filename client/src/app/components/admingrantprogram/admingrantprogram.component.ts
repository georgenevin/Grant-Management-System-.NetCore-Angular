import { Component, OnInit } from '@angular/core';
import { GrantModel } from 'src/app/models/grant-model';
import { GrantprgmserviceService } from 'src/app/services/grantprgmservice.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-admingrantprogram',
  templateUrl: './admingrantprogram.component.html',
  styleUrls: ['./admingrantprogram.component.css']
})
export class AdmingrantprogramComponent implements OnInit {

  programsList:any=[];
  grant:any=null;
  p: number = 1;
  
  constructor(private grantService:GrantprgmserviceService,private toasterService:ToastrService) { }

  ngOnInit(): void {

    this.GetAllGrants();
  }

  AddGrant(program:GrantModel){
  
    var grandFlag= this.grantService.addGrantProgram(program).subscribe(
        response => {
          this.grant=response;
          console.log(response);
          this.toasterService.info("Grant added succesfully");
          this.GetAllGrants();
        }
      
      ,error => this.toasterService.error(error.error));
  
   
  }

  GetAllGrants(){

    this.grantService.getAllGrantProgram().subscribe(

        response =>{

          this.programsList=response;

        },error => this.toasterService.error(error.error ) )

  }


  deleteGrant(program:any){

    
    this.grantService.deleteGrantProgram(program).subscribe(response=>{

      if(response)
      {
       this.toasterService.info("Succesfully Deleted")
       this.GetAllGrants();
      }
      else
      {
        this.toasterService.error("Unsucessful")
      }

  },error =>
            
   this.toasterService.error(error.error)
  
  );


  }

  updateGrantPrgm(program:any)
  {
           
      this.grantService.updateGrantProgram(program).subscribe(response=>{

           if(response)
           {
            this.toasterService.info("Succesfully Updated");
            this.GetAllGrants();
           }
           else
           {
            this.toasterService.error("Unsucessful");
           }


      },
      
      error=> this.toasterService.error(error)
    
      );
    }
      
              
  }


