using Microsoft.EntityFrameworkCore.Migrations;

namespace PMS.Migrations
{
    public partial class templatetabtypefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tabs",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Title",
                table: "Tabs",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
