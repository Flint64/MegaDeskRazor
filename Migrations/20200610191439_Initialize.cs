using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDeskRazor.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NumDrawers",
                columns: table => new
                {
                    NumDrawersId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfDrawers = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumDrawers", x => x.NumDrawersId);
                });

            migrationBuilder.CreateTable(
                name: "RushOption",
                columns: table => new
                {
                    RushOptionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RushOptionName = table.Column<string>(nullable: true),
                    PriceUnder1000 = table.Column<decimal>(nullable: false),
                    PriceBetween1000And2000 = table.Column<decimal>(nullable: false),
                    PriceOver2000 = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RushOption", x => x.RushOptionId);
                });

            migrationBuilder.CreateTable(
                name: "SurfaceMaterial",
                columns: table => new
                {
                    SurfaceMaterialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurfaceMaterialName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurfaceMaterial", x => x.SurfaceMaterialId);
                });

            migrationBuilder.CreateTable(
                name: "Desk",
                columns: table => new
                {
                    DeskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Depth = table.Column<decimal>(nullable: false),
                    Width = table.Column<decimal>(nullable: false),
                    SurfaceArea = table.Column<decimal>(nullable: false),
                    NumDrawersId = table.Column<int>(nullable: false),
                    SurfaceMaterialId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desk", x => x.DeskId);
                    table.ForeignKey(
                        name: "FK_Desk_NumDrawers_NumDrawersId",
                        column: x => x.NumDrawersId,
                        principalTable: "NumDrawers",
                        principalColumn: "NumDrawersId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Desk_SurfaceMaterial_SurfaceMaterialId",
                        column: x => x.SurfaceMaterialId,
                        principalTable: "SurfaceMaterial",
                        principalColumn: "SurfaceMaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeskQuote",
                columns: table => new
                {
                    DeskQuoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentDate = table.Column<DateTime>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    DeskId = table.Column<int>(nullable: false),
                    RushOptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeskQuote", x => x.DeskQuoteId);
                    table.ForeignKey(
                        name: "FK_DeskQuote_Desk_DeskId",
                        column: x => x.DeskId,
                        principalTable: "Desk",
                        principalColumn: "DeskId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeskQuote_RushOption_RushOptionId",
                        column: x => x.RushOptionId,
                        principalTable: "RushOption",
                        principalColumn: "RushOptionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desk_NumDrawersId",
                table: "Desk",
                column: "NumDrawersId");

            migrationBuilder.CreateIndex(
                name: "IX_Desk_SurfaceMaterialId",
                table: "Desk",
                column: "SurfaceMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_DeskQuote_DeskId",
                table: "DeskQuote",
                column: "DeskId");

            migrationBuilder.CreateIndex(
                name: "IX_DeskQuote_RushOptionId",
                table: "DeskQuote",
                column: "RushOptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeskQuote");

            migrationBuilder.DropTable(
                name: "Desk");

            migrationBuilder.DropTable(
                name: "RushOption");

            migrationBuilder.DropTable(
                name: "NumDrawers");

            migrationBuilder.DropTable(
                name: "SurfaceMaterial");
        }
    }
}
