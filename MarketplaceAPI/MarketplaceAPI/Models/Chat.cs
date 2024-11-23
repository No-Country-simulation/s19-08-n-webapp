using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarketplaceAPI.Models
{
    public class Chat
    {
        [Key]
        public int IdChat { get; set; } // PK

        [Required(ErrorMessage = "Project ID is required.")]
        public int IdProject { get; set; } // FK

        [Required(ErrorMessage = "User ID is required.")]
        public int IdUser { get; set; } // FK

        [Required(ErrorMessage = "Message is required.")]
        [MaxLength(200, ErrorMessage = "Message cannot exceed 200 characters.")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Date and time are required.")]
        public DateTime DateTime { get; set; }

        [MaxLength(200, ErrorMessage = "URL cannot exceed 200 characters.")]
        public string? Url { get; set; }



        //tablas relacionadas

        [ForeignKey("IdProject")]
        public Project Project { get; set; } 

        [ForeignKey("IdUser")]
        public User User { get; set; }
    }
}
