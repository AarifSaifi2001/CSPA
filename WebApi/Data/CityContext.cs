using Microsoft.EntityFrameworkCore;

namespace WebApi.Data
{
    public class CityContext : DbContext
    {
        
        public CityContext(DbContextOptions<CityContext> options): base(options)
        {
            
        }

        public DbSet<Cities> Cities{ get; set;}

        public DbSet<User> Users{ get; set;}

        public DbSet<Car> Cars{get; set;}

        public DbSet<FuelType> FuelTypes{get; set;}

        public DbSet<BodyType> BodyTypes{get; set;}
    }
}