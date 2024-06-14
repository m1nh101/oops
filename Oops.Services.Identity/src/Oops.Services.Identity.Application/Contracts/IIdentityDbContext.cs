using Microsoft.EntityFrameworkCore;
using Oops.Services.Identity.Core.Entities;

namespace Oops.Services.Identity.Application.Contracts;

public interface IIdentityDbContext
{
  DbSet<User> Users { get; }
  DbSet<Role> Roles { get; }

  Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
