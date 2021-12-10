using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthAssessment.Migrations
{
    public partial class changeFields9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormQuestionQuestion");

            migrationBuilder.AddForeignKey(
                name: "FK_FormQuestions_Questions_QuestionId",
                table: "FormQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormQuestions_Questions_QuestionId",
                table: "FormQuestions");

            migrationBuilder.CreateTable(
                name: "FormQuestionQuestion",
                columns: table => new
                {
                    QuestionsId = table.Column<int>(type: "integer", nullable: false),
                    FormQuestionsQuestionId = table.Column<int>(type: "integer", nullable: false),
                    FormQuestionsFormId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormQuestionQuestion", x => new { x.QuestionsId, x.FormQuestionsQuestionId, x.FormQuestionsFormId });
                    table.ForeignKey(
                        name: "FK_FormQuestionQuestion_FormQuestions_FormQuestionsQuestionId_~",
                        columns: x => new { x.FormQuestionsQuestionId, x.FormQuestionsFormId },
                        principalTable: "FormQuestions",
                        principalColumns: new[] { "QuestionId", "FormId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormQuestionQuestion_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormQuestionQuestion_FormQuestionsQuestionId_FormQuestionsF~",
                table: "FormQuestionQuestion",
                columns: new[] { "FormQuestionsQuestionId", "FormQuestionsFormId" });
        }
    }
}
