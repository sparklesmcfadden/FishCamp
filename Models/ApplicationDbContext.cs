using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FishCamp.Models;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IDataProtectionKeyContext
{
    public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Call this first and then make model customizations
        base.OnModelCreating(builder);

        foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        builder.Entity<ApplicationUser>().ToTable("User");
        builder.Entity<IdentityRole>().ToTable("Role");
        builder.Entity<IdentityUserRole<string>>().ToTable("UserRole");
        builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
        builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");
        builder.Entity<IdentityUserToken<string>>().ToTable("UserToken");
    }

    public DbSet<Trip> Trips { get; set; }
    public DbSet<TripUser> TripUsers { get; set; }
    public DbSet<TripComment> TripComments { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<LocationTrip> LocationTrips { get; set; }
    public DbSet<LocationComment> LocationComments { get; set; }
    public DbSet<LocationPhoto> LocationPhotos { get; set; }
    public DbSet<LocationVisit> LocationVisits { get; set; }
    public DbSet<LocationVisitComment> LocationVisitComments { get; set; }
    public DbSet<LocationVisitPhoto> LocationVisitPhotos { get; set; }
    public DbSet<LocationVisitUser> LocationVisitUsers { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<PhotoComment> PhotoComments { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Fish> FishTypes { get; set; }
    public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }
}