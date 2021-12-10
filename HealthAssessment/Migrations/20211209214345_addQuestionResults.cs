using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HealthAssessment.Migrations
{
    public partial class addQuestionResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Form_UserForm_UserFormId",
                table: "Form");

            migrationBuilder.DropForeignKey(
                name: "FK_FormQuestion_Form_FormId1",
                table: "FormQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_FormQuestionQuestion_FormQuestion_FormQuestionsFormId",
                table: "FormQuestionQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUserForm_UserForm_UserFormsId",
                table: "UserUserForm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserForm",
                table: "UserForm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormQuestion",
                table: "FormQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Form",
                table: "Form");

            migrationBuilder.RenameTable(
                name: "UserForm",
                newName: "UserForms");

            migrationBuilder.RenameTable(
                name: "FormQuestion",
                newName: "FormQuestions");

            migrationBuilder.RenameTable(
                name: "Form",
                newName: "Forms");

            migrationBuilder.RenameIndex(
                name: "IX_FormQuestion_FormId1",
                table: "FormQuestions",
                newName: "IX_FormQuestions_FormId1");

            migrationBuilder.RenameIndex(
                name: "IX_Form_UserFormId",
                table: "Forms",
                newName: "IX_Forms_UserFormId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserForms",
                table: "UserForms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormQuestions",
                table: "FormQuestions",
                column: "FormId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Forms",
                table: "Forms",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserFormResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    FormId = table.Column<int>(type: "integer", nullable: false),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    Result = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFormResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFormResult_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFormResult_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFormResult_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFormResult_FormId",
                table: "UserFormResult",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFormResult_QuestionId",
                table: "UserFormResult",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFormResult_UserId",
                table: "UserFormResult",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormQuestionQuestion_FormQuestions_FormQuestionsFormId",
                table: "FormQuestionQuestion",
                column: "FormQuestionsFormId",
                principalTable: "FormQuestions",
                principalColumn: "FormId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FormQuestions_Forms_FormId1",
                table: "FormQuestions",
                column: "FormId1",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_UserForms_UserFormId",
                table: "Forms",
                column: "UserFormId",
                principalTable: "UserForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserUserForm_UserForms_UserFormsId",
                table: "UserUserForm",
                column: "UserFormsId",
                principalTable: "UserForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormQuestionQuestion_FormQuestions_FormQuestionsFormId",
                table: "FormQuestionQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_FormQuestions_Forms_FormId1",
                table: "FormQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_Forms_UserForms_UserFormId",
                table: "Forms");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUserForm_UserForms_UserFormsId",
                table: "UserUserForm");

            migrationBuilder.DropTable(
                name: "UserFormResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserForms",
                table: "UserForms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Forms",
                table: "Forms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormQuestions",
                table: "FormQuestions");

            migrationBuilder.RenameTable(
                name: "UserForms",
                newName: "UserForm");

            migrationBuilder.RenameTable(
                name: "Forms",
                newName: "Form");

            migrationBuilder.RenameTable(
                name: "FormQuestions",
                newName: "FormQuestion");

            migrationBuilder.RenameIndex(
                name: "IX_Forms_UserFormId",
                table: "Form",
                newName: "IX_Form_UserFormId");

            migrationBuilder.RenameIndex(
                name: "IX_FormQuestions_FormId1",
                table: "FormQuestion",
                newName: "IX_FormQuestion_FormId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserForm",
                table: "UserForm",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Form",
                table: "Form",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormQuestion",
                table: "FormQuestion",
                column: "FormId");

            migrationBuilder.AddForeignKey(
                name: "FK_Form_UserForm_UserFormId",
                table: "Form",
                column: "UserFormId",
                principalTable: "UserForm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormQuestion_Form_FormId1",
                table: "FormQuestion",
                column: "FormId1",
                principalTable: "Form",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FormQuestionQuestion_FormQuestion_FormQuestionsFormId",
                table: "FormQuestionQuestion",
                column: "FormQuestionsFormId",
                principalTable: "FormQuestion",
                principalColumn: "FormId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserUserForm_UserForm_UserFormsId",
                table: "UserUserForm",
                column: "UserFormsId",
                principalTable: "UserForm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
