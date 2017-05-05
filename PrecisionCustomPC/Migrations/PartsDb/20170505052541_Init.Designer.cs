using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PrecisionCustomPC.Models;
using PrecisionCustomPC;

namespace PrecisionCustomPC.Migrations.PartsDb
{
    [DbContext(typeof(PartsDbContext))]
    [Migration("20170505052541_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.Motherboard", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand")
                        .IsRequired();

                    b.Property<int>("MaxRAM");

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<int>("PCISlots");

                    b.Property<int>("Price");

                    b.Property<int>("RAMClass");

                    b.Property<int>("RamSlots");

                    b.Property<string>("Series");

                    b.Property<int>("Size");

                    b.Property<int>("USB3Slots");

                    b.HasKey("ID");

                    b.ToTable("Motherboards");
                });

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.Tower", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand")
                        .IsRequired();

                    b.Property<int>("FanCount");

                    b.Property<bool>("LiquidCooling");

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<int>("Price");

                    b.Property<string>("Series");

                    b.Property<int>("Size");

                    b.HasKey("ID");

                    b.ToTable("Towers");
                });

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.TowerColor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Color");

                    b.Property<string>("ColorHash");

                    b.Property<int?>("TowerID");

                    b.HasKey("ID");

                    b.HasIndex("TowerID");

                    b.ToTable("TowerColor");
                });

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.TowerImage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImagePath");

                    b.Property<int?>("TowerColorID");

                    b.HasKey("ID");

                    b.HasIndex("TowerColorID");

                    b.ToTable("TowerImage");
                });

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.TowerColor", b =>
                {
                    b.HasOne("PrecisionCustomPC.Models.PartsViewModels.Tower")
                        .WithMany("Colors")
                        .HasForeignKey("TowerID");
                });

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.TowerImage", b =>
                {
                    b.HasOne("PrecisionCustomPC.Models.PartsViewModels.TowerColor")
                        .WithMany("Images")
                        .HasForeignKey("TowerColorID");
                });
        }
    }
}
