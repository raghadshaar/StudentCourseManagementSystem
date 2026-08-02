using StudentCourseManagementSystem.Repositories;
using StudentCourseManagementSystem.Services;

namespace StudentCourseManagementSystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await using var context =
                new StudentCourseManagementContext();

            var seeder =
                new DataSeeder(context);

            await seeder.SeedAsync();

            context.ChangeTracker.Clear();

            var runner =
                new DemoRunner(
                    context,
                    new StudentRepository(context),
                    new CourseRepository(context),
                    new InstructorRepository(context),
                    new DepartmentRepository(context));

            await runner.RunAsync();
        }
    }
}