using Ops.Services.Library.Mediator;

namespace Oops.Services.Identity.Application.Commands;

public sealed record AuthenticateUserCredentialCommand(
  string Username,
  string Password) : IRequest<AuthenticateUserCredentialResult>;

public sealed record AuthenticateUserCredentialResult(
  string Token);