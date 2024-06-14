namespace Oops.Services.Identity.Core.Exceptions;

public sealed class InvalidUsernameException : Exception
{
  public string Username { get; }

  public InvalidUsernameException(string username)
    : base(username)
  {
    Username = username;
  }
}
