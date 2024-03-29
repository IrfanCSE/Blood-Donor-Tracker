﻿// <auto-generated />
using System;
using BloodDonorTracker.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BloodDonorTracker.Data.Migrations.AppDb
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BloodDonorTracker.Models.Admin", b =>
                {
                    b.Property<long>("AdminIdPk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AdminDonorIdFk")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("AdminIdPk");

                    b.HasIndex("AdminDonorIdFk")
                        .IsUnique();

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("BloodDonorTracker.Models.Alert", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfDonation")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<long>("RequestIdFk")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("TimeOfDonation")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RequestIdFk")
                        .IsUnique();

                    b.ToTable("Alerts");
                });

            modelBuilder.Entity("BloodDonorTracker.Models.BlackList", b =>
                {
                    b.Property<long>("BlackListIdPk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ActionDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("DonorIdFk")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("BlackListIdPk");

                    b.HasIndex("DonorIdFk")
                        .IsUnique();

                    b.ToTable("BlackLists");
                });

            modelBuilder.Entity("BloodDonorTracker.Models.BloodGroup", b =>
                {
                    b.Property<long>("BloodGroupIdPk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BloodGroupName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("BloodGroupIdPk");

                    b.ToTable("BloodGroups");
                });

            modelBuilder.Entity("BloodDonorTracker.Models.BloodRequest", b =>
                {
                    b.Property<long>("BloodRequestIdPk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("BloodGroupFK")
                        .HasColumnType("bigint");

                    b.Property<string>("Condition")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<double?>("Distance")
                        .HasColumnType("float");

                    b.Property<DateTime>("DonationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsResponsed")
                        .HasColumnType("bit");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float");

                    b.Property<long>("RequestDonorFk")
                        .HasColumnType("bigint");

                    b.Property<long?>("ResponsedDonorFk")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("BloodRequestIdPk");

                    b.HasIndex("BloodGroupFK");

                    b.HasIndex("RequestDonorFk");

                    b.HasIndex("ResponsedDonorFk");

                    b.ToTable("BloodRequests");
                });

            modelBuilder.Entity("BloodDonorTracker.Models.Donor", b =>
                {
                    b.Property<long>("DonorIdPk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<double?>("Distance")
                        .HasColumnType("float");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsLocationUpdateAuto")
                        .HasColumnType("bit");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("NID")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("UserIdFk")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebSocketConnectionId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DonorIdPk");

                    b.ToTable("Donors");
                });

            modelBuilder.Entity("BloodDonorTracker.Models.DonorRequest", b =>
                {
                    b.Property<long>("DonorRequestIdPk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BloodRequestIdFk")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RequestDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("RequestDonorIdFk")
                        .HasColumnType("bigint");

                    b.Property<long>("RequestUserIdFk")
                        .HasColumnType("bigint");

                    b.Property<bool?>("isAccept")
                        .HasColumnType("bit");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("isRead")
                        .HasColumnType("bit");

                    b.HasKey("DonorRequestIdPk");

                    b.HasIndex("BloodRequestIdFk");

                    b.HasIndex("RequestDonorIdFk");

                    b.HasIndex("RequestUserIdFk");

                    b.ToTable("DonorRequests");
                });

            modelBuilder.Entity("BloodDonorTracker.Models.HealthReport", b =>
                {
                    b.Property<long>("HealthReportIdPk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BloodGroupIdFk")
                        .HasColumnType("bigint");

                    b.Property<long>("DonorIdFk")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastDonationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("HealthReportIdPk");

                    b.HasIndex("BloodGroupIdFk");

                    b.HasIndex("DonorIdFk")
                        .IsUnique();

                    b.ToTable("HealthReports");
                });

            modelBuilder.Entity("BloodDonorTracker.Models.Admin", b =>
                {
                    b.HasOne("BloodDonorTracker.Models.Donor", "AdminDonorNav")
                        .WithOne("Admin")
                        .HasForeignKey("BloodDonorTracker.Models.Admin", "AdminDonorIdFk");

                    b.Navigation("AdminDonorNav");
                });

            modelBuilder.Entity("BloodDonorTracker.Models.Alert", b =>
                {
                    b.HasOne("BloodDonorTracker.Models.BloodRequest", "RequestIdNav")
                        .WithOne("Alert")
                        .HasForeignKey("BloodDonorTracker.Models.Alert", "RequestIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequestIdNav");
                });

            modelBuilder.Entity("BloodDonorTracker.Models.BlackList", b =>
                {
                    b.HasOne("BloodDonorTracker.Models.Donor", "DonorIdNav")
                        .WithOne("BlackList")
                        .HasForeignKey("BloodDonorTracker.Models.BlackList", "DonorIdFk");

                    b.Navigation("DonorIdNav");
                });

            modelBuilder.Entity("BloodDonorTracker.Models.BloodRequest", b =>
                {
                    b.HasOne("BloodDonorTracker.Models.BloodGroup", "BloodGroupNav")
                        .WithMany("BloodRequests")
                        .HasForeignKey("BloodGroupFK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BloodDonorTracker.Models.Donor", "RequestDonorNav")
                        .WithMany("BloodRequests")
                        .HasForeignKey("RequestDonorFk")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BloodDonorTracker.Models.Donor", "ResponsedDonorNav")
                        .WithMany("BloodResponsedRequests")
                        .HasForeignKey("ResponsedDonorFk")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("BloodGroupNav");

                    b.Navigation("RequestDonorNav");

                    b.Navigation("ResponsedDonorNav");
                });

            modelBuilder.Entity("BloodDonorTracker.Models.DonorRequest", b =>
                {
                    b.HasOne("BloodDonorTracker.Models.BloodRequest", "BloodRequestIdNav")
                        .WithMany("DonorRequests")
                        .HasForeignKey("BloodRequestIdFk")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BloodDonorTracker.Models.Donor", "RequestDonorIdNav")
                        .WithMany("RequestReceive")
                        .HasForeignKey("RequestDonorIdFk")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BloodDonorTracker.Models.Donor", "RequestUserIdNav")
                        .WithMany("RequestSend")
                        .HasForeignKey("RequestUserIdFk")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BloodRequestIdNav");

                    b.Navigation("RequestDonorIdNav");

                    b.Navigation("RequestUserIdNav");
                });

            modelBuilder.Entity("BloodDonorTracker.Models.HealthReport", b =>
                {
                    b.HasOne("BloodDonorTracker.Models.BloodGroup", "BloodGroupNav")
                        .WithMany("HealthReports")
                        .HasForeignKey("BloodGroupIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BloodDonorTracker.Models.Donor", "DonorNav")
                        .WithOne("HealthReportNav")
                        .HasForeignKey("BloodDonorTracker.Models.HealthReport", "DonorIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BloodGroupNav");

                    b.Navigation("DonorNav");
                });

            modelBuilder.Entity("BloodDonorTracker.Models.BloodGroup", b =>
                {
                    b.Navigation("BloodRequests");

                    b.Navigation("HealthReports");
                });

            modelBuilder.Entity("BloodDonorTracker.Models.BloodRequest", b =>
                {
                    b.Navigation("Alert");

                    b.Navigation("DonorRequests");
                });

            modelBuilder.Entity("BloodDonorTracker.Models.Donor", b =>
                {
                    b.Navigation("Admin");

                    b.Navigation("BlackList");

                    b.Navigation("BloodRequests");

                    b.Navigation("BloodResponsedRequests");

                    b.Navigation("HealthReportNav");

                    b.Navigation("RequestReceive");

                    b.Navigation("RequestSend");
                });
#pragma warning restore 612, 618
        }
    }
}
