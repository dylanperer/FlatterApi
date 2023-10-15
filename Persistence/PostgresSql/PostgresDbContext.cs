using Microsoft.EntityFrameworkCore;
using PrototypeBackend.Entities;

namespace Persistence.PostgresSql;

public class PostgresDbContext : DbContext
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Profile> Profiles { get; set; }
    public virtual DbSet<Occupation> Occupations { get; set; }
    public virtual DbSet<Interest> Interests { get; set; }
    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public PostgresDbContext()
    {
    }

    public PostgresDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(c =>
        {
            c.HasOne(user => user.Profile).WithOne(profile => profile.User)
                .HasForeignKey<Profile>(u => u.ProfileId);
        });

        modelBuilder.Entity<Profile>(c =>
        {
            c.HasOne(profile => profile.Occupation).WithOne()
                .HasForeignKey<Occupation>(u=>u.OccupationId);

            c.HasMany(profile => profile.Interests);
        });
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql(
            "User ID=test;Password=test;Server=localhost;Port=5432;Database=prototype; Integrated Security=true;Pooling=true");
}