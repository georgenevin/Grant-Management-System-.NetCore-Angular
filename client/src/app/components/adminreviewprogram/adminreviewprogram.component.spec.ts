import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminreviewprogramComponent } from './adminreviewprogram.component';

describe('AdminreviewprogramComponent', () => {
  let component: AdminreviewprogramComponent;
  let fixture: ComponentFixture<AdminreviewprogramComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminreviewprogramComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminreviewprogramComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
