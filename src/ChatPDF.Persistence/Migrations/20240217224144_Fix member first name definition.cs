using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Codefastly.ChatPDF.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Fixmemberfirstnamedefinition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstNam",
                table: "Members",
                newName: "FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Members",
                newName: "FirstNam");
        }
    }
}
