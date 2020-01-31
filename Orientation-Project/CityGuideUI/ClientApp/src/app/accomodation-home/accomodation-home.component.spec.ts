import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccomodationHomeComponent } from './accomodation-home.component';

describe('AccomodationHomeComponent', () => {
  let component: AccomodationHomeComponent;
  let fixture: ComponentFixture<AccomodationHomeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccomodationHomeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccomodationHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
