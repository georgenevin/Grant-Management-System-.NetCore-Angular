import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicantionappliedprogramsComponent } from './applicantionappliedprograms.component';

describe('ApplicantionappliedprogramsComponent', () => {
  let component: ApplicantionappliedprogramsComponent;
  let fixture: ComponentFixture<ApplicantionappliedprogramsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApplicantionappliedprogramsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplicantionappliedprogramsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
