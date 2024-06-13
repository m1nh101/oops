using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oops.Services.Identity.Core.Entities;

namespace Oops.Services.Identity.Infrastructure.Database.Configurations;

public sealed class RoleEntityConfiguration : IEntityTypeConfiguration<Role>
{
  public void Configure(EntityTypeBuilder<Role> builder)
  {
    builder.ToTable("roles");

    builder.HasKey(e => e.Id);

    builder.Property(e => e.Id)
      .HasColumnType("uuid")
      .HasDefaultValueSql("uuid_generate_v4()")
      .HasConversion<KeyConversion>();

    builder.Property(e => e.Name)
      .HasColumnType("varchar(256)")
      .HasMaxLength(256)
      .IsRequired(true);
  }
}
