namespace PruebaTecnicaCarsales.Api.Domain.Models;

public class RickAndMortyEpisodeResponse
{
    public Info Info { get; set; } = default!;
    public List<RickAndMortyEpisode> Results { get; set; } = new();
}

public class Info
{
    public int Count { get; set; }
    public int Pages { get; set; }
    public string? Next { get; set; }
    public string? Prev { get; set; }
}

public class RickAndMortyEpisode
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Air_Date { get; set; } = string.Empty;
    public string Episode { get; set; } = string.Empty;
    public List<string> Characters { get; set; } = new();
}
