using Oops.Services.Identity.Core.Entities;
using Ops.Services.Library.Mediator;

namespace Oops.Services.Identity.Application.Commands;

public record UpdateUserProfileCommand(
  string GivenName,
  DateTime? Birthday,
  Gender? Gender) : IRequest<UpdateUserProfileResult>;

public record UpdateUserProfileResult(
  string Id);