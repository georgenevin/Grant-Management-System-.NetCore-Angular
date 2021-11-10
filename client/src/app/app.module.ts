import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SigninComponent } from './components/signin/signin.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { JwtModule } from "@auth0/angular-jwt";
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import {ActivatedRouteSnapshot} from '@angular/router';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RegisterComponent } from './components/register/register.component';
import { ApplicationComponent } from './components/application/application.component';
import { HomeComponent } from './components/home/home.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { ErrorComponent } from './components/error/error.component';
import { ErrorsInterceptor } from './interceptors/errors.interceptor';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { ServererrorComponent } from './components/servererror/servererror.component';
import { AuthGuard } from './_guards/auth.guard';
import {AdminhomeComponent} from './components/adminhome/adminhome.component';
import { AdmingrantprogramComponent } from './components/admingrantprogram/admingrantprogram.component';
import { AdminaddgrantprogramComponent } from './components/adminaddgrantprogram/adminaddgrantprogram.component';
import { AdmindeletegrantprogramComponent } from './components/admindeletegrantprogram/admindeletegrantprogram.component'
import {JwtInterceptorInterceptor} from './interceptors/jwt-interceptor.interceptor';
import { ApplicationapplicantdetailsComponent } from './components/applicationapplicantdetails/applicationapplicantdetails.component';
import { ApplicationcontactdetailsComponent } from './components/applicationcontactdetails/applicationcontactdetails.component';
import { AgGridModule } from 'ag-grid-angular';
import {NgxPaginationModule} from 'ngx-pagination'; 


import { ApplicationeducationdetailsComponent } from './components/applicationeducationdetails/applicationeducationdetails.component';
import { AdminreviewprogramComponent } from './components/adminreviewprogram/adminreviewprogram.component';
import { ApplicantionappliedprogramsComponent } from './components/applicantionappliedprograms/applicantionappliedprograms.component';



export function tokenGetter(){
  return localStorage.getItem("user");
}

@NgModule({
  declarations: [
    AppComponent,
    SigninComponent,
    RegisterComponent,
    ApplicationComponent,
    HomeComponent,
    NavigationComponent,
    ErrorComponent,
    NotFoundComponent,
    ServererrorComponent,
    AdminhomeComponent,
    AdmingrantprogramComponent,
    AdminaddgrantprogramComponent,
    AdmindeletegrantprogramComponent,
    ApplicationapplicantdetailsComponent,
    ApplicationcontactdetailsComponent,

    ApplicationeducationdetailsComponent,
     AdminreviewprogramComponent,
     ApplicantionappliedprogramsComponent,
   
    

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      positionClass:'toast-top-right'
    }),
    JwtModule.forRoot({
      config:{

        tokenGetter:tokenGetter,
      }

    }),
   
    AgGridModule.withComponents([]),
    NgxPaginationModule
    
  ],
  providers: [
    {
      provide:HTTP_INTERCEPTORS,useClass:ErrorsInterceptor,multi:true,
    
    },
    {
      provide:HTTP_INTERCEPTORS,useClass:JwtInterceptorInterceptor,multi:true
    },
    AuthGuard,

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
