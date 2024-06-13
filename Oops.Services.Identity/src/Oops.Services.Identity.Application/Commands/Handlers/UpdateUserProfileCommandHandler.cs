using Ops.Services.Library.Mediator;

namespace Oops.Services.Identity.Application.Commands.Handlers;

public sealed class UpdateUserProfileCommandHandler
  : IRequestHandler<UpdateUserProfileCommand, UpdateUserProfileResult>
{
  public Task<UpdateUserProfileResult> Handle(UpdateUserProfileCommand request)
  {
    throw new NotImplementedException();
  }
}
