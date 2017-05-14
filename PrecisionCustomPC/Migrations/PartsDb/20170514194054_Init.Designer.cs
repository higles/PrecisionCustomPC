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
    [Migration("20170514194054_Init")]
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

                    b.Property<int>("ColorValue");

                    b.Property<int?>("FanID");

                    b.Property<int?>("MemoryID");

                    b.Property<int?>("TowerID");

                    b.Property<int?>("VideoCardID");

                    b.HasKey("ID");

                    b.HasIndex("FanID");

                    b.HasIndex("MemoryID");

                    b.HasIndex("TowerID");

                    b.HasIndex("VideoCardID");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.Fan", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand")
                        .IsRequired();

                    b.Property<int>("ColorModel");

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<int?>("Price")
                        .IsRequired();

                    b.Property<string>("Series");

                    b.Property<int>("Size");

                    b.HasKey("ID");

                    b.ToTable("Fans");
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

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.Memory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand")
                        .IsRequired();

                    b.Property<int>("Class");

                    b.Property<int>("ColorModel");

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<int?>("Price")
                        .IsRequired();

                    b.Property<string>("Series");

                    b.Property<int>("Size");

                    b.Property<float>("Speed");

                    b.HasKey("ID");

                    b.ToTable("Memory");
                });

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.Motherboard", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand")
                        .IsRequired();

                    b.Property<int?>("ColorID");

                    b.Property<int?>("M2Slots");

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

                    b.HasIndex("ColorID");

                    b.ToTable("Motherboards");
                });

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.PowerSupply", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand")
                        .IsRequired();

                    b.Property<int?>("ColorID");

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<int>("Modular");

                    b.Property<int>("Power");

                    b.Property<int?>("Price")
                        .IsRequired();

                    b.Property<string>("Series");

                    b.HasKey("ID");

                    b.HasIndex("ColorID");

                    b.ToTable("PowerSupplies");
                });

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.Processor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand")
                        .IsRequired();

                    b.Property<int?>("ColorID");

                    b.Property<bool>("Cooler");

                    b.Property<int>("Cores");

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<int?>("Price")
                        .IsRequired();

                    b.Property<string>("Series");

                    b.Property<float>("Speed");

                    b.HasKey("ID");

                    b.HasIndex("ColorID");

                    b.ToTable("Processors");
                });

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.Storage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand")
                        .IsRequired();

                    b.Property<int?>("ColorID");

                    b.Property<int>("FormFactor");

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<int?>("Price")
                        .IsRequired();

                    b.Property<string>("Series");

                    b.Property<int>("Size");

                    b.HasKey("ID");

                    b.HasIndex("ColorID");

                    b.ToTable("Storage");
                });

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.Tower", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand")
                        .IsRequired();

                    b.Property<int>("ColorModel");

                    b.Property<int?>("FanCount")
                        .IsRequired();

                    b.Property<bool?>("LiquidCooling")
                        .IsRequired();

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<bool?>("OpticalDrive");

                    b.Property<int?>("Price")
                        .IsRequired();

                    b.Property<string>("Series");

                    b.Property<int>("Size");

                    b.HasKey("ID");

                    b.ToTable("Towers");
                });

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.VideoCard", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand")
                        .IsRequired();

                    b.Property<int>("ColorModel");

                    b.Property<int>("Memory");

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<int>("Power");

                    b.Property<int?>("Price")
                        .IsRequired();

                    b.Property<string>("Series");

                    b.Property<float?>("Speed");

                    b.HasKey("ID");

                    b.ToTable("VideoCards");
                });

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.Color", b =>
                {
                    b.HasOne("PrecisionCustomPC.Models.PartsViewModels.Fan")
                        .WithMany("Colors")
                        .HasForeignKey("FanID");

                    b.HasOne("PrecisionCustomPC.Models.PartsViewModels.Memory")
                        .WithMany("Colors")
                        .HasForeignKey("MemoryID");

                    b.HasOne("PrecisionCustomPC.Models.PartsViewModels.Tower")
                        .WithMany("Colors")
                        .HasForeignKey("TowerID");

                    b.HasOne("PrecisionCustomPC.Models.PartsViewModels.VideoCard")
                        .WithMany("Colors")
                        .HasForeignKey("VideoCardID");
                });

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.Image", b =>
                {
                    b.HasOne("PrecisionCustomPC.Models.PartsViewModels.Color")
                        .WithMany("Images")
                        .HasForeignKey("ColorID");
                });

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.Motherboard", b =>
                {
                    b.HasOne("PrecisionCustomPC.Models.PartsViewModels.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorID");
                });

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.PowerSupply", b =>
                {
                    b.HasOne("PrecisionCustomPC.Models.PartsViewModels.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorID");
                });

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.Processor", b =>
                {
                    b.HasOne("PrecisionCustomPC.Models.PartsViewModels.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorID");
                });

            modelBuilder.Entity("PrecisionCustomPC.Models.PartsViewModels.Storage", b =>
                {
                    b.HasOne("PrecisionCustomPC.Models.PartsViewModels.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorID");
                });
        }
    }
}
