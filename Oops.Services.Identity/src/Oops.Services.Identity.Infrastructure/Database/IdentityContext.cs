using Microsoft.EntityFrameworkCore;
using Oops.Services.Identity.Core.Entities;

namespace Oops.Services.Identity.Infrastructure.Database;

public class IdentityContext : DbContext
{
  public IdentityContext(DbContextOptions<IdentityContext> options)
    : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityContext).Assembly);
  }

  public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    foreach (var entry in ChangeTracker.Entries<ICreatable>())
    {
      if (entry.State == EntityState.Added)
      {
        entry.Entity.CreatedAt = DateTime.Now;

        // this will apply empty uuid value for non-user attach with data;
        // valid uuid will apply for user session attach data; implement later;
        entry.Entity.CreatedBy = new Key(Guid.Empty);
      }
    }

    foreach (var entry in ChangeTracker.Entries<IAuditable>())
    {
      if (entry.State == EntityState.Modified)
      {
        entry.Entity.LastModifiedAt = DateTime.Now;

        // this will apply empty uuid value for non-user attach with data;
        // valid uuid will apply for user session attach data; implement later;
        entry.Entity.ModifiedBy = new Key(Guid.Empty);
      }
    }

    return base.SaveChangesAsync(cancellationToken);
  }

  public virtual DbSet<User> Users => Set<User>();
  public virtual DbSet<Role> Roles => Set<Role>();
  public virtual DbSet<UserRole> UserRoles => Set<UserRole>();
}
