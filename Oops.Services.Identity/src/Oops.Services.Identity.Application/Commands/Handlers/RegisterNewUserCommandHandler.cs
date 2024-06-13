using Ops.Services.Library.Mediator;

namespace Oops.Services.Identity.Application.Commands.Handlers;

public sealed class RegisterNewUserCommandHandler
  : IRequestHandler<RegisterNewUserCommand, RegisterNewUserResult>
{
  public Task<RegisterNewUserResult> Handle(RegisterNewUserCommand request)
  {
    throw new NotImplementedException();
  }
}
