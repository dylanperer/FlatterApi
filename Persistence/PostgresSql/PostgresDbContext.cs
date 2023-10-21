using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PrototypeBackend.Entities;

namespace Persistence.PostgresSql;

public class PostgresDbContext : DbContext
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Profile> Profiles { get; set; }
    public virtual DbSet<GenderIdentity> GenderIdentities { get; set; }
    public virtual DbSet<Occupation> Occupations { get; set; }
    public virtual DbSet<InterestCollection> InterestCollections { get; set; }
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
            c.HasOne(p => p.GenderIdentity)
                .WithMany()
                .HasForeignKey(p => p.GenderIdentityId)
                .IsRequired();

            c.HasOne(p => p.PreferredGenderIdentity)
                .WithMany()
                .HasForeignKey(p => p.PreferredGenderIdentityId)
                .IsRequired();

            c.HasOne(p => p.Occupation)
                .WithMany()
                .HasForeignKey(p => p.OccupationId)
                .IsRequired();

            // c.HasOne(p => p.InterestCollection)
            //     .WithMany()
            //     .HasForeignKey(p => p.InterestCollectionId);
        });

        modelBuilder.Entity<InterestCollection>(c =>
        {
            c.HasOne(u => u.Interests).WithMany().HasForeignKey(u => u.InterestCollectionId);
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.LogTo(action: Console.WriteLine, minimumLevel: LogLevel.Information);
        options.UseNpgsql(
            "User ID=test;Password=test;Server=localhost;Port=5432;Database=dev; Integrated Security=true;Pooling=true;IncludeErrorDetail=true;");
    }
}