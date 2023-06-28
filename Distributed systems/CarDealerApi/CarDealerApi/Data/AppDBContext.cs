using CarDealerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealerApi.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options)
        {
        }
        public DbSet<Car> cars { get; set; }
        public DbSet<User> users { get; set; }
    }
}
