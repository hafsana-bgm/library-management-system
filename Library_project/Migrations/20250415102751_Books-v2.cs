using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_project.Data.Migrations
{
    /// <inheritdoc />
    public partial class Booksv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Books",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Books",
                newName: "MyProperty");
        }
    }
}
