using Microsoft.EntityFrameworkCore.Migrations;

namespace PMS.Migrations
{
    public partial class templatetabkpicreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TemplateTabKpis",
                columns: table => new
                {
                    TabId = table.Column<int>(nullable: false),
                    TemplateId = table.Column<int>(nullable: false),
                    KpiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateTabKpis", x => new { x.TemplateId, x.TabId, x.KpiId });
                    table.ForeignKey(
                        name: "FK_TemplateTabKpis_Kpis_KpiId",
                        column: x => x.KpiId,
                        principalTable: "Kpis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateTabKpis_Tabs_TabId",
                        column: x => x.TabId,
                        principalTable: "Tabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateTabKpis_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemplateTabKpis_KpiId",
                table: "TemplateTabKpis",
                column: "KpiId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateTabKpis_TabId",
                table: "TemplateTabKpis",
                column: "TabId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemplateTabKpis");
        }
    }
}
