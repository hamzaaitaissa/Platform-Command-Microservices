using System.Numerics;

namespace PlatformService.Data
{
    //we dont need to create any instance of it
    //If the database is empty, let’s fill in some cool starter data so users aren’t staring at a blank page.
    public static class PrepDb
    {
        public static void PrePopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>()); 
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("Seeding data...");

                context.Platforms.AddRange(
                    new Models.Platform() { Name = "Dot net", Publisher = "Microsoft", Cost = "Free"},
                    new Models.Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free"},
                    new Models.Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free"}
                    );
                //unless youy save it, it aint going anywhere
                context.SaveChanges();
            }
            else{
                Console.WriteLine("we already have data");
            }
        }
    }
}
