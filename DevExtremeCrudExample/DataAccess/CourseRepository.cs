using Dapper;
using DevExpress.Utils.Filtering;
using DevExtremeCrudExample.Models;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DevExtremeCrudExample.DataAccess
{
    public class CourseRepository
    {
        private readonly string _connectionString;
        
        public CourseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            var sql = "SELECT * FROM Courses";
            using (var db = Connection)
            {
                return await db.QueryAsync<Course>(sql);
            }
        }
    }
}
