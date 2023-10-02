using Microsoft.AspNetCore.Mvc;

namespace DevSchool.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly string _connectionString;
        public StudentsController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevSchool");
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return NoContent();
        }
    }
}