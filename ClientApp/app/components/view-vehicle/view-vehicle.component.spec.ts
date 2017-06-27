import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewVehicleComponent } from './view-vehicle.component';

describe('ViewVehicleComponent', () => {
  let component: ViewVehicleComponent;
  let fixture: ComponentFixture<ViewVehicleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewVehicleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewVehicleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
