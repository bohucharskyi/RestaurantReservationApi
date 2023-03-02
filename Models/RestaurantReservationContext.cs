using Microsoft.EntityFrameworkCore;

namespace ReservationApi.Models
{
    public class RestaurantReservationContext : DbContext
    {
        public RestaurantReservationContext(DbContextOptions<RestaurantReservationContext> options)
            : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Table> Tables{ get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>()
                .Property(t => t.Size)
                .HasConversion<string>();

            #region Seeding

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant(1, "ABC Restaurant", TimeSpan.FromHours(15), TimeSpan.FromHours(23)),
                new Restaurant(2, "DEF Restaurant", TimeSpan.FromHours(16), TimeSpan.FromHours(22)),
                new Restaurant(3, "GHI Restaurant", TimeSpan.FromHours(17), TimeSpan.FromHours(21))
            );

            modelBuilder.Entity<Location>().HasData(
                new Location(1, 1, "ABC Restaurant Address 1"),
                new Location(2, 2, "DEF Restaurant Address 1"),
                new Location(3, 3, "GHI Restaurant Address 1")
            );

            modelBuilder.Entity<Table>().HasData(
                new Table(1, 1, Table.TableSize.Small),
                new Table(2, 1, Table.TableSize.Small),
                new Table(3, 1, Table.TableSize.Medium),
                new Table(4, 1, Table.TableSize.Medium),
                new Table(5, 1, Table.TableSize.Large),
                new Table(6, 2, Table.TableSize.Small),
                new Table(7, 2, Table.TableSize.Small),
                new Table(8, 2, Table.TableSize.Medium),
                new Table(9, 2, Table.TableSize.Medium),
                new Table(10, 2, Table.TableSize.Medium),
                new Table(11, 2, Table.TableSize.Large),
                new Table(12, 2, Table.TableSize.Large),
                new Table(13, 3, Table.TableSize.Small),
                new Table(14, 3, Table.TableSize.Medium),
                new Table(15, 3, Table.TableSize.Medium),
                new Table(16, 3, Table.TableSize.Large)
            );

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
