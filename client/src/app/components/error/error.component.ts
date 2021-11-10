import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.css']
})
export class ErrorComponent implements OnInit {

  url:String="http://localhost:54413/api/";
  validationErrors:String[]=[];
  constructor(private http:HttpClient) { }

  ngOnInit(): void {
  }

  get404Error():void
  {
     this.http.get(this.url +'buggy/not-found').subscribe(response => {
       
      console.log(response);

     },error =>{
       console.log(error);
     })
  }

  get400Error(){


    this.http.get(this.url + 'buggy/bad-request').subscribe(response =>{
      console.log(response);
    },error => {
      console.log(error);
    })
  }

  get500Error(){
      
    this.http.get(this.url + 'buggy/server-error').subscribe(response => {
      console.log(response);
    },error => {
      console.log(error);
    })

  }

  get401Error(){
    this.http.get(this.url+'buggy/not-found').subscribe(response =>{
      console.log(response);
    },error =>{
      console.log(error);
    })
  }

  get400ValidationError(){
    this.http.post(this.url + 'account/register' , {}).subscribe(response =>{

      console.log(response);
    },error => {
      console.log(error);
      this.validationErrors=error;
    
    })
  }



}
