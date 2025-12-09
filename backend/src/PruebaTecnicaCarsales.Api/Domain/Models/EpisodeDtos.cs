namespace PruebaTecnicaCarsales.Api.Domain.Models;

public class EpisodeDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string AirDate { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty; 
    public int CharactersCount { get; set; }
}

public class PagedEpisodesDto
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
    public IEnumerable<EpisodeDto> Items { get; set; } = Enumerable.Empty<EpisodeDto>();
}
