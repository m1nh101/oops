namespace Oops.Services.Identity.Core.Entities;

public interface IAuditable
{
  DateTime? LastModifiedAt { get; set; }
  Key? ModifiedBy { get; set; }
}

public interface ICreatable
{
  Key CreatedBy { get; set; }
  DateTime CreatedAt { get; set; }
}