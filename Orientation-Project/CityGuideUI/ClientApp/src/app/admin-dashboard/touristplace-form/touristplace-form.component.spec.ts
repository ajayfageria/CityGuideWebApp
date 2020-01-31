import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TouristplaceFormComponent } from './touristplace-form.component';

describe('TouristplaceFormComponent', () => {
  let component: TouristplaceFormComponent;
  let fixture: ComponentFixture<TouristplaceFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TouristplaceFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TouristplaceFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
