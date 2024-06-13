using Ops.Services.Library.Mediator;

namespace Oops.Services.Identity.Application.Commands;

public sealed record ResetUserPasswordCommand(
  string ResetPasswordToken,
  string NewPassword,
  string ConfirmPassword) : IRequest<ResetUserPasswordResult>;

public sealed record ResetUserPasswordResult(
  string Id);
