using System.ComponentModel.DataAnnotations;

namespace MarketplaceAPI.Models
{
    public class Role
    {
        [Key]
        public int idRole { get; set; }

        [Required(ErrorMessage = "The role name is required.")]
        [StringLength(50, ErrorMessage = "The role name must not exceed 50 characters.")]
        public string name { get; set; }

        [StringLength(150, ErrorMessage = "The description must not exceed 150 characters.")]
        public string description { get; set; }
    }

}
