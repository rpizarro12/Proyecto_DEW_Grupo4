import { ComponentFixture, TestBed } from '@angular/core/testing';

import { QueofrecemosComponent } from './queofrecemos.component';

describe('QueofrecemosComponent', () => {
  let component: QueofrecemosComponent;
  let fixture: ComponentFixture<QueofrecemosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ QueofrecemosComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(QueofrecemosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
