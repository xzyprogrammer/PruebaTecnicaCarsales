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

    public async Task<EpisodeDetailDto?> GetEpisodeByIdAsync(
    int id,
    CancellationToken cancellationToken = default)
    {
        var episode = await _rickAndMortyClient.GetEpisodeByIdAsync(id, cancellationToken);
        if (episode == null) return null;

        var characterIds = episode.Characters
            .Select(TryGetIdFromUrl)
            .Where(id => id.HasValue)
            .Select(id => id!.Value)
            .Take(10) 
            .ToList();

        var characters = await _rickAndMortyClient
            .GetCharactersByIdsAsync(characterIds, cancellationToken);

        return new EpisodeDetailDto
        {
            Id = episode.Id,
            Name = episode.Name,
            AirDate = episode.Air_Date,
            Code = episode.Episode,
            CharactersCount = episode.Characters?.Count ?? 0,
            Characters = characters.Select(c => new CharacterDto
            {
                Id = c.Id,
                Name = c.Name,
                Status = c.Status,
                Species = c.Species,
                Image = c.Image
            })
        };
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

    private static int? TryGetIdFromUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url)) return null;
        var last = url.TrimEnd('/').Split('/').LastOrDefault();
        return int.TryParse(last, out var id) ? id : null;
    }


}
