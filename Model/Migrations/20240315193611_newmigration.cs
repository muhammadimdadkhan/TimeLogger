using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class newmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliverableType",
                table: "TimeLogs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DrawingNumber",
                table: "TimeLogs",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ERFNumber",
                table: "TimeLogs",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeliverableType",
                table: "TimeLogs");

            migrationBuilder.DropColumn(
                name: "DrawingNumber",
                table: "TimeLogs");

            migrationBuilder.DropColumn(
                name: "ERFNumber",
                table: "TimeLogs");
        }
    }
}
