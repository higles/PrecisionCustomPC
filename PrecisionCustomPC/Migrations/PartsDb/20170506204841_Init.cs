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
                    PCISlots = table.Column<int>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    RAMClass = table.Column<int>(nullable: false),
                    RamSlots = table.Column<int>(nullable: false),
                    Series = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    USB3Slots = table.Column<int>(nullable: true)
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
                name: "Colors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColorHash = table.Column<string>(maxLength: 7, nullable: false),
                    TowerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Colors_Towers_TowerID",
                        column: x => x.TowerID,
                        principalTable: "Towers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColorID = table.Column<int>(nullable: true),
                    ImagePath = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Images_Colors_ColorID",
                        column: x => x.ColorID,
                        principalTable: "Colors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colors_TowerID",
                table: "Colors",
                column: "TowerID");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ColorID",
                table: "Images",
                column: "ColorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Towers");
        }
    }
}
