using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthAssessment.Migrations
{
    public partial class changeFields1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormQuestions_Forms_FormId",
                table: "FormQuestions");

            migrationBuilder.DropIndex(
                name: "IX_FormQuestions_FormId",
                table: "FormQuestions");

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

            migrationBuilder.CreateIndex(
                name: "IX_FormFormQuestion_FormsId",
                table: "FormFormQuestion",
                column: "FormsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormFormQuestion");

            migrationBuilder.CreateIndex(
                name: "IX_FormQuestions_FormId",
                table: "FormQuestions",
                column: "FormId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormQuestions_Forms_FormId",
                table: "FormQuestions",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
