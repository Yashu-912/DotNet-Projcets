using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assignment8.Models {

    public class Teacher {

        [Key]
        public int Teacher_ID {get; set;}

        [Required]
        public string? Teacher_Name {get; set;}

        [Required]
        public string? Subject {get; set;}

    }
}
