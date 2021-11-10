import { Component } from '@angular/core';
import { UiserviceService } from '../app/services/uiservice.service';
import { Subscription } from 'rxjs';
import {UserModel } from '../app/models/user-model';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Gant Management System';
 

}
