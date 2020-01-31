import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchbarentityComponent } from './searchbarentity.component';

describe('SearchbarentityComponent', () => {
  let component: SearchbarentityComponent;
  let fixture: ComponentFixture<SearchbarentityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SearchbarentityComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchbarentityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
