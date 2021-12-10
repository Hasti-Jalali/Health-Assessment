using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthAssessment.Migrations
{
    public partial class changeFields2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormFormQuestion");

            migrationBuilder.DropTable(
                name: "FormQuestionQuestion");

            migrationBuilder.DropTable(
                name: "UserUserForm");

            migrationBuilder.AddColumn<int>(
                name: "UserFormId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FormQuestionId",
                table: "Questions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FormQuestionId",
                table: "Forms",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserFormId",
                table: "Users",
                column: "UserFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_FormQuestionId",
                table: "Questions",
                column: "FormQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_FormQuestionId",
                table: "Forms",
                column: "FormQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_FormQuestions_FormQuestionId",
                table: "Forms",
                column: "FormQuestionId",
                principalTable: "FormQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_FormQuestions_FormQuestionId",
                table: "Questions",
                column: "FormQuestionId",
                principalTable: "FormQuestions",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_FormQuestions_FormQuestionId",
                table: "Forms");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_FormQuestions_FormQuestionId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserForms_UserFormId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserFormId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Questions_FormQuestionId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Forms_FormQuestionId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "UserFormId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FormQuestionId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "FormQuestionId",
                table: "Forms");

            migrationBuilder.CreateTable(
                name: "FormFormQuestion",
                columns: table => new
                {
                    FormQuestionsId = table.Column<int>(type: "integer", nullable: false),
                    FormsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormFormQuestion", x => new { x.FormQuestionsId, x.FormsId });
                    table.ForeignKey(
                        name: "FK_FormFormQuestion_FormQuestions_FormQuestionsId",
                        column: x => x.FormQuestionsId,
                        principalTable: "FormQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormFormQuestion_Forms_FormsId",
                        column: x => x.FormsId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormQuestionQuestion",
                columns: table => new
                {
                    FormQuestionsId = table.Column<int>(type: "integer", nullable: false),
                    QuestionsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormQuestionQuestion", x => new { x.FormQuestionsId, x.QuestionsId });
                    table.ForeignKey(
                        name: "FK_FormQuestionQuestion_FormQuestions_FormQuestionsId",
                        column: x => x.FormQuestionsId,
                        principalTable: "FormQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormQuestionQuestion_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
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
                name: "IX_FormFormQuestion_FormsId",
                table: "FormFormQuestion",
                column: "FormsId");

            migrationBuilder.CreateIndex(
                name: "IX_FormQuestionQuestion_QuestionsId",
                table: "FormQuestionQuestion",
                column: "QuestionsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUserForm_UsersId",
                table: "UserUserForm",
                column: "UsersId");
        }
    }
}
