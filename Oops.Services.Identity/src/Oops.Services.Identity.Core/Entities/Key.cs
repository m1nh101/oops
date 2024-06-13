namespace Oops.Services.Identity.Core.Entities;

public record Key(Guid? Id)
{
  public override string ToString()
  {
    return Id.ToString() ?? "";
  }
}
