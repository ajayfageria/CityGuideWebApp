import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BlogsFormComponent } from './blogs-form.component';

describe('BlogsFormComponent', () => {
  let component: BlogsFormComponent;
  let fixture: ComponentFixture<BlogsFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BlogsFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BlogsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
