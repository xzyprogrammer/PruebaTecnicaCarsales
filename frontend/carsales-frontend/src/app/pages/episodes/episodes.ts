import { Component, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EpisodesService } from '../../services/episodes.service';
import { Episode } from '../../models/episode.model';

@Component({
  selector: 'app-episodes-page',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './episodes.html',
  styleUrl: './episodes.css'
})
export class Episodes {
  private readonly episodesService = inject(EpisodesService);

  episodes = signal<Episode[]>([]);
  currentPage = signal(1);
  totalPages = signal(1);
  totalCount = signal(0);

  loading = signal(false);
  error = signal<string | null>(null);

  nameFilter = signal<string>('');

  selectedEpisode = signal<Episode | null>(null);
  loadingDetail = signal(false);
  detailError = signal<string | null>(null);

  constructor() {
    this.loadPage(1);
  }

  loadPage(page: number): void {
    if (page <= 0) return;
    if (this.totalPages() > 0 && page > this.totalPages()) return;

    this.loading.set(true);
    this.error.set(null);
    this.selectedEpisode.set(null);
    this.detailError.set(null);

    const filter = this.nameFilter().trim() || undefined;

    this.episodesService.getEpisodes(page, filter).subscribe({
      next: (response) => {
        this.episodes.set(response.items);
        this.currentPage.set(response.currentPage);
        this.totalPages.set(response.totalPages);
        this.totalCount.set(response.totalCount);
        this.loading.set(false);
      },
      error: (err) => {
        console.error(err);
        this.error.set('No se pudieron cargar los episodios.');
        this.loading.set(false);
      }
    });
  }
  applyFilter(): void {
    this.loadPage(1);
  }

  clearFilter(): void {
    this.nameFilter.set('');
    this.loadPage(1);
  }

  prevPage(): void {
    const page = this.currentPage();
    if (page > 1) {
      this.loadPage(page - 1);
    }
  }

  nextPage(): void {
    const page = this.currentPage();
    if (page < this.totalPages()) {
      this.loadPage(page + 1);
    }
  }

  // Cargar detalle desde el backend
  openEpisodeDetail(episode: Episode): void {
    this.selectedEpisode.set(null);
    this.detailError.set(null);
    this.loadingDetail.set(true);

    this.episodesService.getEpisodeById(episode.id).subscribe({
      next: (ep) => {
        this.selectedEpisode.set(ep);
        this.loadingDetail.set(false);
      },
      error: (err) => {
        console.error(err);
        this.detailError.set('No se pudo cargar el detalle del episodio.');
        this.loadingDetail.set(false);
      }
    });
  }

  closeDetail(): void {
    this.selectedEpisode.set(null);
    this.detailError.set(null);
  }
}
