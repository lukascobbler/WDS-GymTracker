import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginRegisterScreenComponent } from './login-register-screen.component';

describe('LoginRegisterScreenComponent', () => {
  let component: LoginRegisterScreenComponent;
  let fixture: ComponentFixture<LoginRegisterScreenComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LoginRegisterScreenComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoginRegisterScreenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
