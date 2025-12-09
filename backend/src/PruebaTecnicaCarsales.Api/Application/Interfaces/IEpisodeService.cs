using PruebaTecnicaCarsales.Api.Domain.Models;

namespace PruebaTecnicaCarsales.Api.Application.Interfaces;

public interface IEpisodeService
{
    Task<PagedEpisodesDto> GetEpisodesAsync(
        int page,
        string? nameFilter = null,
        CancellationToken cancellationToken = default);

    Task<EpisodeDto?> GetEpisodeByIdAsync(
        int id,
        CancellationToken cancellationToken = default);
}
