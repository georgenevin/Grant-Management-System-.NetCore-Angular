import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationeducationdetailsComponent } from './applicationeducationdetails.component';

describe('ApplicationeducationdetailsComponent', () => {
  let component: ApplicationeducationdetailsComponent;
  let fixture: ComponentFixture<ApplicationeducationdetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApplicationeducationdetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplicationeducationdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
