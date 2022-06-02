
using Microsoft.EntityFrameworkCore;

public class AirplaneContext : DbContext
{

    public DbSet<Passenger> Passengers { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Airplane> Airplanes { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<CityOfArrival> CitiesOfArrival { get; set; }
    public DbSet<CityOfDeparture> CitiesOfDeparture { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder); optionsBuilder.UseNpgsql(@"Host=localhost;Database=airplane-company;Username=airplane-company;Password=password")
            .UseSnakeCaseNamingConvention()
            .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())).EnableSensitiveDataLogging();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Airplane>().Property(ap => ap.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Passenger>().Property(p => p.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Flight>().Property(f => f.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<Ticket>().Property(t => t.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<CityOfArrival>().Property(ca => ca.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<CityOfDeparture>().Property(cd => cd.Id).ValueGeneratedOnAdd();

        modelBuilder.Entity<Passenger>().HasMany(ps => ps.Tickets);
        modelBuilder.Entity<Flight>().HasMany(fl => fl.Tickets).WithOne(t => t.Flight);
        modelBuilder.Entity<Airplane>().HasMany(ap => ap.Flights).WithOne(fl => fl.Airplane);
        modelBuilder.Entity<CityOfDeparture>().HasMany(cd => cd.Flights).WithOne(fl => fl.CityOfDeparture);
        modelBuilder.Entity<CityOfArrival>().HasMany(ca => ca.Flights).WithOne(fl => fl.CityOfArrival);
    }

}

