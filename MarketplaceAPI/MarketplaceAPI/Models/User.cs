using System.ComponentModel.DataAnnotations;

namespace MarketplaceAPI.Models
{
    public class User
    {
        [Key]
        public int idUser { get; set; }

        [Required(ErrorMessage = "The name is required.")]
        [StringLength(50, ErrorMessage = "The name must not exceed 50 characters.")]
        public string name { get; set; }

        [Required(ErrorMessage = "The last name is required.")]
        [StringLength(50, ErrorMessage = "The last name must not exceed 50 characters.")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "The email is required.")]
        [StringLength(100, ErrorMessage = "The email must not exceed 100 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string email { get; set; }

        [Required(ErrorMessage = "The country is required.")]
        [StringLength(50, ErrorMessage = "The country must not exceed 50 characters.")]
        public string country { get; set; }

        [StringLength(200, ErrorMessage = "The LinkedIn URL must not exceed 200 characters.")]
        public string linkedIn { get; set; }

        
        [StringLength(200, ErrorMessage = "The portfolio URL must not exceed 200 characters.")]
        public string portfolio { get; set; }

        [StringLength(100, ErrorMessage = "The image URL must not exceed 100 characters.")]
        public string image { get; set; }

        [Required(ErrorMessage = "The role is required.")]
        public int idRole { get; set; }

        public ICollection<ProjectContributor> ProjectApplications { get; set; } // List of project applications

    }

}
