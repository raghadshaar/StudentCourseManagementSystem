using Microsoft.EntityFrameworkCore;
using StudentCourseManagementSystem.Models;
using StudentCourseManagementSystem.Repositories;
using StudentCourseManagementSystem.Services;

namespace StudentCourseManagementSystem
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await using var context =
                new StudentCourseManagementContext();

            var seeder = new DataSeeder(context);
            await seeder.SeedAsync();
            context.ChangeTracker.Clear();
        }
           
       

              
    }
}