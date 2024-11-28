using System.ComponentModel.DataAnnotations;

namespace MarketplaceAPI.Models
{
    public class Message
    {
        [Key]
        public int idMessage { get; set; }

        [Required(ErrorMessage = "The chat ID is required.")]
        public int idChat { get; set; }

        [Required(ErrorMessage = "The sender is required.")]
        [StringLength(50, ErrorMessage = "The sender name must not exceed 50 characters.")]
        public string sender { get; set; }

        [Required(ErrorMessage = "The message is required.")]
        [StringLength(200, ErrorMessage = "The message must not exceed 200 characters.")]
        public string message { get; set; }

        [Required(ErrorMessage = "The date and time are required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
        public DateTime dateTime { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        [StringLength(200, ErrorMessage = "The URL must not exceed 200 characters.")]
        public string url { get; set; }
    }

}
