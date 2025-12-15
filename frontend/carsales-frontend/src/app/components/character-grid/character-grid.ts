import { Component, input } from '@angular/core';
import { Character } from '../../models/character.model';

@Component({
  selector: 'app-character-grid',
  standalone: true,
  templateUrl: './character-grid.html',
  styleUrl: './character-grid.css'
})
export class CharacterGridComponent {
  characters = input.required<Character[]>();
}
