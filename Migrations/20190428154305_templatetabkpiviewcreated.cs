using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMS.Migrations
{
    public partial class templatetabkpiviewcreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplateTabKpis_Tabs_TabId",
                table: "TemplateTabKpis");

            migrationBuilder.DropForeignKey(
                name: "FK_TemplateTabKpis_Templates_TemplateId",
                table: "TemplateTabKpis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TemplateTabs",
                table: "TemplateTabs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TemplateTabKpis",
                table: "TemplateTabKpis");

            migrationBuilder.DropIndex(
                name: "IX_TemplateTabKpis_TabId",
                table: "TemplateTabKpis");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "TemplateTabKpis");

            migrationBuilder.RenameColumn(
                name: "TabId",
                table: "TemplateTabKpis",
                newName: "TemplateTabId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TemplateTabs",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Templates",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemplateTabs",
                table: "TemplateTabs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemplateTabKpis",
                table: "TemplateTabKpis",
                columns: new[] { "TemplateTabId", "KpiId" });

            migrationBuilder.CreateIndex(
                name: "IX_TemplateTabs_TemplateId",
                table: "TemplateTabs",
                column: "TemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateTabKpis_TemplateTabs_TemplateTabId",
                table: "TemplateTabKpis",
                column: "TemplateTabId",
                principalTable: "TemplateTabs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TemplateTabKpis_TemplateTabs_TemplateTabId",
                table: "TemplateTabKpis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TemplateTabs",
                table: "TemplateTabs");

            migrationBuilder.DropIndex(
                name: "IX_TemplateTabs_TemplateId",
                table: "TemplateTabs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TemplateTabKpis",
                table: "TemplateTabKpis");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TemplateTabs");

            migrationBuilder.RenameColumn(
                name: "TemplateTabId",
                table: "TemplateTabKpis",
                newName: "TabId");

            migrationBuilder.AddColumn<int>(
                name: "TemplateId",
                table: "TemplateTabKpis",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Templates",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemplateTabs",
                table: "TemplateTabs",
                columns: new[] { "TemplateId", "TabId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TemplateTabKpis",
                table: "TemplateTabKpis",
                columns: new[] { "TemplateId", "TabId", "KpiId" });

            migrationBuilder.CreateIndex(
                name: "IX_TemplateTabKpis_TabId",
                table: "TemplateTabKpis",
                column: "TabId");

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateTabKpis_Tabs_TabId",
                table: "TemplateTabKpis",
                column: "TabId",
                principalTable: "Tabs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TemplateTabKpis_Templates_TemplateId",
                table: "TemplateTabKpis",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
