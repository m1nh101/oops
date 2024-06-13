using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Oops.Services.Identity.Core.Entities;
using Oops.Services.Identity.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddSingleton<IPasswordValidator<User>, PasswordValidator<User>>();

builder.Services.AddDbContext<IdentityContext>(options =>
{
  var connectionString = builder.Configuration.GetConnectionString("IdentityDbConnection");

  options.UseNpgsql(connectionString,
    e => e.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName));
});


var app = builder.Build();

// Configure the HTTP request pipeline.

app.Run();