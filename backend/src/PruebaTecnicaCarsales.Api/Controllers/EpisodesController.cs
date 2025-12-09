using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaCarsales.Api.Application.Interfaces;
using PruebaTecnicaCarsales.Api.Domain.Models;

namespace PruebaTecnicaCarsales.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EpisodesController : ControllerBase
{
    private readonly IEpisodeService _episodeService;

    public EpisodesController(IEpisodeService episodeService)
    {
        _episodeService = episodeService;
    }

    [HttpGet]
    public async Task<ActionResult<PagedEpisodesDto>> GetEpisodes(
        [FromQuery] int page = 1,
        [FromQuery] string? name = null,
        CancellationToken cancellationToken = default)
    {
        if (page <= 0)
        {
            return BadRequest("El número de página debe ser mayor o igual a 1.");
        }

        var result = await _episodeService.GetEpisodesAsync(page, name, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<EpisodeDto>> GetEpisodeById(
        int id,
        CancellationToken cancellationToken = default)
    {
        var episode = await _episodeService.GetEpisodeByIdAsync(id, cancellationToken);

        if (episode == null)
        {
            return NotFound();
        }

        return Ok(episode);
    }



}
