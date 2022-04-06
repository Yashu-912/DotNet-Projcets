using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment8.Models {

    public class Student {

        [Key]
        public int Student_ID {get; set;}

        [Required]
        public string? Student_Name {get; set;} 

        [Required]
        public string? Class {get; set;}

        [Required]
        public int percentage {get; set;}

    }
}