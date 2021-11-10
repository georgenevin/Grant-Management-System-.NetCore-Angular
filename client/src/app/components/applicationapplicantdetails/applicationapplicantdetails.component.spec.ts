import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationapplicantdetailsComponent } from './applicationapplicantdetails.component';

describe('ApplicationapplicantdetailsComponent', () => {
  let component: ApplicationapplicantdetailsComponent;
  let fixture: ComponentFixture<ApplicationapplicantdetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApplicationapplicantdetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplicationapplicantdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
