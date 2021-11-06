import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Impacto360Component } from './impacto360.component';

describe('Impacto360Component', () => {
  let component: Impacto360Component;
  let fixture: ComponentFixture<Impacto360Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Impacto360Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Impacto360Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
