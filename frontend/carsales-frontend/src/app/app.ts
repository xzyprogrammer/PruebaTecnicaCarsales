import { Component, signal } from '@angular/core';
import { EpisodesPageComponent } from './pages/episodes/episodes';

@Component({
  selector: 'app-root',
  imports: [EpisodesPageComponent],
  standalone: true,
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('carsales-frontend');
}
