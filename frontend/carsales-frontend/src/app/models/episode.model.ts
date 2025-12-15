import { Character } from './character.model';

export interface Episode {
  id: number;
  name: string;
  airDate: string;
  code: string;
  charactersCount: number;
}

export interface EpisodeDetail extends Episode {
  characters: Character[];
}

export interface PagedEpisodes {
  currentPage: number;
  totalPages: number;
  totalCount: number;
  items: Episode[];
}


