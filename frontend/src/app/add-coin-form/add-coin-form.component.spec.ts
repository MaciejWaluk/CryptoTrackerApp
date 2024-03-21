import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCoinFormComponent } from './add-coin-form.component';

describe('AddCoinFormComponent', () => {
  let component: AddCoinFormComponent;
  let fixture: ComponentFixture<AddCoinFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddCoinFormComponent]
    });
    fixture = TestBed.createComponent(AddCoinFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
