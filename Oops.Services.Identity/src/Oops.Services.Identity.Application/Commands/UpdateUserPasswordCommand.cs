using Ops.Services.Library.Mediator;

namespace Oops.Services.Identity.Application.Commands;

public sealed record UpdateUserPasswordCommand(
  string OldPassword,
  string NewPassword,
  string ConfirmPassword) : IRequest<UpdateUserPasswordResult>
{
  public string Id { get; set; } = default!;
}

public sealed record UpdateUserPasswordResult(
  string Id);