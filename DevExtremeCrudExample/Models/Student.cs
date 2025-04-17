using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DevExtremeCrudExample.Models
{
    public class Student
    {
        public int Id { get; set; }   // Primary key
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("courseId")]
        public int CourseId { get; set; }
    }
}
