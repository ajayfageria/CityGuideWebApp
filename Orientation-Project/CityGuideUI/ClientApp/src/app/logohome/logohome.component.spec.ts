import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LogohomeComponent } from './logohome.component';

describe('LogohomeComponent', () => {
  let component: LogohomeComponent;
  let fixture: ComponentFixture<LogohomeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LogohomeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LogohomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
