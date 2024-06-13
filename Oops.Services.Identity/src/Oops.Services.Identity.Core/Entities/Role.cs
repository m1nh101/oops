namespace Oops.Services.Identity.Core.Entities;

public class Role
{
  private Role() { }

  public Role(string name)
  {
    Name = name;
  }

  public Key Id { get; private set; } = null!;
  public string Name { get; private set; } = string.Empty;

  public void SetName(string name) => Name = name;

  public virtual ICollection<User> Users { get; private set; } = [];
  public virtual ICollection<UserRole> UserRoles { get; private set; } = [];
}
