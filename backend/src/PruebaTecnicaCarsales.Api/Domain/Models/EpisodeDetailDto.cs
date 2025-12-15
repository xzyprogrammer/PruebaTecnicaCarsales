namespace PruebaTecnicaCarsales.Api.Domain.Models
{
    public class EpisodeDetailDto : EpisodeDto
    {
        public IEnumerable<CharacterDto> Characters { get; set; } = new List<CharacterDto>();
    }

}
