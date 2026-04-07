using System.ComponentModel.DataAnnotations;

namespace MVCWithLinq1.Models
{
    [MetadataType(typeof(StudentMetaData))]
    public partial class Student
    {
    }

    public class StudentMetaData
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(1, 100, ErrorMessage = "Age must be between 1 to 100")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Class is required")]
        public string Class { get; set; }

        [Required(ErrorMessage = "Fees is required")]
        public int? Fees { get; set; }
    }
}