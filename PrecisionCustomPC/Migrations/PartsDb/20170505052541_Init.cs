using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PrecisionCustomPC.Migrations.PartsDb
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motherboards",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(nullable: false),
                    MaxRAM = table.Column<int>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    PCISlots = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    RAMClass = table.Column<int>(nullable: false),
                    RamSlots = table.Column<int>(nullable: false),
                    Series = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    USB3Slots = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboards", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Towers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(nullable: false),
                    FanCount = table.Column<int>(nullable: false),
                    LiquidCooling = table.Column<bool>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Series = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TowerColor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Color = table.Column<string>(nullable: true),
                    ColorHash = table.Column<string>(nullable: true),
                    TowerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TowerColor", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TowerColor_Towers_TowerID",
                        column: x => x.TowerID,
                        principalTable: "Towers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TowerImage",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImagePath = table.Column<string>(nullable: true),
                    TowerColorID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TowerImage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TowerImage_TowerColor_TowerColorID",
                        column: x => x.TowerColorID,
                        principalTable: "TowerColor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TowerColor_TowerID",
                table: "TowerColor",
                column: "TowerID");

            migrationBuilder.CreateIndex(
                name: "IX_TowerImage_TowerColorID",
                table: "TowerImage",
                column: "TowerColorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropTable(
                name: "TowerImage");

            migrationBuilder.DropTable(
                name: "TowerColor");

            migrationBuilder.DropTable(
                name: "Towers");
        }
    }
}
