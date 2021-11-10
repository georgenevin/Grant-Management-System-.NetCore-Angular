import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminaddgrantprogramComponent } from './adminaddgrantprogram.component';

describe('AdminaddgrantprogramComponent', () => {
  let component: AdminaddgrantprogramComponent;
  let fixture: ComponentFixture<AdminaddgrantprogramComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminaddgrantprogramComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminaddgrantprogramComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
