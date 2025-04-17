using DevExtremeCrudExample.DataAccess;
using DevExtremeCrudExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DevExtremeCrudExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly StudentRepository _studentRepository;
        public StudentController(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentRepository.GetAllAsync();
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Dictionary<string, object> values)
        {
            if (!values.TryGetValue("values", out var valuesJson))
            {
                return BadRequest("Eksik veri.");
            }

            var student = JsonSerializer.Deserialize<Student>(valuesJson.ToString());

            if (student == null || !ModelState.IsValid)
            {
                return BadRequest("Geçersiz öğrenci verisi.");
            }

            await _studentRepository.AddAsync(student);
            return Ok(student);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]  Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // var editedStudent = JsonSerializer.Deserialize<Student>(student.ToString());

            await _studentRepository.UpdateAsync(student);
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
