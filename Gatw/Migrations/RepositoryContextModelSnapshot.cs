﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gatw.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Entities.Models.Device", b =>
                {
                    b.Property<int>("UID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DeviceId")
                        .UseIdentityColumn();

                    b.Property<Guid>("AssociatedGatewaySerialNumber")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Vendor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UID");

                    b.HasIndex("AssociatedGatewaySerialNumber");

                    b.ToTable("Devices");

                    b.HasData(
                        new
                        {
                            UID = 1,
                            AssociatedGatewaySerialNumber = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            DateCreated = new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = true,
                            Vendor = "Modem HP"
                        },
                        new
                        {
                            UID = 2,
                            AssociatedGatewaySerialNumber = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            DateCreated = new DateTime(2022, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = false,
                            Vendor = "Printer HP"
                        });
                });

            modelBuilder.Entity("Entities.Models.Gateway", b =>
                {
                    b.Property<Guid>("SerialNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("GatewaeyId");

                    b.Property<string>("IPv4Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SerialNumber");

                    b.ToTable("Gateways");

                    b.HasData(
                        new
                        {
                            SerialNumber = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                            IPv4Address = "10.8.77.120",
                            Name = "Gateway1"
                        },
                        new
                        {
                            SerialNumber = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                            IPv4Address = "10.8.77.130",
                            Name = "Gateway2"
                        });
                });

            modelBuilder.Entity("Entities.Models.Device", b =>
                {
                    b.HasOne("Entities.Models.Gateway", "Gateway")
                        .WithMany("Devices")
                        .HasForeignKey("AssociatedGatewaySerialNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gateway");
                });

            modelBuilder.Entity("Entities.Models.Gateway", b =>
                {
                    b.Navigation("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}
