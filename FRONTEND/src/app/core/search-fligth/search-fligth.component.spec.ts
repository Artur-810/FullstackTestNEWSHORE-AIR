import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchFligthComponent } from './search-fligth.component';

describe('SearchFligthComponent', () => {
  let component: SearchFligthComponent;
  let fixture: ComponentFixture<SearchFligthComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchFligthComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchFligthComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
