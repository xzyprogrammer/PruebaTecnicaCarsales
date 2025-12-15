using PruebaTecnicaCarsales.Api.Domain.Models;

namespace PruebaTecnicaCarsales.Api.Application.Interfaces;

public interface IRickAndMortyClient
{
    Task<RickAndMortyEpisodeResponse?> GetEpisodesAsync(
        int page,
        string? name = null,
        CancellationToken cancellationToken = default);

    Task<RickAndMortyEpisode?> GetEpisodeByIdAsync(
        int id,
        CancellationToken cancellationToken = default);

    Task<RickAndMortyCharacter?> GetCharacterByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<List<RickAndMortyCharacter>> GetCharactersByIdsAsync(IEnumerable<int> ids, CancellationToken cancellationToken = default);

}