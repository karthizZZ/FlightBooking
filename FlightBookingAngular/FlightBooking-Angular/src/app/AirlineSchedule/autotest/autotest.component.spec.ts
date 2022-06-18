import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AutotestComponent } from './autotest.component';

describe('AutotestComponent', () => {
  let component: AutotestComponent;
  let fixture: ComponentFixture<AutotestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AutotestComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AutotestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
