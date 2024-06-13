using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oops.Services.Identity.Core.Entities;

namespace Oops.Services.Identity.Infrastructure.Database.Configurations;

public sealed class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(EntityTypeBuilder<User> builder)
  {
    builder.ToTable("users");

    builder.HasKey(e => e.Id);

    builder.Property(e => e.Id)
      .HasColumnType("uuid")
      .HasDefaultValueSql("uuid_generate_v4()")
      .HasConversion<KeyConversion>();

    builder.Property(e => e.Username)
      .HasColumnType("varchar(256)")
      .HasMaxLength(256)
      .IsRequired(true);

    builder.Property(e => e.Email)
      .HasColumnType("varchar(256)")
      .HasMaxLength(256)
      .IsRequired(true);

    builder.Property(e => e.Password)
      .HasColumnType("varchar(512)")
      .HasMaxLength(512)
      .IsRequired(true);

    builder.Property(e => e.CreatedAt)
      .HasColumnName("created_at")
      .HasColumnType("timestamp without time zone");

    builder.Property(e => e.LastModifiedAt)
      .HasColumnType("timestamp without time zone")
      .HasColumnName("last_modified_at");

    builder.Property(e => e.ModifiedBy)
      .HasColumnType("uuid")
      .HasColumnName("modified_by")
      .HasConversion(e => e == null ? null : e.Id, d => d == null ? null : new Key(d))
      .IsRequired(false);

    builder.Property(e => e.CreatedBy)
      .HasColumnType("uuid")
      .HasColumnName("created_by")
      .HasConversion<KeyConversion>()
      .IsRequired();

    builder.HasIndex(e => e.Email)
      .IsUnique();

    builder.HasIndex(e => e.Username)
      .IsUnique();

    builder.HasMany(e => e.Roles)
      .WithMany(e => e.Users)
      .UsingEntity<UserRole>(
        l => l
          .HasOne(d => d.Role)
          .WithMany(d => d.UserRoles)
          .HasForeignKey(d => d.RoleId),
        r => r
          .HasOne(d => d.User)
          .WithMany(d => d.UserRoles)
          .HasForeignKey(d => d.UserId),
        t =>
        {
          t.ToTable("user_roles");
          t.HasKey(k => new { k.RoleId, k.UserId });

          t.Property(e => e.UserId)
            .HasConversion<KeyConversion>();

          t.Property(e => e.RoleId)
            .HasConversion<KeyConversion>();
        });
  }
}
