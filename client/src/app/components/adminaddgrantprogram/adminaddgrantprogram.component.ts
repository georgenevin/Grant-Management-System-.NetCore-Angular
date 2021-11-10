import { Component, OnInit,Input, Output,EventEmitter  } from '@angular/core';
import { GrantModel } from 'src/app/models/grant-model';


@Component({
  selector: 'app-adminaddgrantprogram',
  templateUrl: './adminaddgrantprogram.component.html',
  styleUrls: ['./adminaddgrantprogram.component.css']
})
export class AdminaddgrantprogramComponent implements OnInit {

  grantProgram:GrantModel={GrantId:0,ProgramName:"",ProgramCode:"",StartDate:"",EndDate:"",Status:false};
  notValidDate:any;
  error:any={isError:false,errorMessage:''};
  @Input() program:any;
  @Output() addProgramEvent:EventEmitter<GrantModel>=new EventEmitter();
  

  constructor() { 


  }

  ngOnInit(): void {

  }

  onSubmit(event: Event):void{

  
    this.notValidDate=this.validateDates(this.grantProgram.StartDate,this.grantProgram.EndDate);
 
    if(this.notValidDate)
    {
    
      this.addProgramEvent.emit(this.grantProgram);
      this.grantProgram={GrantId:0,ProgramName:"",ProgramCode:"",StartDate:"",EndDate:"",Status:false};
     
    }
    else
    {
      event.stopPropagation();
    }
   
  }


  validateDates(sDate: string, eDate: string){
    this.notValidDate = true;
    this.error={isError:false,errorMessage:''};
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
