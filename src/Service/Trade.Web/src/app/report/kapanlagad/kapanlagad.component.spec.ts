import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KapanlagadComponent } from './kapanlagad.component';

describe('KapanlagadComponent', () => {
  let component: KapanlagadComponent;
  let fixture: ComponentFixture<KapanlagadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KapanlagadComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(KapanlagadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
