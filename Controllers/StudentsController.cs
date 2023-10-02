using System.Data.SqlClient;
using Dapper;
using DevSchool.Entities;
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
            await using (var sqlConnection = new SqlConnection(_connectionString))
            {
                const  string slqCommand = "SELECT *FROM Students where IsActive = 1";

                var students = await sqlConnection.QueryAsync<Students>(slqCommand);

                return Ok(students);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var parameters = new
            {
                id = id
            };
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                const string sqlCommand = "SELECT *FROM Students WHERE StudentId = @id";
                var student = await sqlConnection.QuerySingleOrDefaultAsync<Students>(sqlCommand, parameters);

                if (student is null)
                    return NotFound();
                else
                    return Ok(student);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return NoContent();
        }
    }
}