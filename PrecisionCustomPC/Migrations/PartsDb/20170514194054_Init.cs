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
                name: "Fans",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(nullable: false),
                    ColorModel = table.Column<int>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Series = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fans", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Memory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(nullable: false),
                    Class = table.Column<int>(nullable: false),
                    ColorModel = table.Column<int>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Series = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Speed = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Towers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(nullable: false),
                    ColorModel = table.Column<int>(nullable: false),
                    FanCount = table.Column<int>(nullable: false),
                    LiquidCooling = table.Column<bool>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    OpticalDrive = table.Column<bool>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Series = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VideoCards",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(nullable: false),
                    ColorModel = table.Column<int>(nullable: false),
                    Memory = table.Column<int>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Power = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Series = table.Column<string>(nullable: true),
                    Speed = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCards", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColorValue = table.Column<int>(nullable: false),
                    FanID = table.Column<int>(nullable: true),
                    MemoryID = table.Column<int>(nullable: true),
                    TowerID = table.Column<int>(nullable: true),
                    VideoCardID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Colors_Fans_FanID",
                        column: x => x.FanID,
                        principalTable: "Fans",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Colors_Memory_MemoryID",
                        column: x => x.MemoryID,
                        principalTable: "Memory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Colors_Towers_TowerID",
                        column: x => x.TowerID,
                        principalTable: "Towers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Colors_VideoCards_VideoCardID",
                        column: x => x.VideoCardID,
                        principalTable: "VideoCards",
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

            migrationBuilder.CreateTable(
                name: "Motherboards",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(nullable: false),
                    ColorID = table.Column<int>(nullable: true),
                    M2Slots = table.Column<int>(nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Motherboards_Colors_ColorID",
                        column: x => x.ColorID,
                        principalTable: "Colors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PowerSupplies",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(nullable: false),
                    ColorID = table.Column<int>(nullable: true),
                    Model = table.Column<string>(nullable: false),
                    Modular = table.Column<int>(nullable: false),
                    Power = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Series = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerSupplies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PowerSupplies_Colors_ColorID",
                        column: x => x.ColorID,
                        principalTable: "Colors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Processors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(nullable: false),
                    ColorID = table.Column<int>(nullable: true),
                    Cooler = table.Column<bool>(nullable: false),
                    Cores = table.Column<int>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Series = table.Column<string>(nullable: true),
                    Speed = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Processors_Colors_ColorID",
                        column: x => x.ColorID,
                        principalTable: "Colors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(nullable: false),
                    ColorID = table.Column<int>(nullable: true),
                    FormFactor = table.Column<int>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Series = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Storage_Colors_ColorID",
                        column: x => x.ColorID,
                        principalTable: "Colors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colors_FanID",
                table: "Colors",
                column: "FanID");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_MemoryID",
                table: "Colors",
                column: "MemoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_TowerID",
                table: "Colors",
                column: "TowerID");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_VideoCardID",
                table: "Colors",
                column: "VideoCardID");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ColorID",
                table: "Images",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_ColorID",
                table: "Motherboards",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_PowerSupplies_ColorID",
                table: "PowerSupplies",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_Processors_ColorID",
                table: "Processors",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_ColorID",
                table: "Storage",
                column: "ColorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropTable(
                name: "PowerSupplies");

            migrationBuilder.DropTable(
                name: "Processors");

            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Fans");

            migrationBuilder.DropTable(
                name: "Memory");

            migrationBuilder.DropTable(
                name: "Towers");

            migrationBuilder.DropTable(
                name: "VideoCards");
        }
    }
}
