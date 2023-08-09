using Microsoft.EntityFrameworkCore;

namespace AuthorizationService.Data
{
	public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext appDbContext)
        {
            Console.WriteLine("--> Attempting to apply migrations...");

            try
            {
                appDbContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"---> Could not run migration : {ex.Message}");
            }
        }
    }
}

