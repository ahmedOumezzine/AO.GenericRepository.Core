using System.ComponentModel.DataAnnotations;

namespace DemoApp.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
         
        [Required]
        public string Name { get; set; }

        [Required]
        public string Prenom { get; set; }

    }
}

