using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarketplaceAPI.Models
{
    public class Publication
    {
        [Key]
        public int idPublication { get; set; } //PK

        [Required(ErrorMessage = "User ID is required.")]
        public int idUser { get; set; } // FK

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(50, ErrorMessage = "Title cannot exceed 50 characters.")]
        public string title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(100, ErrorMessage = "Description cannot exceed 100 characters.")]
        public string description { get; set; }

        [Required(ErrorMessage = "Publication date is required.")]
        public DateTime publicationDate { get; set; }

        [StringLength(200, ErrorMessage = "Image URL cannot exceed 200 characters.")]
        public string image { get; set; }

        [Required(ErrorMessage = "The state is required.")]
        [StringLength(20, ErrorMessage = "The state must not exceed 20 characters.")]
        public string state { get; set; }

    }
}
