import { Component, OnInit ,Input} from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormGroupDirective } from '@angular/forms';

@Component({
  selector: 'app-applicationcontactdetails',
  templateUrl: './applicationcontactdetails.component.html',
  styleUrls: ['./applicationcontactdetails.component.css']
})
export class ApplicationcontactdetailsComponent implements OnInit {


  @Input() formGroupName!:string
  @Input() contactDetail!:FormGroup

  constructor(private rootFormGroup:FormGroupDirective) { }

  ngOnInit(): void {

    this.contactDetail=this.rootFormGroup.control.get(this.formGroupName) as FormGroup;

  }

}
