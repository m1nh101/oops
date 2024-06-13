using Oops.Services.Identity.Core.Entities;
using Ops.Services.Library.Mediator;

namespace Oops.Services.Identity.Application.Commands;

public sealed record RegisterNewUserCommand(
  string Username,
  string Email,
  string GivenName,
  string Password,
  string ConfirmPassword,
  DateTime? Birthday,
  Gender? Gender) : IRequest<RegisterNewUserResult>;

public sealed record RegisterNewUserResult(
  string Id);
