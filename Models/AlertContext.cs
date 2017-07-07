using Microsoft.EntityFrameworkCore;

namespace AlertApi.Models
{
    public class AlertContext : DbContext
    {
        public AlertContext(DbContextOptions<AlertContext> options)
            : base(options)
        {
        }

        public DbSet<AlertItem> AlertItems { get; set; }

    }
}