namespace Oops.Services.Identity.Core.Exceptions;

public sealed class InvalidRoleException : Exception
{
  public string RoleName { get; }

  public InvalidRoleException(string roleName)
  {
    RoleName = roleName;
  }
}
