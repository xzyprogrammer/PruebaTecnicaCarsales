import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PagedEpisodes, Episode } from '../models/episode.model';
import { environment } from '../../enviroments/enviroment';

@Injectable({
  providedIn: 'root'
})
export class EpisodesService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = environment.apiBaseUrl;

  getEpisodes(page: number = 1, name?: string): Observable<PagedEpisodes> {
    let params = new HttpParams().set('page', page.toString());

    if (name && name.trim().length > 0) {
      params = params.set('name', name.trim());
    }

    return this.http.get<PagedEpisodes>(`${this.baseUrl}/episodes`, { params });
  }

  getEpisodeById(id: number): Observable<Episode> {
    return this.http.get<Episode>(`${this.baseUrl}/episodes/${id}`);
  }
}

