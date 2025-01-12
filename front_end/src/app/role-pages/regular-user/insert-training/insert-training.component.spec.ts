import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsertTrainingComponent } from './insert-training.component';

describe('InsertTrainingComponent', () => {
  let component: InsertTrainingComponent;
  let fixture: ComponentFixture<InsertTrainingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InsertTrainingComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InsertTrainingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
