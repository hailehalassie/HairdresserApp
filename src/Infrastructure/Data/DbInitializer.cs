using Domain.Entities;

namespace Infrastructure.Data
{ 
    public static class DbInitializer
    {
        public static async Task SeedServicesAsync(AppDbContext context)
    {
        if (!context.Services.Any())
        {
            var services = new List<Service>
            {
                new Service { Id = Guid.NewGuid(), Name = "Hair", Price = 10m, DurationInMinutes = 30 },
                new Service { Id = Guid.NewGuid(), Name = "Beard", Price = 8m, DurationInMinutes = 20 },
                new Service { Id = Guid.NewGuid(), Name = "Hair+Beard", Price = 15m, DurationInMinutes = 45 },
            };

            context.Services.AddRange(services);
            await context.SaveChangesAsync();
        }
    }
    }
}