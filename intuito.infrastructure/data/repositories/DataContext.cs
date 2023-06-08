using intuito.domain.entities;
using Microsoft.EntityFrameworkCore;

namespace intuito.infrastructure.data.repositories
{
    public class DataContext : DbContext
    {
        public DbSet<MovieEntity> Movie { get; set; }
        public DbSet<RoomEntity> Room { get; set; }
        public DbSet<CustomerEntity> Customer { get; set; }
        public DbSet<SeatEntity> Seat { get; set; }
        public DbSet<BookingEntity> Booking { get; set; }
        public DbSet<BillboardEntity> Billboard { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CustomerEntity>()
                .HasIndex(u => u.DocumentNumber)
                .IsUnique();
        }
    }
}
