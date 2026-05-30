using Microsoft.EntityFrameworkCore;
using ML;

namespace DL;

public class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost,1433;Database=PruebaTecnicaDB;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;");
        }
    }
    public DbSet<ML.WorkedHoursReport> WorkedHoursReports { get; set; }
    public DbSet<Login> Logins { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Area> Areas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Login>()
            .ToTable("ccloglogin");

        modelBuilder.Entity<User>()
            .ToTable("ccUsers");

        modelBuilder.Entity<Area>()
            .ToTable("ccRIACat_Areas");

        modelBuilder.Entity<ML.WorkedHoursReport>()
        .HasNoKey();
    }
}