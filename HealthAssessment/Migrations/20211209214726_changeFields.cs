using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HealthAssessment.Migrations
{
    public partial class changeFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormQuestionQuestion_FormQuestions_FormQuestionsFormId",
                table: "FormQuestionQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_FormQuestions_Forms_FormId1",
                table: "FormQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFormResult_Forms_FormId",
                table: "UserFormResult");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFormResult_Questions_QuestionId",
                table: "UserFormResult");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFormResult_Users_UserId",
                table: "UserFormResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormQuestions",
                table: "FormQuestions");

            migrationBuilder.DropIndex(
                name: "IX_FormQuestions_FormId1",
                table: "FormQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFormResult",
                table: "UserFormResult");

            migrationBuilder.DropColumn(
                name: "FormId1",
                table: "FormQuestions");

            migrationBuilder.RenameTable(
                name: "UserFormResult",
                newName: "UserFormResults");

            migrationBuilder.RenameColumn(
                name: "FormQuestionsFormId",
                table: "FormQuestionQuestion",
                newName: "FormQuestionsId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFormResult_UserId",
                table: "UserFormResults",
                newName: "IX_UserFormResults_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFormResult_QuestionId",
                table: "UserFormResults",
                newName: "IX_UserFormResults_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFormResult_FormId",
                table: "UserFormResults",
                newName: "IX_UserFormResults_FormId");

            migrationBuilder.AlterColumn<int>(
                name: "FormId",
                table: "FormQuestions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FormQuestions",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormQuestions",
                table: "FormQuestions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFormResults",
                table: "UserFormResults",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FormQuestions_FormId",
                table: "FormQuestions",
                column: "FormId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormQuestionQuestion_FormQuestions_FormQuestionsId",
                table: "FormQuestionQuestion",
                column: "FormQuestionsId",
                principalTable: "FormQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FormQuestions_Forms_FormId",
                table: "FormQuestions",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFormResults_Forms_FormId",
                table: "UserFormResults",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFormResults_Questions_QuestionId",
                table: "UserFormResults",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFormResults_Users_UserId",
                table: "UserFormResults",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormQuestionQuestion_FormQuestions_FormQuestionsId",
                table: "FormQuestionQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_FormQuestions_Forms_FormId",
                table: "FormQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFormResults_Forms_FormId",
                table: "UserFormResults");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFormResults_Questions_QuestionId",
                table: "UserFormResults");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFormResults_Users_UserId",
                table: "UserFormResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormQuestions",
                table: "FormQuestions");

            migrationBuilder.DropIndex(
                name: "IX_FormQuestions_FormId",
                table: "FormQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFormResults",
                table: "UserFormResults");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FormQuestions");

            migrationBuilder.RenameTable(
                name: "UserFormResults",
                newName: "UserFormResult");

            migrationBuilder.RenameColumn(
                name: "FormQuestionsId",
                table: "FormQuestionQuestion",
                newName: "FormQuestionsFormId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFormResults_UserId",
                table: "UserFormResult",
                newName: "IX_UserFormResult_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFormResults_QuestionId",
                table: "UserFormResult",
                newName: "IX_UserFormResult_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFormResults_FormId",
                table: "UserFormResult",
                newName: "IX_UserFormResult_FormId");

            migrationBuilder.AlterColumn<int>(
                name: "FormId",
                table: "FormQuestions",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "FormId1",
                table: "FormQuestions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormQuestions",
                table: "FormQuestions",
                column: "FormId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFormResult",
                table: "UserFormResult",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FormQuestions_FormId1",
                table: "FormQuestions",
                column: "FormId1");

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
                name: "FK_UserFormResult_Forms_FormId",
                table: "UserFormResult",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFormResult_Questions_QuestionId",
                table: "UserFormResult",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFormResult_Users_UserId",
                table: "UserFormResult",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
