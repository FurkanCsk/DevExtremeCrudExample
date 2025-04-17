using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Pkcs;

namespace DevExtremeCrudExample.Models
{
    public class StudentWithCourse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
    }
}
