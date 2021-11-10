import { Component, OnInit ,Input, Output,EventEmitter} from '@angular/core';
import { GrantprgmserviceService } from 'src/app/services/grantprgmservice.service';
import { ToastrService } from 'ngx-toastr';

import { GrantModel } from 'src/app/models/grant-model';

@Component({
  selector: 'app-admindeletegrantprogram',
  templateUrl: './admindeletegrantprogram.component.html',
  styleUrls: ['./admindeletegrantprogram.component.css']
})
export class AdmindeletegrantprogramComponent implements OnInit {

  @Input() program:any;
  @Output() deleteProgram:EventEmitter<GrantModel>=new EventEmitter();
  @Output() updateProgram:EventEmitter<GrantModel>=new EventEmitter();
  notValidDate:boolean=false;
  error={isError:false,errorMessage:''};
 
  validationError={isValidprogramCode:false,isValidprogramName:false}

  constructor(private grantService:GrantprgmserviceService,private toastService:ToastrService) { }

  ngOnInit(): void {
  }
   
  deleteGrant(deleteProgram:any)
  {
 
    
    this.deleteProgram.emit(deleteProgram);
  }


  updateGrant(updateProgram:any)
  {
       let validationSuccess=this.validateUpdatedGrant(updateProgram);
       if(validationSuccess)
       {
        this.updateProgram.emit(updateProgram);
       }
      else
      {
        this.toastService.error("Please recheck the entered datas");
      }
       
  }

  validateUpdatedGrant(updateProgram:any)
  { 
    
       let dataValidated=this.validateDates(updateProgram.startDate,updateProgram.endDate,updateProgram.programName,updateProgram.programCode);
       
      return dataValidated;
  }

  validateDates(sDate: string, eDate: string,programName:string,programCode:string){
   
    this.notValidDate = true;
    this.error={isError:false,errorMessage:''};
    this.validationError={isValidprogramCode:false,isValidprogramName:false}
    if(programName === "")
    {
      this.validationError.isValidprogramName=true;
      this.notValidDate = false;
    }

    if(programCode === "")
    {
      this.validationError.isValidprogramName=true;
      this.notValidDate = false;
    }
     

    if((sDate == null || eDate ==null)){
      this.error={isError:true,errorMessage:'Start date and end date are required.'};
      this.notValidDate = false;
    }

    if((sDate != null && eDate !=null) && (eDate) < (sDate)){
      this.error={isError:true,errorMessage:'End date should be greater then start date.'};
      this.notValidDate = false;
    }
    return this.notValidDate;
  }


}
