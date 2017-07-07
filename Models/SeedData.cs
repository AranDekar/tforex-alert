using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace AlertApi.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AlertContext(
                serviceProvider.GetRequiredService<DbContextOptions<AlertContext>>()))
            {
                // Look for any AlertItems.
                if (context.AlertItems.Any())
                {
                    return;   // DB has been seeded
                }

                context.AlertItems.AddRange(
                     new AlertItem
                     {
                         Id = 1,
                         Name = "asp.net core redis + travis + aws ecs",
                         IsComplete = false
                     },
                     new AlertItem
                     {
                         Id = 2,
                         Name = "node js + travis + aws ecs",
                         IsComplete = false
                     },
                     new AlertItem
                     {
                         Id = 3,
                         Name = "alertItem => alerts",
                         IsComplete = false
                     }
                );
                context.SaveChanges();
            }
        }
    }
}