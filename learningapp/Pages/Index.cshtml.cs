using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace learningapp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<Course> Courses = new List<Course>();
        
        private IConfiguration _configuration;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void OnGet()
        {
            string connectionString = _configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")!;
            // var config = _configuration.GetSection("Common:Settings");
            // string connectionString = config.GetValue<string>("dbpassword");

            var sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            var sqlcommand = new SqlCommand(
            "SELECT CourseID,CourseName,Rating FROM Course;", sqlConnection);

            using (SqlDataReader sqlDatareader = sqlcommand.ExecuteReader())
            {
                while (sqlDatareader.Read())
                {
                    if (sqlDatareader.HasRows)
                    {
                        Courses.Add(new Course()
                        {
                            CourseID = Int32.Parse(sqlDatareader["CourseID"].ToString()),
                            CourseName = sqlDatareader["CourseName"].ToString(),
                            Rating = Decimal.Parse(sqlDatareader["Rating"].ToString())
                        });
                    }

                }
            }

        }
    }
}
