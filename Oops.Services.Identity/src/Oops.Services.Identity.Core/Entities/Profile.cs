namespace Oops.Services.Identity.Core.Entities;

public class Profile : IAuditable, ICreatable
{
  private Profile() { }

  public Profile(string givenName, DateTime birthday, Gender gender)
  {
    GivenName = givenName;
    Birthday = birthday;
    Gender = gender;
  }

  public Key Id { get; set; } = null!;
  public string GivenName { get; private set; } = string.Empty;
  public DateTime Birthday { get; private set; }
  public Gender Gender { get; private set; }
  public DateTime CreatedAt { get; set; }
  public DateTime? LastModifiedAt { get; set; }
  public Key CreatedBy { get; set; } = null!;
  public Key? ModifiedBy { get; set; }

  public virtual Key UserId { get; private set; } = null!;
  public virtual User User { get; private set; } = null!;
}
