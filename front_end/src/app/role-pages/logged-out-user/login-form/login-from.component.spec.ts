import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginFomrComponent } from './login-form.component';

describe('LoginComponent', () => {
  let component: LoginFomrComponent;
  let fixture: ComponentFixture<LoginFomrComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LoginFomrComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoginFomrComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
