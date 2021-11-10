import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdmingrantprogramComponent } from './admingrantprogram.component';

describe('AdmingrantprogramComponent', () => {
  let component: AdmingrantprogramComponent;
  let fixture: ComponentFixture<AdmingrantprogramComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdmingrantprogramComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdmingrantprogramComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
