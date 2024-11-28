using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarketplaceAPI.Models
{
    public class Notification
    {
        [Key]
        public int idNotification { get; set; }

        [Required(ErrorMessage = "The project ID is required.")]
        public int idProject { get; set; }

        [Required(ErrorMessage = "The notification type is required.")]
        [StringLength(50, ErrorMessage = "The notification type must not exceed 50 characters.")]
        public string type { get; set; }

        [StringLength(150, ErrorMessage = "The description must not exceed 150 characters.")]
        public string description { get; set; }

        [Required(ErrorMessage = "The state is required.")]
        [StringLength(20, ErrorMessage = "The state must not exceed 20 characters.")]
        public string state { get; set; }

        public int? idUserCollaborator { get; set; }

        
    }
}
