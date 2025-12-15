import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EpisodeCardComponent } from './episode-card';

describe('EpisodeCard', () => {
  let component: EpisodeCardComponent;
  let fixture: ComponentFixture<EpisodeCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EpisodeCardComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EpisodeCardComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
