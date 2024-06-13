using Ops.Services.Library.Mediator;

namespace Oops.Services.Identity.Application.Commands;

public sealed record GenerateResetUserPasswordTokenCommand(
  string Email) : IRequest<GenerateResetUserPasswordTokenResult>;

public sealed record GenerateResetUserPasswordTokenResult(
  bool EmailSent);