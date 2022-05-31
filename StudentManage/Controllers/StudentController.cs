using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManage.Model;
using StudentManage.Service;
using StudentManage.ViewModel;

namespace StudentManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var student = await _studentService.GetAll();
            if (student == null)
            {
                return BadRequest("No student find");
            }
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] StudentVm student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _studentService.Create(student);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(student);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _studentService.Delete(id);
            if (!result)
            {
                return BadRequest();
            }
            return Ok(id);
        }
    }
}