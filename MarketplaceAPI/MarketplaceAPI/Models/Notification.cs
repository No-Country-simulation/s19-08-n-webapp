using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarketplaceAPI.Models
{
    public class Notification
    {
        [Key]
        public int IdNotification { get; set; } // PK

        [Required(ErrorMessage = "Project ID is required.")]
        public int IdProject { get; set; } // FK

        [Required(ErrorMessage = "Notification type is required.")]
        [StringLength(50, ErrorMessage = "Notification type cannot exceed 50 characters.")]
        public string NotificationType { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(50, ErrorMessage = "Description cannot exceed 50 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [StringLength(20, ErrorMessage = "Status cannot exceed 20 characters.")]
        public string Status { get; set; }

        [StringLength(50, ErrorMessage = "Type notification cannot exceed 50 characters.")]
        public string? TypeNotification { get; set; }

        public int? IdUserCollaborator { get; set; } //FK


        //tablas relacionadas

        [ForeignKey("IdProject")]
        public Project project { get; set; } 

        [ForeignKey("IdUserCollaborator")]
        public User user { get; set; }
    }
}
