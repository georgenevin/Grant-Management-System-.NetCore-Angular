import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationcontactdetailsComponent } from './applicationcontactdetails.component';

describe('ApplicationcontactdetailsComponent', () => {
  let component: ApplicationcontactdetailsComponent;
  let fixture: ComponentFixture<ApplicationcontactdetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApplicationcontactdetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplicationcontactdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
