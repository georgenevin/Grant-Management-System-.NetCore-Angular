import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdmindeletegrantprogramComponent } from './admindeletegrantprogram.component';

describe('AdmindeletegrantprogramComponent', () => {
  let component: AdmindeletegrantprogramComponent;
  let fixture: ComponentFixture<AdmindeletegrantprogramComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdmindeletegrantprogramComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdmindeletegrantprogramComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
