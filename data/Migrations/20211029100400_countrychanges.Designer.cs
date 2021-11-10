﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using data.Data;

namespace data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211029100400_countrychanges")]
    partial class countrychanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("models.Models.AppUserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UserType")
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("models.Models.CountryModel", b =>
                {
                    b.Property<int>("Country_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PhoneCode")
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Country_Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("models.Models.GrantProgramModel", b =>
                {
                    b.Property<int>("GrantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("EndDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgramCode")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ProgramName")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("StartDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.HasKey("GrantId");

                    b.ToTable("GrantPrograms");
                });

            modelBuilder.Entity("models.Models.StateModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Country_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("Country_Id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("models.Models.StateModel", b =>
                {
                    b.HasOne("models.Models.CountryModel", "Country")
                        .WithMany("States")
                        .HasForeignKey("Country_Id");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("models.Models.CountryModel", b =>
                {
                    b.Navigation("States");
                });
#pragma warning restore 612, 618
        }
    }
}
