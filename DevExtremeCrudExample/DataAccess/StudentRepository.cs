using Dapper;
using DevExpress.Utils.Filtering;
using DevExtremeCrudExample.Models;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DevExtremeCrudExample.DataAccess
{
    public class StudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        private IDbConnection Connection => new SqlConnection(_connectionString);

        public async Task<IEnumerable<StudentWithCourse>> GetAllAsync()
        {
            var sql = @" SELECT s.Id AS Id,
                        s.Name AS Name,
                        s.Email AS Email,
                        s.CourseId,
                        c.Title AS CourseTitle
                        FROM Students s
                        INNER JOIN Courses c ON s.CourseId = c.Id";


            using (var db = Connection)
            {
                return await db.QueryAsync<StudentWithCourse>(sql);
            }
        }

        public async Task AddAsync(Student student)
        {
            var sql = "INSERT INTO Students (Name,Email,CourseId) VALUES (@Name,@Email,@CourseId)";

            using(var db = Connection)
            {
               await db.ExecuteAsync(sql, student);
            }
        }

        public async Task UpdateAsync(Student student)
        {
            var sql = "UPDATE Students SET Name = @Name, Email = @Email, CourseId = @CourseId Where Id = @Id";

            using (var db = Connection)
            {
                await db.ExecuteAsync(sql, student);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM Students Where Id = @Id";
            using (var db = Connection)
            {
                await db.ExecuteAsync(sql, new { Id = id});
            }
        }


    }
}
