namespace Oops.Services.Identity.Core.Exceptions;

public sealed class InvalidEmailException : Exception
{
  public string Email { get; }

  public InvalidEmailException(string email)
  {
    Email = email;
  }
}
