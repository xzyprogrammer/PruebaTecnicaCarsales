import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EpisodeDetailModalComponent } from './episode-detail-modal';

describe('EpisodeDetailModal', () => {
  let component: EpisodeDetailModalComponent;
  let fixture: ComponentFixture<EpisodeDetailModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EpisodeDetailModalComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EpisodeDetailModalComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
