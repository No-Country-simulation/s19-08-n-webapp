using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarketplaceAPI.Models
{
    public class Publication
    {
        [Key]
        public int IdPublication { get; set; } //PK

        [Required(ErrorMessage = "User ID is required.")]
        public int IdUser { get; set; } // FK

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(50, ErrorMessage = "Title cannot exceed 50 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(100, ErrorMessage = "Description cannot exceed 100 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Publication date is required.")]
        public DateTime PublicationDate { get; set; }

        [StringLength(200, ErrorMessage = "Image URL cannot exceed 200 characters.")]
        public string Image { get; set; }


        //tablas relacionadas
        
        [ForeignKey("IdUser")]
        public User User { get; set; }
    }
}
