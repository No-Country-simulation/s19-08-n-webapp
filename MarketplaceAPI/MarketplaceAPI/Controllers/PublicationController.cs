using MarketplaceAPI.DTOs;
using MarketplaceAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketplaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicationsController : ControllerBase
    {
        private readonly IPublicationService _publicationService;

        public PublicationsController(IPublicationService publicationService)
        {
            _publicationService = publicationService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarPublicaciones()
        {
            var publication = await _publicationService.ListarPublicaciones();
            return Ok(publication);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPublicacion(int id)
        {
            var publication = await _publicationService.ObtenerPublicacion(id);
            if (publication == null)
                return NotFound(new { message = "Publicación no encontrada." });


            return Ok(publication);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarPublicacion(int id, [FromBody] PublicationDTO publicationDto)
        {
            if (id != publicationDto.idPublication)
                return BadRequest(new { message = "El ID de la publicación no coincide." });


            var updatedPublication = await _publicationService.ActualizarPublicacion(publicationDto);
            if (updatedPublication == null)
                return NotFound(new { message = "Publicación no encontrada para actualizar." });

            return Ok(updatedPublication);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPublicacion(int id)
        {
            var eliminted = await _publicationService.EliminarPublicacion(id);
            if (!eliminted)
                return NotFound(new { message = "Publicación no encontrada para eliminar." });

            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> AgregarPublicacion([FromBody] PublicationDTO publicationDto)
        {
            if (publicationDto == null)
                return BadRequest(new { message = "Datos de la publicación no válidos." });

            var createdPublication = await _publicationService.AgregarPublicacion(publicationDto);
            return CreatedAtAction(nameof(ObtenerPublicacion), new { id = createdPublication.idPublication }, createdPublication);
        }
    }
}

