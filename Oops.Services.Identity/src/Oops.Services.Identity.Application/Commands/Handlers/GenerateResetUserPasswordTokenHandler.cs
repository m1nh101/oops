using Ops.Services.Library.Mediator;

namespace Oops.Services.Identity.Application.Commands.Handlers;

public sealed class GenerateResetUserPasswordTokenHandler
  : IRequestHandler<GenerateResetUserPasswordTokenCommand, GenerateResetUserPasswordTokenResult>
{
  public Task<GenerateResetUserPasswordTokenResult> Handle(GenerateResetUserPasswordTokenCommand request)
  {
    throw new NotImplementedException();
  }
}
