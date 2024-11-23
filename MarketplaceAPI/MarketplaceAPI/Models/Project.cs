using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarketplaceAPI.Models
{
    public class Project
    {
        [Key]
        public int IdProject { get; set; } // PK

        [Required(ErrorMessage = "Publication ID is required.")]
        public int IdPublication { get; set; } // FK

        [Required(ErrorMessage = "Requester User ID is required.")]
        public int IdUserRequester { get; set; } // FK

        [Required(ErrorMessage = "Collaborator User ID is required.")]
        public int IdUserCollaborator { get; set; } // FK

        [Required(ErrorMessage = "Start date is required.")]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [MaxLength(100, ErrorMessage = "Status cannot exceed 100 characters.")]
        public string Status { get; set; }

        
        // class relacionadas
        [ForeignKey("IdPublication")]
        public Publication publication { get; set; } 

        public User user { get; set; }     
        
    }
}
