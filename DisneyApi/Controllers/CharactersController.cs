using AutoMapper;
using DisneyApi.Application.Services;
using DisneyApi.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DisneyApi.Presentation.Controllers
{
    [ApiController]
    [Route("characters")]
    public class CharactersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPersonajesService _service;
        public CharactersController(IPersonajesService service, IMapper mapper)
        {
            this._mapper = mapper;
            this._service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PersonajeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetAllCharacters(string name = null, int? age = null, int? idMovie = null, int? weight = null)
        {
            try
            {
                if(name != null && age == null && idMovie == null && weight == null)
                {
                    var personaje = _service.GetCharacterByName(name);
                    var personajeMapeado = _mapper.Map<PersonajeDto>(personaje);

                    return Ok(personajeMapeado);
                }

                else if (name == null && age != null && idMovie == null && weight == null)
                {
                    var personajes = _service.GetCharactersByAge(age.Value);
                    var personajesMapeados = _mapper.Map<List<PersonajeDto>>(personajes);

                    return Ok(personajesMapeados);
                }

                else if(name == null && age == null && idMovie == null && weight != null)
                {
                    var personajes = _service.GetCharactersByWeight(weight.Value);
                    var personajesMapeados = _mapper.Map<List<PersonajeDto>>(personajes);

                    return Ok(personajesMapeados);
                }

                else
                {
                    var personaje = _service.GetAllCharacters();
                    var personajesMapeados = _mapper.Map<List<PersonajeDto>>(personaje);

                    return Ok(personajesMapeados);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(PersonajeDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult CreateCharacter([FromBody] PersonajeDtoForCreationOrUpdate personaje)
        {
            try
            {
                var personajeEntity = _service.CreatePersonaje(personaje);

                if (personajeEntity != null)
                {
                    var personajeCreado = _mapper.Map<PersonajeDto>(personajeEntity);
                    return Created("~characters/", personajeCreado);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteCharacter(int id)
        {
            try
            {
                var character = _service.GetCharacterById(id);

                if (character == null)
                {
                    return NotFound();
                }

                _service.Delete(character);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult UpdateCharacter(int id, [FromBody] PersonajeDtoForCreationOrUpdate personaje)
        {
            try
            {
                if (personaje == null)
                {
                    return BadRequest("Todos los campos deben estar completos para poder realizar la actualización de este elemento.");
                }

                var personajeEntity = _service.GetCharacterById(id);

                if (personajeEntity == null)
                {
                    return NotFound();
                }

                _mapper.Map(personaje, personajeEntity);
                _service.Update(personajeEntity);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet]
        [Route("{id}/details")]
        [ProducesResponseType(typeof(PersonajeDtoForDetails), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetCharactersWithDetails(int id)
        {
            try
            {
                var character = _service.GetCharacteWithDetails(id);

                return Ok(character);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
