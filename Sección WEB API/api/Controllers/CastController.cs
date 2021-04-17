using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.Extensions.Logging;
using System;
using api.Services;
using System.Collections.Generic;
using AutoMapper;
using api.Entities;

namespace api.Controllers
{
  [ApiController]
  [Route("api/movies/{movieId}/casts")]
  public class CastController : ControllerBase
  {
    private ILogger<CastController> _logger;
    private IMailService _localMailService;
    private IMovieInfoRepository _repository;
    private IMapper _mapper;

    public CastController(ILogger<CastController> logger, IMailService localMailService, IMovieInfoRepository repository,
    IMapper mapper)
    {
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));
      _localMailService = localMailService ?? throw new ArgumentNullException(nameof(logger));
      _repository = repository ?? throw new ArgumentNullException(nameof(repository));
      _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public IActionResult GetCasts(int movieId)
    {
      if (!_repository.MovieExists(movieId))
      {
        return NotFound();
      }

      var casts = _repository.GetCastsByMovie(movieId);

      return Ok(_mapper.Map<IEnumerable<CastDto>>(casts));
    }

    [HttpGet("{id}", Name = "GetCast")]
    public IActionResult GetCast(int movieId, int id)
    {
      try
      {
        if (!_repository.MovieExists(movieId))
        {
          return NotFound();
        }

        var cast = _repository.GetCastByMovie(movieId, id);

        if (cast == null)
        {
          _logger.LogInformation($"El cast con id {id} no fue encontrado");
          return NotFound();
        }

        return Ok(_mapper.Map<CastDto>(cast));
      }
      catch (System.Exception ex)
      {
        _logger.LogCritical($"Un error ocurrio al buscar el cast con id {id}", ex);
        return StatusCode(500, "Un problema ocurrio al realizar la solictud al recurso");
      }
    }

    [HttpPost]
    public IActionResult
    CreateCast(
        int movieId,
        [FromBody] CastForCreationDto castForCreationDto
    )
    {

      if (!_repository.MovieExists(movieId))
      {
        return NotFound();
      }

      var finalCast = _mapper.Map<Cast>(castForCreationDto);
      _repository.AddCastForMovie(movieId, finalCast);
      _repository.Save();

      var createdCastToReturn = _mapper.Map<CastForCreationDto>(finalCast);

      return CreatedAtRoute(nameof(GetCast),
      new { movieId, id = finalCast.Id },
      createdCastToReturn);
    }

    [HttpPut("{id}")]
    public IActionResult
    UpdateCast(
        int movieId,
        int id,
        [FromBody] CastForUpdateDto castForUpdate
    )
    {
      if (!_repository.MovieExists(movieId))
      {
        return NotFound();
      }

      var castFromStore = _repository.GetCastByMovie(movieId, id);

      if (castFromStore == null)
      {
        return NotFound();
      }

      _mapper.Map(castForUpdate, castFromStore);
      _repository.UpdateCastForMovie(movieId, castFromStore);
      _repository.Save();

      return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult
    PartialUpdateCast(
        int movieId,
        int id,
        [FromBody] JsonPatchDocument<CastForUpdateDto> patchDocument
    )
    {

      if (!_repository.MovieExists(movieId))
      {
        return NotFound();
      }

      var castFromStore = _repository.GetCastByMovie(movieId, id);

      if (castFromStore == null)
      {
        return NotFound();
      }

      var castToPatch = _mapper.Map<CastForUpdateDto>(castFromStore);

      patchDocument.ApplyTo(castToPatch, ModelState);

      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (!TryValidateModel(castToPatch))
      {
        return BadRequest(ModelState);
      }

      _mapper.Map(castToPatch, castFromStore);
      _repository.UpdateCastForMovie(movieId, castFromStore);
      _repository.Save();

      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCast(int movieId, int id)
    {

      if (!_repository.MovieExists(movieId))
      {
        return NotFound();
      }

      var castFromStore = _repository.GetCastByMovie(movieId, id);

      if (castFromStore == null)
      {
        return NotFound();
      }

      _localMailService.Send("Recurso eliminado", $"El recurco con id {id} fue eliminado");

      _repository.DeleteCast(castFromStore);
      _repository.Save();

      return NoContent();
    }
  }
}
