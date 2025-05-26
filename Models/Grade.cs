using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Buoi5.Models
{
    public class Grade
    {
        public int GradeId { get; set; }

        [Required(ErrorMessage = "GradeName is required.")]
        public string GradeName { get; set; }

        [ValidateNever]
        public List<Student> Students { get; set; }
    }
}
