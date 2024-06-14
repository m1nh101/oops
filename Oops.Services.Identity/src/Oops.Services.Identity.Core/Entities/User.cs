using Oops.Services.Identity.Core.Exceptions;

namespace Oops.Services.Identity.Core.Entities;

public class User : IAuditable, ICreatable
{
  private User() { }

  public User(string username, string email)
  {
    Username = username;
    Email = email;
  }

  public Key Id { get; private set; } = null!;
  public string Username { get; private set; } = string.Empty;
  public string Email { get; private set; } = string.Empty;
  public string Password { get; private set; } = string.Empty;

  public Profile Profile { get; private set; } = null!;
  public DateTime CreatedAt { get; set; }
  public DateTime? LastModifiedAt { get; set; }
  public Key CreatedBy { get; set; } = null!;
  public Key? ModifiedBy { get; set; }

  public virtual ICollection<Role> Roles { get; private set; } = [];
  public virtual ICollection<UserRole> UserRoles { get; private set; } = [];

  public void SetUsername(string username)
  {
    Username = username;
  }
  public void SetPassword(string password)
  {
    Password = password;
  }

  public User AssociateToProfile(Profile profile)
  {
    ArgumentNullException.ThrowIfNull(profile, nameof(profile));

    Profile = profile;
    return this;
  }
  public User AssignToRole(Role role)
  {
    var isAssignedInRoles = Roles.Any(e => e.Name == role.Name);
    if (isAssignedInRoles)
      throw new InvalidRoleException(role.Name);

    Roles.Add(role);
    return this;
  }

  public Profile LoadProfile()
  {
    ArgumentNullException.ThrowIfNull(Profile);

    return Profile;
  }

  public IEnumerable<string> GetUserRoles()
  {
    if(Roles is null)
      throw new NullReferenceException(nameof(Roles));

    return Roles.Select(x => x.Name);
  }
}
