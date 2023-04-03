using Microsoft.EntityFrameworkCore;
using MvcToDoApi.Data;
using MvcToDoApi.Models;

namespace MvcToDoApi.SeedData
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcToDoApiContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcToDoApiContext>>()))

            {
                // Look for any projets.
                if (context.ProjectItem.Any())
                {
                    return; // DB has been seeded
                }

                context.ProjectItem.AddRange(
                    new ProjectItem
                    {
                        Name = "Create models",
                        StartDate = DateTime.Parse("31-3-2023"),
                        EndDate = DateTime.Parse("2-4-2023"),
                        StatusOfProject = StatusOfProject.Active,
                        Priority = 1
                    },

                    new ProjectItem
                    {
                        Name = "",
                        StartDate = DateTime.Parse("1-4-2023"),
                        EndDate = DateTime.Parse("3-4-2023"),
                        StatusOfProject = StatusOfProject.Active,
                        Priority = 1
                    },

                    new ProjectItem
                    {
                        Name = "",
                        StartDate = DateTime.Parse("2-4-2023"),
                        EndDate = DateTime.Parse("4-4-2023"),
                        StatusOfProject = StatusOfProject.Active,
                        Priority = 2
                    },

                    new ProjectItem
                    {
                        Name = "",
                        StartDate = DateTime.Parse("3-4-2023"),
                        EndDate = DateTime.Parse("5-4-2023"),
                        StatusOfProject = StatusOfProject.NotStarted,
                        Priority = 2
                    },

                    new ProjectItem
                    {
                        Name = "",
                        StartDate = DateTime.Parse("4-4-2023"),
                        EndDate = DateTime.Parse("6-4-2023"),
                        StatusOfProject = StatusOfProject.NotStarted,
                        Priority = 3
                    },

                    new ProjectItem
                    {
                        Name = "",
                        StartDate = DateTime.Parse("5-4-2023"),
                        EndDate = DateTime.Parse("7-4-2023"),
                        StatusOfProject = StatusOfProject.NotStarted,
                        Priority = 3
                    }

                );
                context.SaveChanges();
            }
        }
    }
}
