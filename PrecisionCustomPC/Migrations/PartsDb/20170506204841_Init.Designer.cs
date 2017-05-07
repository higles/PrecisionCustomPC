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
    [Migration("20170506204841_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.Color", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ColorHash")
                        .IsRequired()
                        .HasMaxLength(7);

                    b.Property<int?>("TowerID");

                    b.HasKey("ID");

                    b.HasIndex("TowerID");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.Image", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ColorID");

                    b.Property<string>("ImagePath")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("ColorID");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.Motherboard", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand")
                        .IsRequired();

                    b.Property<int>("MaxRAM");

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<int?>("PCISlots");

                    b.Property<int?>("Price")
                        .IsRequired();

                    b.Property<int>("RAMClass");

                    b.Property<int?>("RamSlots")
                        .IsRequired();

                    b.Property<string>("Series");

                    b.Property<int>("Size");

                    b.Property<int?>("USB3Slots");

                    b.HasKey("ID");

                    b.ToTable("Motherboards");
                });

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.Tower", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand")
                        .IsRequired();

                    b.Property<int?>("FanCount")
                        .IsRequired();

                    b.Property<bool?>("LiquidCooling")
                        .IsRequired();

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<int?>("Price")
                        .IsRequired();

                    b.Property<string>("Series");

                    b.Property<int>("Size");

                    b.HasKey("ID");

                    b.ToTable("Towers");
                });

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.Color", b =>
                {
                    b.HasOne("PrecisionCustomPC.Models.PartsViewModels.Tower")
                        .WithMany("Colors")
                        .HasForeignKey("TowerID");
                });

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.Image", b =>
                {
                    b.HasOne("PrecisionCustomPC.Models.PartsViewModels.Color")
                        .WithMany("Images")
                        .HasForeignKey("ColorID");
                });
        }
    }
}
