using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Buoi5.Models

{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GradeId { get; set; }

        [ValidateNever]
        public Grade Grade { get; set; }

    }
}
