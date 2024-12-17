using MarketplaceAPI.Data;
using MarketplaceAPI.DTOs;
using MarketplaceAPI.Models;
using MarketplaceAPI.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceAPI.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly DBContextMarketplace _dbContext;

        public PublicationService(DBContextMarketplace dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<PublicationDTO>> ListarPublicaciones()
        {
            return await _dbContext.Publications
                .Select(pub => new PublicationDTO
                {
                    idPublication = pub.idPublication,
                    title = pub.title,
                    image = pub.image,
                    description = pub.description,
                    idUser = pub.idUser
                })
                .ToListAsync();
        }
        public async Task<PublicationDTO?> ObtenerPublicacion(int idPublication)
        {
            var publication = await _dbContext.Publications.FindAsync(idPublication);
            if (publication == null) return null;
            return new PublicationDTO
            {
                idPublication = publication.idPublication,
                title = publication.title,
                image = publication.image,
                description = publication.description,
                idUser = publication.idUser
            };
        }

        public async Task<PublicationDTO?> ActualizarPublicacion(PublicationDTO publicationDto)
        {
            var publication = await _dbContext.Publications.FindAsync(publicationDto.idPublication);
            if (publication == null) return null;

            publication.title = publicationDto.title;
            publication.image = publicationDto.image;
            publication.description = publicationDto.description;
            _dbContext.Publications.Update(publication);
            await _dbContext.SaveChangesAsync();
            return new PublicationDTO
            {
                idPublication = publication.idPublication,
                title = publication.title,
                image = publication.image,  
                description = publication.description,
                idUser = publication.idUser
            };
        }
        public async Task<bool> EliminarPublicacion(int idPublication)
        {
            var publication = await _dbContext.Publications.FindAsync(idPublication);
            if (publication == null) return false;
            _dbContext.Publications.Remove(publication);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
        public async Task<PublicationDTO> AgregarPublicacion(PublicationDTO publicationDto)
        {
            var newPublication = new Publication
            {
                title = publicationDto.title,
                description = publicationDto.description,
                image = publicationDto.image,
                idUser = publicationDto.idUser
            };

            _dbContext.Publications.Add(newPublication);
            await _dbContext.SaveChangesAsync();

            return new PublicationDTO
            {
                idPublication = newPublication.idPublication,
                title = newPublication.title,
                description = newPublication.description,
                image = newPublication.image,
                idUser = newPublication.idUser
            };
        }
    }
}

