using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HealthAssessment.Migrations
{
    public partial class changeFields3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_FormQuestions_FormQuestionId",
                table: "Forms");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_FormQuestions_FormQuestionId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "FormQuestions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_FormQuestionId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Forms_FormQuestionId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FormQuestionId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "FormQuestionId",
                table: "Forms");

            migrationBuilder.CreateTable(
                name: "FormQuestion",
                columns: table => new
                {
                    FormsId = table.Column<int>(type: "integer", nullable: false),
                    QuestionsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormQuestion", x => new { x.FormsId, x.QuestionsId });
                    table.ForeignKey(
                        name: "FK_FormQuestion_Forms_FormsId",
                        column: x => x.FormsId,
                        principalTable: "Forms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FormQuestion_Questions_QuestionsId",
                        column: x => x.QuestionsId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormQuestion_QuestionsId",
                table: "FormQuestion",
                column: "QuestionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormQuestion");

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

            migrationBuilder.CreateTable(
                name: "FormQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FormId = table.Column<int>(type: "integer", nullable: false),
                    QuestionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormQuestions", x => x.Id);
                });

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
        }
    }
}
