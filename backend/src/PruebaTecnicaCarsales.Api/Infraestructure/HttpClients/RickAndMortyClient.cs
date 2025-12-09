using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using PruebaTecnicaCarsales.Api.Application.Interfaces;
using PruebaTecnicaCarsales.Api.Domain.Models;

namespace PruebaTecnicaCarsales.Api.Infrastructure.HttpClients;

public class RickAndMortyClient : IRickAndMortyClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public RickAndMortyClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;

        var baseUrl = _configuration["RickAndMortyApi:BaseUrl"];
        if (!string.IsNullOrWhiteSpace(baseUrl))
        {
            _httpClient.BaseAddress = new Uri(baseUrl);
        }
    }

    public async Task<RickAndMortyEpisodeResponse?> GetEpisodesAsync(
        int page,
        string? name = null,
        CancellationToken cancellationToken = default)
    {
        var endpoint = _configuration["RickAndMortyApi:EpisodesEndpoint"] ?? "episode";

        var query = new List<string> { $"page={page}" };
        if (!string.IsNullOrWhiteSpace(name))
        {
            query.Add($"name={Uri.EscapeDataString(name)}");
        }

        var queryString = string.Join("&", query);
        var fullUrl = $"{endpoint}?{queryString}";

        var response = await _httpClient.GetAsync(fullUrl, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error calling Rick and Morty API: {response.StatusCode}");
        }

        return await response.Content.ReadFromJsonAsync<RickAndMortyEpisodeResponse>(cancellationToken: cancellationToken);
    }

    public async Task<RickAndMortyEpisode?> GetEpisodeByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        var endpoint = _configuration["RickAndMortyApi:EpisodesEndpoint"] ?? "episode";
        var fullUrl = $"{endpoint}/{id}";

        var response = await _httpClient.GetAsync(fullUrl, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

            throw new HttpRequestException($"Error calling Rick and Morty API: {response.StatusCode}");
        }

        return await response.Content.ReadFromJsonAsync<RickAndMortyEpisode>(cancellationToken: cancellationToken);
    }

}
