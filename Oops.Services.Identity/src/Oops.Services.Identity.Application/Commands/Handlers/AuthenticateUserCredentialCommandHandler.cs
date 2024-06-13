using Ops.Services.Library.Mediator;

namespace Oops.Services.Identity.Application.Commands.Handlers;

public sealed class AuthenticateUserCredentialCommandHandler
  : IRequestHandler<AuthenticateUserCredentialCommand, AuthenticateUserCredentialResult>
{
  public Task<AuthenticateUserCredentialResult> Handle(AuthenticateUserCredentialCommand request)
  {
    throw new NotImplementedException();
  }
}
