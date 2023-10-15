using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope =  app.ApplicationServices.CreateScope())
            {
                SeedDate(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedDate(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding  data");

                context.Platforms.AddRange(
                    new Platform {Name = "Dot Net",Publisher= "Microsoft",Cost = "Free"},
                    new Platform { Name = "SQL Server", Publisher = "Microsoft", Cost = "Free" },
                    new Platform { Name = "Kubernates", Publisher = "Cloud Native computing  Foundation", Cost = "Free" }
                    );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already data");
            }
        }
    }
}
