﻿// <auto-generated />
using System;
using Cronis.VehicleControl.Infra.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cronis.VehicleControl.Infra.Migrations
{
    [DbContext(typeof(ExcContext))]
    [Migration("20240702001520_user")]
    partial class user
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cronis.VehicleControl.Domain.Model.Entities.CheckList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("VehiclePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CheckList");
                });

            modelBuilder.Entity("Cronis.VehicleControl.Domain.Model.Entities.CheckListItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Approved")
                        .HasColumnType("bit");

                    b.Property<Guid>("CheckListId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CheckListId");

                    b.HasIndex("ItemId");

                    b.ToTable("CheckListItem");
                });

            modelBuilder.Entity("Cronis.VehicleControl.Domain.Model.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Cronis.VehicleControl.Domain.Model.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Cronis.VehicleControl.Domain.Model.Entities.CheckList", b =>
                {
                    b.HasOne("Cronis.VehicleControl.Domain.Model.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cronis.VehicleControl.Domain.Model.Entities.CheckListItem", b =>
                {
                    b.HasOne("Cronis.VehicleControl.Domain.Model.Entities.CheckList", "CheckList")
                        .WithMany("CheckListItem")
                        .HasForeignKey("CheckListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cronis.VehicleControl.Domain.Model.Entities.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CheckList");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Cronis.VehicleControl.Domain.Model.Entities.CheckList", b =>
                {
                    b.Navigation("CheckListItem");
                });
#pragma warning restore 612, 618
        }
    }
}