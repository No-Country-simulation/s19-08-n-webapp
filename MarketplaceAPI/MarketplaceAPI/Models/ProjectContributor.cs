using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MarketplaceAPI.Models
{
    public class ProjectContributor
    {
        [Key]
        [Required(ErrorMessage = "Project ID is required.")]
        public int idProject { get; set; }

        [Required(ErrorMessage = "IdUser collaborator ID is required.")]
        public int idUserContributor { get; set; }

        [Required(ErrorMessage = "IdUser collaborator ID is required.")]
        public string nameContributor { get; set; }

        [Required(ErrorMessage = "collaborator date is required.")]
        public DateTime applicationDate { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [StringLength(20, ErrorMessage = "Status cannot be longer than 20 characters.")]
        public string status { get; set; }



        // Navigation properties
        [JsonIgnore]
        public Project Project { get; set; }
        [JsonIgnore]
        public User Applicant { get; set; }  

    }
}
