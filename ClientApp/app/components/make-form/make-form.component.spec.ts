import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MakeFormComponent } from './make-form.component';

describe('MakeFormComponent', () => {
  let component: MakeFormComponent;
  let fixture: ComponentFixture<MakeFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MakeFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MakeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
