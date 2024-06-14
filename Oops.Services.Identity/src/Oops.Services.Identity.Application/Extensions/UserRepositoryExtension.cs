using Microsoft.EntityFrameworkCore;
using Oops.Services.Identity.Core.Entities;

namespace Oops.Services.Identity.Application.Extensions;

public static class UserRepositoryExtension
{
  public static Task<bool> HasEmailUsed(this DbSet<User> users,string email)
  {
    return users.AnyAsync(u => u.Email == email);
  }

  public static Task<bool> HasUsernameUsed(this DbSet<User> users,string username)
  {
    return users.AnyAsync(u => u.Username == username);
  }
}
