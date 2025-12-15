import { Component, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EpisodesService } from '../../services/episodes.service';
import { Episode, EpisodeDetail } from '../../models/episode.model';
import { EpisodeCardComponent } from '../../components/episode-card/episode-card';
import { EpisodeDetailModalComponent } from '../../components/episode-detail-modal/episode-detail-modal';
import { HeroBanner } from '../../components/hero-banner/hero-banner';

@Component({
  selector: 'app-episodes-page',
  standalone: true,
  imports: [CommonModule, HeroBanner, EpisodeCardComponent, EpisodeDetailModalComponent],
  templateUrl: './episodes.html',
  styleUrl: './episodes.css',
})
export class EpisodesPageComponent {
  private readonly episodesService = inject(EpisodesService);

  episodes = signal<Episode[]>([]);
  currentPage = signal(1);
  totalPages = signal(1);
  totalCount = signal(0);

  nameFilter = signal<string>('');

  loading = signal(false);
  error = signal<string | null>(null);

  selectedEpisode = signal<EpisodeDetail | null>(null);
  loadingDetail = signal(false);
  detailError = signal<string | null>(null);

  constructor() {
    this.loadPage(1);
  }

  loadPage(page: number): void {
    this.loading.set(true);
    this.error.set(null);
    this.selectedEpisode.set(null);

    const filter = this.nameFilter().trim() || undefined;

    this.episodesService.getEpisodes(page, filter).subscribe({
      next: (res) => {
        this.episodes.set(res.items);         
        this.currentPage.set(res.currentPage);
        this.totalPages.set(res.totalPages);
        this.totalCount.set(res.totalCount);
        this.loading.set(false);
      },
      error: () => {
        this.error.set('El episodio ingresado no se encuentra disponible.');
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
    if (this.currentPage() > 1) this.loadPage(this.currentPage() - 1);
  }

  nextPage(): void {
    if (this.currentPage() < this.totalPages()) this.loadPage(this.currentPage() + 1);
  }

  openDetail(ep: Episode): void {
    this.loadingDetail.set(true);
    this.detailError.set(null);
    this.selectedEpisode.set(null);

    this.episodesService.getEpisodeById(ep.id).subscribe({
      next: (detail) => {
        this.selectedEpisode.set(detail);     // <-- EpisodeDetail con characters
        this.loadingDetail.set(false);
      },
      error: () => {
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
