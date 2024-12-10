using MarketplaceAPI.DTOs;

namespace MarketplaceAPI.Services.Interfaces
{
    public interface IPublicationService
    {
        Task<IEnumerable<PublicationDTO>> ListarPublicaciones();
        Task<PublicationDTO?> ObtenerPublicacion(int idPublication);
        Task<PublicationDTO?> ActualizarPublicacion(PublicationDTO publicationDto);
        Task<bool> EliminarPublicacion(int idPublication);
        Task<PublicationDTO> AgregarPublicacion(PublicationDTO publicationDto);

    }
}
