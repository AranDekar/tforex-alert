using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AlertApi.Models;

namespace AlertApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<AlertContext>(options => options.UseSqlite("Data Source=Alerts.db"));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
            DBinitialize.EnsureCreated(app.ApplicationServices);
            SeedData.Initialize(app.ApplicationServices);
        }
    }
}