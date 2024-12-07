using MarketplaceAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace MarketplaceAPI.DTOs
{
    public class PublicationDTO : BaseDTO
    {
        public int idPublication { get; set; } //PK
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public int idUser { get; set; }

    }
}
