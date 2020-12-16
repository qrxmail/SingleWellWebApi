using SingleWellWebApi.Models.BaseInfo;
using SingleWellWebApi.Models.Work;
using Microsoft.EntityFrameworkCore;

namespace SingleWellWebApi.Models
{
    public class SingleWellWebContext : DbContext
    {
        public SingleWellWebContext(DbContextOptions<SingleWellWebContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<OilStation> OilStation { get; set; }
        public DbSet<Truck> Truck { get; set; }

        public DbSet<WorkTicket> WorkTicket { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

