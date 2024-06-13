namespace Oops.Services.Identity.Core.Entities;

public class UserRole
{
  private UserRole() { }

  public UserRole(string roleId,  string userId)
  {
    RoleId = new Key(Guid.Parse(roleId));
    UserId = new Key(Guid.Parse(userId));
  }

  public Key UserId { get; private set; } = null!;
  public Key RoleId { get; private set; } = null!;

  public virtual User User { get; private set; } = null!;
  public virtual Role Role { get; private set; } = null!;
}
