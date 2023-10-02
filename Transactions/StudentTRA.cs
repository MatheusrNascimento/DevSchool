using System.Data.SqlClient;
using Dapper;
using DevSchool.Entities;

namespace DevSchool.Transactions;

public class StudentTRA
{
    public async Student GetAll(string connectionString)
    {
        using (var sqlConnection = new SqlConnection(connectionString))
        {
            const  string slqCommand = "SELECT *FROM Students where IsActive = 1";
            
            var students = await sqlConnection.QueryAsync<Student>(slqCommand);
        }
    }
}