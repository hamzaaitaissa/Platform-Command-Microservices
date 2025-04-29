namespace PlatformService.Data
{
    //we dont need to create any instance of it
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
            }
            else{
                Console.WriteLine("we already have data");
            }
        }
    }
}
