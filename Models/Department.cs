using System.ComponentModel.DataAnnotations;

namespace AngularBackEnd.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; } 
    }
}
