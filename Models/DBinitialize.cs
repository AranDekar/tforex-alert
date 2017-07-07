using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AlertApi.Models
{
    public static class DBinitialize
    {
        public static void EnsureCreated(IServiceProvider serviceProvider)
        {
            var context = new AlertContext(serviceProvider.GetRequiredService<DbContextOptions<AlertContext>>());
            context.Database.EnsureCreated();
        }
    }
}