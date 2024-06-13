namespace Oops.Services.Identity.Core.Entities;

public class User : IAuditable, ICreatable
{
  private User() { }

  public User(string username, string email, string password)
  {
    Username = username;
    Email = email;
    Password = password;
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

  public User AssociateToProfile(Profile profile)
  {
    ArgumentNullException.ThrowIfNull(profile, nameof(profile));

    Profile = profile;
    return this;
  }

  public Profile LoadProfile()
  {
    ArgumentNullException.ThrowIfNull(Profile);

    return Profile;
  }
}
