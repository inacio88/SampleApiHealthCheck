using System.Text.Json;
using apiWithHealthChecksAndScalar.Models;

namespace apiWithHealthChecksAndScalar.Data
{
    public class CourseData
    {
        public List<CourseModel> Courses {get; private set;}

        public CourseData()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }; 
            string filepath = Path.Combine(
            Directory.GetCurrentDirectory(), 
            "Data", 
            "coursedata.json");

            string json = File.ReadAllText(filepath);

            Courses = JsonSerializer.Deserialize<List<CourseModel>>(json, options) ?? new List<CourseModel>();
        }
    }
}