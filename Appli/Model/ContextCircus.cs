using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace WildCircus
{
    public class WildCircusContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=WildCircus;Integrated Security=True; MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
     
        }

        public bool Exists()
        {
            return (this.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists();
        }
    }
}
