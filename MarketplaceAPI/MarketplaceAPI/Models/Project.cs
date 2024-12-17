using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MarketplaceAPI.Models
{
    public class Project
    {
        [Key]
      
        public int idProject { get; set; } // PK

        //-----------------------------
        [Required(ErrorMessage = "Publication ID is required.")]
        public int idPublication { get; set; } // FK

        //-----------------------------
        [Required(ErrorMessage = "Requester User ID is required.")]
        public int idUserRequester { get; set; } // FK

        //-----------------------------
        [Required(ErrorMessage = "Name project is required.")]
        public  string nameProject { get; set; }
        //-----------------------------

        [Required(ErrorMessage = "Description project is required.")]
        public string description { get; set; }

        //-----------------------------
        [Required(ErrorMessage = "Start date is required.")]
        public DateTime startDate { get; set; }

        //-----------------------------
        public DateTime? endDate { get; set; }

        //-----------------------------
        [Required(ErrorMessage = "The state is required.")]
        [MaxLength(100, ErrorMessage = "The state must not exceed 20 characters.")]
        public string stateProject { get; set; }

   


    }
}
