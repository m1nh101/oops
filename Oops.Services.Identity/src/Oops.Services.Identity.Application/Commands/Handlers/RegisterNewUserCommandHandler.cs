using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Oops.Services.Identity.Application.Contracts;
using Oops.Services.Identity.Application.Extensions;
using Oops.Services.Identity.Core.Entities;
using Oops.Services.Identity.Core.Exceptions;
using Ops.Services.Library.Mediator;

namespace Oops.Services.Identity.Application.Commands.Handlers;

public sealed class RegisterNewUserCommandHandler
  : IRequestHandler<RegisterNewUserCommand, RegisterNewUserResult>
{
  private readonly IIdentityDbContext _context;
  private readonly IPasswordHasher<User> _passwordHasher;
  private const string DEFAULT_ROLE_NAME = "default";
  private const Gender DEFAULT_GENDER = Gender.Other;
  private static readonly DateTime DEFAULT_BIRTHDAY = DateTime.Parse("1900-01-01");

  public RegisterNewUserCommandHandler(
    IIdentityDbContext context,
    IPasswordHasher<User> passwordHasher,
    IPasswordValidator<User> passwordValidator)
  {
    _context = context;
    _passwordHasher = passwordHasher;
  }

  public async Task<RegisterNewUserResult> Handle(RegisterNewUserCommand request)
  {
    var hasEmailUsed = await _context.Users.HasEmailUsed(request.Username);
    if (hasEmailUsed)
      throw new InvalidEmailException(request.Email);

    var hasUsernameUsed = await _context.Users.HasUsernameUsed(request.Username);
    if (hasUsernameUsed)
      throw new InvalidUsernameException(request.Username);

    var defaultRole = await _context.Roles.FirstOrDefaultAsync(e => e.Name == DEFAULT_ROLE_NAME);
    if (defaultRole == null)
      throw new InvalidRoleException(DEFAULT_ROLE_NAME);

    // skip password verify
    var user = new User(request.Username, request.Email);
    var profile = new Profile(request.GivenName, request.Birthday ?? DEFAULT_BIRTHDAY, request.Gender ?? DEFAULT_GENDER);
    var hashedPassword = _passwordHasher.HashPassword(user, request.Password);
    
    user.SetPassword(hashedPassword);
    user.AssociateToProfile(profile);
    user.AssignToRole(defaultRole);

    await _context.Users.AddAsync(user);
    await _context.SaveChangesAsync();

    return new(user.Id.ToString());
  }
}
