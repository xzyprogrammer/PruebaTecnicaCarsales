using Microsoft.Extensions.Configuration;
using PruebaTecnicaCarsales.Api.Application.Interfaces;
using PruebaTecnicaCarsales.Api.Domain.Models;

namespace PruebaTecnicaCarsales.Api.Application.Services;

public class EpisodeService : IEpisodeService
{
    private readonly IRickAndMortyClient _rickAndMortyClient;
    private readonly IConfiguration _configuration;

    public EpisodeService(IRickAndMortyClient rickAndMortyClient, IConfiguration configuration)
    {
        _rickAndMortyClient = rickAndMortyClient;
        _configuration = configuration;
    }

    public async Task<PagedEpisodesDto> GetEpisodesAsync(
        int page,
        string? nameFilter = null,
        CancellationToken cancellationToken = default)
    {
        if (page <= 0)
        {
            page = int.Parse(_configuration["Pagination:DefaultPage"] ?? "1");
        }

        var apiResponse = await _rickAndMortyClient.GetEpisodesAsync(page, nameFilter, cancellationToken);

        if (apiResponse == null)
        {
            throw new InvalidOperationException("No se recibió respuesta válida desde Rick & Morty API");
        }

        var episodes = apiResponse.Results.Select(e => MapToEpisodeDto(e));

        return new PagedEpisodesDto
        {
            CurrentPage = page,
            TotalPages = apiResponse.Info.Pages,
            TotalCount = apiResponse.Info.Count,
            Items = episodes
        };
    }

    public async Task<EpisodeDto?> GetEpisodeByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        var episode = await _rickAndMortyClient.GetEpisodeByIdAsync(id, cancellationToken);

        if (episode == null)
        {
            return null;
        }

        return MapToEpisodeDto(episode);
    }

    private static EpisodeDto MapToEpisodeDto(RickAndMortyEpisode e)
    {
        return new EpisodeDto
        {
            Id = e.Id,
            Name = e.Name,
            AirDate = e.Air_Date,
            Code = e.Episode,
            CharactersCount = e.Characters?.Count ?? 0
        };
    }

}
