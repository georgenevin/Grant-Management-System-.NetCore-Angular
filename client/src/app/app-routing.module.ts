import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {RegisterComponent} from '../app/components/register/register.component'
import {SigninComponent} from '../app/components/signin/signin.component'
import { HomeComponent } from './components/home/home.component';
import{ApplicationComponent} from './components/application/application.component'
import {AuthGuard} from 'src/app/_guards/auth.guard'
import { ErrorComponent } from './components/error/error.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { ServererrorComponent } from './components/servererror/servererror.component';
import { AdminhomeComponent } from './components/adminhome/adminhome.component';
import { ApplicantionappliedprogramsComponent } from './components/applicantionappliedprograms/applicantionappliedprograms.component';


const routes: Routes = [
 {path:'',component:HomeComponent},
 {path:'SignUp',component:RegisterComponent},
 {path:'Application',component:ApplicationComponent,canActivate:[AuthGuard],data:{

      role:['applicants']
 }},
 {path:'Application/appliedprograms',component:ApplicantionappliedprogramsComponent,canActivate:[AuthGuard],data:{

  role:['applicants']
}},
 {path:'Error',component:ErrorComponent},
 {path:'not-found',component:NotFoundComponent},
 {path:'server-error',component:ServererrorComponent},
 {path:'admin-home',component:AdminhomeComponent,canActivate:[AuthGuard],data:{
  role:['admin']
 }},
 {path:'**',component:ServererrorComponent}


 

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
