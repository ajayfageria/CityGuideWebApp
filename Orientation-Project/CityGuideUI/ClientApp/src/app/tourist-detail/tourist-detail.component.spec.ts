import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TouristDetailComponent } from './tourist-detail.component';

describe('TouristDetailComponent', () => {
  let component: TouristDetailComponent;
  let fixture: ComponentFixture<TouristDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TouristDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TouristDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
