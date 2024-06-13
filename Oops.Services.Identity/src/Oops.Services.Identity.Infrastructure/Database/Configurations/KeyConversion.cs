using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oops.Services.Identity.Core.Entities;

namespace Oops.Services.Identity.Infrastructure.Database.Configurations;
public sealed class KeyConversion : ValueConverter<Key?, Guid?>
{
  public KeyConversion()
    : base(e => e == null ? null : e.Id,
      d => d == null ? null : new Key(d))
  {
  }
}
