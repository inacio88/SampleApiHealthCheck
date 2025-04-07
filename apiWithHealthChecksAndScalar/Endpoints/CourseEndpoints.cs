using apiWithHealthChecksAndScalar.Data;

namespace apiWithHealthChecksAndScalar.Endpoints
{
    public static class CourseEndpoints
    {
        public static void AddCourseEndpoints(this WebApplication app)
        {
            app.MapGet("/courses", LoadAllCoursesAsync);
            app.MapGet("/courses/{id}", LoadCourseByIdAsync);
        }

        private static async Task<IResult> LoadCourseByIdAsync(CourseData data, int id, int? delay)
        {

            if (delay is not null)
            {
                if(delay > 300_000)
                {
                    delay = 300_000;
                }
                await Task.Delay((int)delay);
            }

            var output = data.Courses.SingleOrDefault(x => x.Id == id);
            if (output is null)
            {
                return Results.NotFound();
            }
            return Results.Ok(output);
        }

        private static async Task<IResult> LoadAllCoursesAsync(CourseData data, string? courseType, string? search, int? delay)
        {
            var output = data.Courses;

            if (!string.IsNullOrWhiteSpace(courseType))
            {
                output.RemoveAll(x => string.Compare(x.CourseType, courseType, StringComparison.OrdinalIgnoreCase) != 0);
            }
            if (!string.IsNullOrWhiteSpace(search))
            {
                output.RemoveAll(x => !x.CourseName.Contains(search, StringComparison.OrdinalIgnoreCase)
                                      &&
                                      !x.ShortDescription.Contains(search, StringComparison.OrdinalIgnoreCase)
                                );
            }

            if (delay is not null)
            {
                if(delay > 300_000)
                {
                    delay = 300_000;
                }
                await Task.Delay((int)delay);
            }

            return Results.Ok(output);
        } 
    }
}