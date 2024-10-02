﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OpenEMS.Infrastructure.Persistence;

#nullable disable

namespace OpenEMS.Infrastructure.Persistence.EntityFramework.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OpenEMS.Analytics.ElectricityMeterSample", b =>
                {
                    b.Property<long>("_PK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("_PK"));

                    b.Property<double?>("CurrentPower")
                        .HasColumnType("double precision");

                    b.Property<string>("CurrentPowerDirection")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ElectricityMeterId")
                        .HasColumnType("uuid");

                    b.Property<string>("OwnedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double?>("TotalEnergyConsumption")
                        .HasColumnType("double precision");

                    b.Property<double?>("TotalEnergyFeedIn")
                        .HasColumnType("double precision");

                    b.HasKey("_PK");

                    b.HasIndex("OwnedBy");

                    b.HasIndex("Timestamp");

                    b.ToTable("ElectricityMeterSamples");
                });

            modelBuilder.Entity("OpenEMS.Analytics.ProducerSample", b =>
                {
                    b.Property<long>("_PK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("_PK"));

                    b.Property<double?>("CurrentPowerProduction")
                        .HasColumnType("double precision");

                    b.Property<string>("OwnedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ProducerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double?>("TotalEnergyProduction")
                        .HasColumnType("double precision");

                    b.HasKey("_PK");

                    b.HasIndex("OwnedBy");

                    b.HasIndex("Timestamp");

                    b.ToTable("ProducerSamples");
                });

            modelBuilder.Entity("OpenEMS.Analytics.SwitchConsumerSample", b =>
                {
                    b.Property<long>("_PK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("_PK"));

                    b.Property<double?>("CurrentPowerConsumption")
                        .HasColumnType("double precision");

                    b.Property<string>("OwnedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SwitchConsumerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double?>("TotalEnergyConsumption")
                        .HasColumnType("double precision");

                    b.HasKey("_PK");

                    b.HasIndex("OwnedBy");

                    b.HasIndex("Timestamp");

                    b.ToTable("SwitchConsumerSamples");
                });

            modelBuilder.Entity("OpenEMS.Domain.Consumers.SwitchConsumer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<double?>("CurrentPowerConsumption")
                        .HasColumnType("double precision");

                    b.Property<double?>("MaximumPowerConsumption")
                        .HasColumnType("double precision");

                    b.Property<string>("Mode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OwnedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SwitchStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OwnedBy");

                    b.ToTable("SwitchConsumers");
                });

            modelBuilder.Entity("OpenEMS.Domain.Meters.ElectricityMeter", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<double?>("CurrentPower")
                        .HasColumnType("double precision");

                    b.Property<string>("CurrentPowerDirection")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double?>("MaximumPowerConsumption")
                        .HasColumnType("double precision");

                    b.Property<double?>("MaximumPowerFeedIn")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OwnedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OwnedBy");

                    b.ToTable("ElectricityMeters");
                });

            modelBuilder.Entity("OpenEMS.Domain.Producers.Producer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<double?>("CurrentPowerProduction")
                        .HasColumnType("double precision");

                    b.Property<double?>("MaximumPowerProduction")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OwnedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OwnedBy");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("OpenEMS.Integrations.Shelly.Domain.GrantedShellyDevice", b =>
                {
                    b.Property<int>("_PK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("_PK"));

                    b.Property<string>("DeviceCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DeviceId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DeviceType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Host")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Index")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OwnedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("_PK");

                    b.HasIndex("OwnedBy");

                    b.HasIndex("DeviceId", "Index")
                        .IsUnique();

                    b.ToTable("GrantedShellyDevices");
                });

            modelBuilder.Entity("OpenEMS.Domain.Consumers.SwitchConsumer", b =>
                {
                    b.OwnsOne("OpenEMS.Domain.IntegrationIdentifier", "Integration", b1 =>
                        {
                            b1.Property<Guid>("SwitchConsumerId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Device")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Integration")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("SwitchConsumerId");

                            b1.HasIndex("Integration", "Device")
                                .IsUnique();

                            b1.ToTable("SwitchConsumers");

                            b1.WithOwner()
                                .HasForeignKey("SwitchConsumerId");
                        });

                    b.OwnsOne("OpenEMS.Domain.TotalEnergy", "TotalEnergyConsumption", b1 =>
                        {
                            b1.Property<Guid>("SwitchConsumerId")
                                .HasColumnType("uuid");

                            b1.Property<double>("LastReported")
                                .HasColumnType("double precision");

                            b1.Property<double>("Value")
                                .HasColumnType("double precision");

                            b1.HasKey("SwitchConsumerId");

                            b1.ToTable("SwitchConsumers");

                            b1.WithOwner()
                                .HasForeignKey("SwitchConsumerId");
                        });

                    b.OwnsOne("OpenEMS.Domain.Consumers.SwitchConsumerSmartModeConfiguration", "SmartModeConfiguration", b1 =>
                        {
                            b1.Property<Guid>("SwitchConsumerId")
                                .HasColumnType("uuid");

                            b1.Property<TimeSpan>("MinimaleEinschaltdauer")
                                .HasColumnType("interval");

                            b1.Property<double>("Nennleistung")
                                .HasColumnType("double precision");

                            b1.Property<TimeSpan>("Wiedereinschaltverzögerung")
                                .HasColumnType("interval");

                            b1.HasKey("SwitchConsumerId");

                            b1.ToTable("SwitchConsumers");

                            b1.WithOwner()
                                .HasForeignKey("SwitchConsumerId");
                        });

                    b.Navigation("Integration")
                        .IsRequired();

                    b.Navigation("SmartModeConfiguration")
                        .IsRequired();

                    b.Navigation("TotalEnergyConsumption");
                });

            modelBuilder.Entity("OpenEMS.Domain.Meters.ElectricityMeter", b =>
                {
                    b.OwnsOne("OpenEMS.Domain.IntegrationIdentifier", "Integration", b1 =>
                        {
                            b1.Property<Guid>("ElectricityMeterId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Device")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Integration")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("ElectricityMeterId");

                            b1.HasIndex("Integration", "Device")
                                .IsUnique();

                            b1.ToTable("ElectricityMeters");

                            b1.WithOwner()
                                .HasForeignKey("ElectricityMeterId");
                        });

                    b.OwnsOne("OpenEMS.Domain.TotalEnergy", "TotalEnergyConsumption", b1 =>
                        {
                            b1.Property<Guid>("ElectricityMeterId")
                                .HasColumnType("uuid");

                            b1.Property<double>("LastReported")
                                .HasColumnType("double precision");

                            b1.Property<double>("Value")
                                .HasColumnType("double precision");

                            b1.HasKey("ElectricityMeterId");

                            b1.ToTable("ElectricityMeters");

                            b1.WithOwner()
                                .HasForeignKey("ElectricityMeterId");
                        });

                    b.OwnsOne("OpenEMS.Domain.TotalEnergy", "TotalEnergyFeedIn", b1 =>
                        {
                            b1.Property<Guid>("ElectricityMeterId")
                                .HasColumnType("uuid");

                            b1.Property<double>("LastReported")
                                .HasColumnType("double precision");

                            b1.Property<double>("Value")
                                .HasColumnType("double precision");

                            b1.HasKey("ElectricityMeterId");

                            b1.ToTable("ElectricityMeters");

                            b1.WithOwner()
                                .HasForeignKey("ElectricityMeterId");
                        });

                    b.Navigation("Integration")
                        .IsRequired();

                    b.Navigation("TotalEnergyConsumption");

                    b.Navigation("TotalEnergyFeedIn");
                });

            modelBuilder.Entity("OpenEMS.Domain.Producers.Producer", b =>
                {
                    b.OwnsOne("OpenEMS.Domain.IntegrationIdentifier", "Integration", b1 =>
                        {
                            b1.Property<Guid>("ProducerId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Device")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Integration")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("ProducerId");

                            b1.HasIndex("Integration", "Device")
                                .IsUnique();

                            b1.ToTable("Producers");

                            b1.WithOwner()
                                .HasForeignKey("ProducerId");
                        });

                    b.OwnsOne("OpenEMS.Domain.TotalEnergy", "TotalEnergyProduction", b1 =>
                        {
                            b1.Property<Guid>("ProducerId")
                                .HasColumnType("uuid");

                            b1.Property<double>("LastReported")
                                .HasColumnType("double precision");

                            b1.Property<double>("Value")
                                .HasColumnType("double precision");

                            b1.HasKey("ProducerId");

                            b1.ToTable("Producers");

                            b1.WithOwner()
                                .HasForeignKey("ProducerId");
                        });

                    b.Navigation("Integration")
                        .IsRequired();

                    b.Navigation("TotalEnergyProduction");
                });
#pragma warning restore 612, 618
        }
    }
}
