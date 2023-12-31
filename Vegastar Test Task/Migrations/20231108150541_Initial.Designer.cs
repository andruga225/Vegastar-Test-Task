﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Vegastar_Test_Task.Models;

#nullable disable

namespace Vegastar_Test_Task.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20231108150541_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Vegastar_Test_Task.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int?>("UserGroupId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserStateId")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.HasIndex("UserGroupId");

                    b.HasIndex("UserStateId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Vegastar_Test_Task.Models.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Discription")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "Admin",
                            Discription = "All permissions"
                        },
                        new
                        {
                            Id = 2,
                            Code = "User",
                            Discription = "Limited access"
                        });
                });

            modelBuilder.Entity("Vegastar_Test_Task.Models.UserState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserStates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "Active",
                            Description = ""
                        },
                        new
                        {
                            Id = 2,
                            Code = "Blocked",
                            Description = ""
                        });
                });

            modelBuilder.Entity("Vegastar_Test_Task.Models.User", b =>
                {
                    b.HasOne("Vegastar_Test_Task.Models.UserGroup", "UserGroup")
                        .WithMany()
                        .HasForeignKey("UserGroupId");

                    b.HasOne("Vegastar_Test_Task.Models.UserState", "UserState")
                        .WithMany()
                        .HasForeignKey("UserStateId");

                    b.Navigation("UserGroup");

                    b.Navigation("UserState");
                });
#pragma warning restore 612, 618
        }
    }
}
