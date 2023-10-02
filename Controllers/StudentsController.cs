using System.Data.SqlClient;
using Dapper;
using DevSchool.Entities;
using DevSchool.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevSchool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<IActionResult> Post(StudentInputModel model)
        {
            var student = new Students(model.FullName, model.BirthDate, model.SchoolClass, model.IsActive);

            var parameters = new
            {
                student.FullName,
                student.BirthDate,
                student.SchoolClass,
                student.IsActive
            };
            
            await using (var sqlConnection = new SqlConnection(_connectionString))
            {
                const string sqlCommand = "INSERT INTO Students ([FullName], [BirthDate], [SchoolClass], [IsActive])" +
                                          "VALUES (@FullName, @BirthDate, @SchoolClass, @IsActive)";
                int id = await sqlConnection.ExecuteScalarAsync<int>(sqlCommand, parameters);

                return Ok(id);
            }
        }
    
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, StudentInputModel model)
        {
            var parameters = new
            {
                model.FullName,
                model.BirthDate,
                model.SchoolClass,
                model.IsActive
            };
            await using (var sqlConnection = new SqlConnection(_connectionString))
            {
                const string sqlCommand =
                    "UPDATE Students SET [FullName] = @FullName, [BirthDate] = @BirthDate, [SchoolClass] = @SchoolClass, [IsActive] = @IsActive WHERE StudentId = @Id";
                await sqlConnection.ExecuteAsync(sqlCommand, parameters);
                
            }

            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var parameters = new
            { 
                id
            };
            
            await using (var sqlConnection = new SqlConnection(_connectionString))
            {
                const string sqlCommand =
                    "UPDATE Students SET [IsActive] = 0 WHERE StudentId = @Id";
                await sqlConnection.ExecuteAsync(sqlCommand, parameters);
                
            }

            return Ok();
        }
    }
}