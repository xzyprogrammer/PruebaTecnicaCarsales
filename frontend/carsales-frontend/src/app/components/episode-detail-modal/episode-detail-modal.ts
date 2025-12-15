import { CommonModule } from '@angular/common';
import { Component, input, output } from '@angular/core';
import { CharacterGridComponent } from '../character-grid/character-grid';
import { EpisodeDetail } from '../../models/episode.model';

@Component({
  selector: 'app-episode-detail-modal',
  standalone: true,
  imports: [CommonModule, CharacterGridComponent],
  templateUrl: './episode-detail-modal.html',
  styleUrl: './episode-detail-modal.css'
})
export class EpisodeDetailModalComponent {
  episode = input<EpisodeDetail | null>();
  close = output<void>();
}
