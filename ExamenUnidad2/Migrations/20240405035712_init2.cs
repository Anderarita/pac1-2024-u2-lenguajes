using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenUnidad2.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Resulatdo",
                schema: "transactional",
                table: "IMC",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resulatdo",
                schema: "transactional",
                table: "IMC");
        }
    }
}
