import { Component, signal } from '@angular/core';
import { Episodes } from './pages/episodes/episodes';

@Component({
  selector: 'app-root',
  imports: [Episodes],
  standalone: true,
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('carsales-frontend');
}
