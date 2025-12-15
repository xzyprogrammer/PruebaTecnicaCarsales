import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CharacterGridComponent } from './character-grid';

describe('CharacterGrid', () => {
  let component: CharacterGridComponent;
  let fixture: ComponentFixture<CharacterGridComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CharacterGridComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CharacterGridComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
