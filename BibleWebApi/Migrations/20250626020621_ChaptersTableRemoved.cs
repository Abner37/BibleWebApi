using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibleWebApi.Migrations
{
    /// <inheritdoc />
    public partial class ChaptersTableRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Verses_Chapters_ChapterId",
                table: "Verses");

            migrationBuilder.DropTable(
                name: "Chapters");

            migrationBuilder.DropIndex(
                name: "IX_Verses_ChapterId",
                table: "Verses");

            migrationBuilder.RenameColumn(
                name: "ChapterId",
                table: "Verses",
                newName: "ChapterNumber");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Verses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChaptersCount",
                table: "Books",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Verses_BookId",
                table: "Verses",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Verses_Books_BookId",
                table: "Verses",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Verses_Books_BookId",
                table: "Verses");

            migrationBuilder.DropIndex(
                name: "IX_Verses_BookId",
                table: "Verses");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Verses");

            migrationBuilder.DropColumn(
                name: "ChaptersCount",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "ChapterNumber",
                table: "Verses",
                newName: "ChapterId");

            migrationBuilder.CreateTable(
                name: "Chapters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    Number = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chapters_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Verses_ChapterId",
                table: "Verses",
                column: "ChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_Chapters_BookId",
                table: "Chapters",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Verses_Chapters_ChapterId",
                table: "Verses",
                column: "ChapterId",
                principalTable: "Chapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
