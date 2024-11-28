using System.ComponentModel.DataAnnotations;

namespace MarketplaceAPI.Models
{
    public class Evaluation
    {
        [Key]
        public int idEvaluation { get; set; }

        [Required(ErrorMessage = "The project ID is required.")]
        public int idProject { get; set; }

        [Required(ErrorMessage = "The evaluator user ID is required.")]
        public int idEvaluatorUser { get; set; }

        [Required(ErrorMessage = "The evaluated user ID is required.")]
        public int idEvaluatedUser { get; set; }

        [Required(ErrorMessage = "The name is required.")]
        public string nameEvaluated { get; set; }

        [Required(ErrorMessage = "The score is required.")]
        public int rating { get; set; }

        [StringLength(200, ErrorMessage = "The comment must not exceed 200 characters.")]
        public string comment { get; set; }

        [Required(ErrorMessage = "The date is required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date format.")]
        public DateTime dateTime { get; set; }

    }
}
