using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthAssessment.Migrations
{
    public partial class changeFields5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormUserForm");

            migrationBuilder.DropTable(
                name: "UserUserForm");

            migrationBuilder.CreateIndex(
                name: "IX_UserForms_FormId",
                table: "UserForms",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_UserForms_UserId",
                table: "UserForms",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserForms_Forms_FormId",
                table: "UserForms",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserForms_Users_UserId",
                table: "UserForms",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserForms_Forms_FormId",
                table: "UserForms");

            migrationBuilder.DropForeignKey(
                name: "FK_UserForms_Users_UserId",
                table: "UserForms");

            migrationBuilder.DropIndex(
                name: "IX_UserForms_FormId",
                table: "UserForms");

            migrationBuilder.DropIndex(
                name: "IX_UserForms_UserId",
                table: "UserForms");

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
    }
}
