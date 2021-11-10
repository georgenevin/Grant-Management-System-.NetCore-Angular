import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, FormGroupDirective,Validators } from '@angular/forms';
import { AgGridModule } from 'ag-grid-angular';


@Component({
  selector: 'app-applicationeducationdetails',
  templateUrl: './applicationeducationdetails.component.html',
  styleUrls: ['./applicationeducationdetails.component.css']
})
export class ApplicationeducationdetailsComponent implements OnInit {

  @Input() educationDetail!:FormGroup
  @Input() formGroupName!:string




 
  constructor(private rootFormGroup:FormGroupDirective,private fb:FormBuilder) { }

  ngOnInit(): void {
    
    this.educationDetail=this.rootFormGroup.control.get(this.formGroupName) as FormGroup;
    this.addNewRow();
    console.log(this.tableRowArray.controls[0].get('courseName'));


  }

  


private createTableRow(): FormGroup {  
  return this.fb.group({  
     
    courseName:["",Validators.required],
    country:["",Validators.required],
    institutionName:["",Validators.required],
    yearofCompleting:["",[Validators.required,Validators.pattern("^[0-9]*$")]]

  });  
}

get tableRowArray(): FormArray {  
  return this.educationDetail.get('education') as FormArray;  
}

addNewRow(): void {  
  this.tableRowArray.push(this.createTableRow());  
}  

onDeleteRow(rowIndex:any): void {  
  rowIndex=rowIndex.target.value;
  this.tableRowArray.removeAt(rowIndex);  
} 


onUpdate(data:any,index:any){

  
 var currentData= this.tableRowArray?.at(index);
 currentData=data;
 
}



 



}
