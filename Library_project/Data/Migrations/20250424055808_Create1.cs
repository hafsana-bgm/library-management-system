using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_project.Data.Migrations
{
    /// <inheritdoc />
    public partial class Create1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookLebels",
                table: "BookLebels");

            migrationBuilder.RenameTable(
                name: "BookLebels",
                newName: "BooksLebels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BooksLebels",
                table: "BooksLebels",
                column: "BookLebelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BooksLebels",
                table: "BooksLebels");

            migrationBuilder.RenameTable(
                name: "BooksLebels",
                newName: "BookLebels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookLebels",
                table: "BookLebels",
                column: "BookLebelId");
        }
    }
}
