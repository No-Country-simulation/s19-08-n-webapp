using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MarketplaceAPI.Models
{
    public class ProjectContributor
    {
        [Key]

        public int idProjectContributor { get; set; }

        [Required(ErrorMessage = "Project ID is required.")]
        public int idProject { get; set; }

        [Required(ErrorMessage = "IdUser collaborator ID is required.")]
        public int idUserContributor { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "collaborator date is required.")]
        public DateTime applicationDate { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [StringLength(20, ErrorMessage = "Status cannot be longer than 20 characters.")]
        public string status { get; set; }

    }
}
