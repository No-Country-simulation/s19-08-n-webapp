using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MarketplaceAPI.Models
{
    public class Chat
    {
        [Key]
        public int idChat { get; set; }

        [Required(ErrorMessage = "The project ID is required.")]
        public int idProject { get; set; }

        [Required(ErrorMessage = "The user ID is required.")]
        public int idUser { get; set; }

        [Required(ErrorMessage = "The date and time are required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
        public DateTime dateTime { get; set; }
    }

}
