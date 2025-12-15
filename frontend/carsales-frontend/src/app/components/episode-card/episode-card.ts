import { Component, input, output } from '@angular/core';
import { Episode } from '../../models/episode.model';

@Component({
  selector: 'app-episode-card',
  standalone: true,
  templateUrl: './episode-card.html',
  styleUrl: './episode-card.css'
})
export class EpisodeCardComponent {
  episode = input.required<Episode>();
  select = output<Episode>();

  open() {
    this.select.emit(this.episode());
  }
}

