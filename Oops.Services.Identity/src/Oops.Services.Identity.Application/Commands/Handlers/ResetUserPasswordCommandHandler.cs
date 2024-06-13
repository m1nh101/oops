using Ops.Services.Library.Mediator;

namespace Oops.Services.Identity.Application.Commands.Handlers;

public sealed class ResetUserPasswordCommandHandler
  : IRequestHandler<ResetUserPasswordCommand, ResetUserPasswordResult>
{
  public Task<ResetUserPasswordResult> Handle(ResetUserPasswordCommand request)
  {
    throw new NotImplementedException();
  }
}
