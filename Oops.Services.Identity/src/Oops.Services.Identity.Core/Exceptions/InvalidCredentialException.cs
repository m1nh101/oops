namespace Oops.Services.Identity.Core.Exceptions;

public sealed class InvalidCredentialException : Exception
{
  public string Credential { get; }

  public InvalidCredentialException(string credential)
  {
    Credential = credential;
  }
}
