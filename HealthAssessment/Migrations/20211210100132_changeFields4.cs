using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthAssessment.Migrations
{
    public partial class changeFields4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_UserForms_UserFormId",
                table: "Forms");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserForms_UserFormId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserFormId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Forms_UserFormId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "UserFormId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserFormId",
                table: "Forms");

            migrationBuilder.AddColumn<bool>(
                name: "Check",
                table: "UserForms",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "FormUserForm",
                columns: table => new
                {
                    FormsId = table.Column<int>(type: "integer", nullable: false),
                    UserFormsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormUserForm", x => new { x.FormsId, x.UserFormsId });
                    table.ForeignKey(
                        name: "FK_FormUserForm_Forms_FormsId",
                        column: x => x.FormsId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormUserForm_UserForms_UserFormsId",
                        column: x => x.UserFormsId,
                        principalTable: "UserForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserUserForm",
                columns: table => new
                {
                    UserFormsId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUserForm", x => new { x.UserFormsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserUserForm_UserForms_UserFormsId",
                        column: x => x.UserFormsId,
                        principalTable: "UserForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUserForm_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormUserForm_UserFormsId",
                table: "FormUserForm",
                column: "UserFormsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUserForm_UsersId",
                table: "UserUserForm",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormUserForm");

            migrationBuilder.DropTable(
                name: "UserUserForm");

            migrationBuilder.DropColumn(
                name: "Check",
                table: "UserForms");

            migrationBuilder.AddColumn<int>(
                name: "UserFormId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserFormId",
                table: "Forms",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserFormId",
                table: "Users",
                column: "UserFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_UserFormId",
                table: "Forms",
                column: "UserFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_UserForms_UserFormId",
                table: "Forms",
                column: "UserFormId",
                principalTable: "UserForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserForms_UserFormId",
                table: "Users",
                column: "UserFormId",
                principalTable: "UserForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
