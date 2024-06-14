using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Oops.Services.Identity.Application.Contracts;
using Oops.Services.Identity.Application.Utils;
using Oops.Services.Identity.Core.Entities;
using Oops.Services.Identity.Core.Exceptions;
using Ops.Services.Library.Mediator;

namespace Oops.Services.Identity.Application.Commands.Handlers;

public sealed class AuthenticateUserCredentialCommandHandler
  : IRequestHandler<AuthenticateUserCredentialCommand, AuthenticateUserCredentialResult>
{
  private readonly IIdentityDbContext _context;
  private readonly IPasswordHasher<User> _passwordHasher;
  private readonly JwtTokenGenerator _jwtTokenGenerator;

  public AuthenticateUserCredentialCommandHandler(
    IIdentityDbContext context,
    IPasswordHasher<User> passwordHasher,
    JwtTokenGenerator jwtTokenGenerator)
  {
    _context = context;
    _passwordHasher = passwordHasher;
    _jwtTokenGenerator = jwtTokenGenerator;
  }

  public async Task<AuthenticateUserCredentialResult> Handle(AuthenticateUserCredentialCommand request)
  {
    var user = await _context.Users
      .AsNoTracking()
      .Include(e => e.Roles)
      .FirstOrDefaultAsync(e => e.Username == request.Username || e.Email == request.Username);
    if (user == null)
      throw new InvalidCredentialException(request.Username);

    var passwordVerification = _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);
    if (passwordVerification == PasswordVerificationResult.Failed)
      throw new InvalidPasswordException(request.Password, "Password wrong");

    var accessToken = _jwtTokenGenerator.Generate(user);

    return new(accessToken);
  }
}
