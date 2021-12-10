using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HealthAssessment.Migrations
{
    public partial class changeFields6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserForms",
                table: "UserForms");

            migrationBuilder.DropIndex(
                name: "IX_UserForms_UserId",
                table: "UserForms");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserForms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserForms",
                table: "UserForms",
                columns: new[] { "UserId", "FormId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserForms",
                table: "UserForms");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserForms",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserForms",
                table: "UserForms",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserForms_UserId",
                table: "UserForms",
                column: "UserId");
        }
    }
}
