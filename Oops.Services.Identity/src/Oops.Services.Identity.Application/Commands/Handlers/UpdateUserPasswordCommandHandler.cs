using Ops.Services.Library.Mediator;

namespace Oops.Services.Identity.Application.Commands.Handlers;

public sealed class UpdateUserPasswordCommandHandler
  : IRequestHandler<UpdateUserPasswordCommand, UpdateUserPasswordResult>
{
  public Task<UpdateUserPasswordResult> Handle(UpdateUserPasswordCommand request)
  {
    throw new NotImplementedException();
  }
}
