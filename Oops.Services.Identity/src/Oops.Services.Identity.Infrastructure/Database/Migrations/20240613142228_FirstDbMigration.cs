using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oops.Services.Identity.Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class FirstDbMigration : Migration
{
  /// <inheritdoc />
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.CreateTable(
        name: "roles",
        columns: table => new
        {
          Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
          Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_roles", x => x.Id);
        });

    migrationBuilder.CreateTable(
        name: "users",
        columns: table => new
        {
          Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
          Username = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
          Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
          Password = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false),
          created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
          last_modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
          created_by = table.Column<Guid>(type: "uuid", nullable: false),
          modified_by = table.Column<Guid>(type: "uuid", nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_users", x => x.Id);
        });

    migrationBuilder.CreateTable(
        name: "profiles",
        columns: table => new
        {
          id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
          given_name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
          birth_day = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
          Gender = table.Column<byte>(type: "smallint", nullable: false),
          created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
          last_modified_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
          created_by = table.Column<Guid>(type: "uuid", nullable: false),
          modified_by = table.Column<Guid>(type: "uuid", nullable: true),
          user_id = table.Column<Guid>(type: "uuid", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_profiles", x => x.id);
          table.ForeignKey(
                    name: "FK_profiles_users_user_id",
                    column: x => x.user_id,
                    principalTable: "users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
        });

    migrationBuilder.CreateTable(
        name: "user_roles",
        columns: table => new
        {
          UserId = table.Column<Guid>(type: "uuid", nullable: false),
          RoleId = table.Column<Guid>(type: "uuid", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_user_roles", x => new { x.RoleId, x.UserId });
          table.ForeignKey(
                    name: "FK_user_roles_roles_RoleId",
                    column: x => x.RoleId,
                    principalTable: "roles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
          table.ForeignKey(
                    name: "FK_user_roles_users_UserId",
                    column: x => x.UserId,
                    principalTable: "users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
        });

    migrationBuilder.CreateIndex(
        name: "IX_profiles_user_id",
        table: "profiles",
        column: "user_id",
        unique: true);

    migrationBuilder.CreateIndex(
        name: "IX_user_roles_UserId",
        table: "user_roles",
        column: "UserId");

    migrationBuilder.CreateIndex(
        name: "IX_users_Email",
        table: "users",
        column: "Email",
        unique: true);

    migrationBuilder.CreateIndex(
        name: "IX_users_Username",
        table: "users",
        column: "Username",
        unique: true);
  }

  /// <inheritdoc />
  protected override void Down(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.DropTable(
        name: "profiles");

    migrationBuilder.DropTable(
        name: "user_roles");

    migrationBuilder.DropTable(
        name: "roles");

    migrationBuilder.DropTable(
        name: "users");
  }
}
