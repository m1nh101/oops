namespace Oops.Services.Identity.Core.Exceptions;

public sealed class InvalidPasswordException : Exception
{
  public string Password { get; }

  public InvalidPasswordException(string password)
  {
    Password = password;
  }

  public InvalidPasswordException(string password, string message) 
    : base(message)
  {
    Password = password;
  }
}
