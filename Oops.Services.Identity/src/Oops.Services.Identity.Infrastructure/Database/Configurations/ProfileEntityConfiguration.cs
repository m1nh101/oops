using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oops.Services.Identity.Core.Entities;

namespace Oops.Services.Identity.Infrastructure.Database.Configurations;

public sealed class ProfileEntityConfiguration : IEntityTypeConfiguration<Profile>
{
  public void Configure(EntityTypeBuilder<Profile> builder)
  {
    builder.ToTable("profiles");

    builder.HasKey(e => e.Id);

    builder.Property(e => e.Id)
      .HasColumnType("uuid")
      .HasColumnName("id")
      .HasDefaultValueSql("uuid_generate_v4()")
      .HasConversion<KeyConversion>();

    builder.Property(e => e.GivenName)
      .HasColumnType("varchar(256)")
      .HasColumnName("given_name")
      .HasMaxLength(256)
      .IsRequired();

    builder.Property(e => e.Birthday)
      .HasColumnName("birth_day")
      .HasColumnType("timestamp without time zone");

    builder.Property(e => e.CreatedAt)
      .HasColumnType("timestamp without time zone")
      .HasColumnName("created_at");

    builder.Property(e => e.LastModifiedAt)
      .HasColumnType("timestamp without time zone")
      .HasColumnName("last_modified_at")
      .IsRequired(false);

    builder.Property(e => e.ModifiedBy)
      .HasColumnType("uuid")
      .HasColumnName("modified_by")
      .HasConversion<KeyConversion>()
      .IsRequired(false);

    builder.Property(e => e.CreatedBy)
      .HasColumnType("uuid")
      .HasColumnName("created_by")
      .HasConversion<KeyConversion>()
      .IsRequired();

    builder.Property(e => e.UserId)
      .HasColumnName("user_id")
      .HasColumnType("uuid")
      .HasConversion<KeyConversion>();

    builder.HasOne(e => e.User)
      .WithOne(e => e.Profile)
      .HasForeignKey<Profile>(e => e.UserId);
  }
}
