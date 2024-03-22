import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CoinFormComponent } from './coin-form.component';

describe('CoinFormComponent', () => {
  let component: CoinFormComponent;
  let fixture: ComponentFixture<CoinFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CoinFormComponent]
    });
    fixture = TestBed.createComponent(CoinFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
