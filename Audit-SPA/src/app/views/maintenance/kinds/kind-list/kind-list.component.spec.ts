/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { KindListComponent } from './kind-list.component';

describe('KindListComponent', () => {
  let component: KindListComponent;
  let fixture: ComponentFixture<KindListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KindListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KindListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
