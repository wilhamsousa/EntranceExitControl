﻿// <auto-generated />
using System;
using Gestran.VehicleControl.Infra.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gestran.VehicleControl.Infra.Migrations
{
    [DbContext(typeof(ExcContext))]
    partial class ExcContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Gestran.VehicleControl.Domain.Model.Entities.CheckList", b =>
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
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VehiclePlate", "StartDateTime")
                        .IsUnique()
                        .HasDatabaseName("IX_VehiclePlateStartDateTime");

                    b.ToTable("CheckList");
                });

            modelBuilder.Entity("Gestran.VehicleControl.Domain.Model.Entities.CheckListItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("Approved")
                        .HasColumnType("bit");

                    b.Property<Guid>("CheckListId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CheckListId");

                    b.HasIndex("ItemId");

                    b.ToTable("CheckListItem");
                });

            modelBuilder.Entity("Gestran.VehicleControl.Domain.Model.Entities.ItemCheckList", b =>
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

            modelBuilder.Entity("Gestran.VehicleControl.Domain.Model.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("IX_Name");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Gestran.VehicleControl.Domain.Model.Entities.CheckList", b =>
                {
                    b.HasOne("Gestran.VehicleControl.Domain.Model.Entities.User", "User")
                        .WithMany("CheckLists")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_CheckList_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Gestran.VehicleControl.Domain.Model.Entities.CheckListItem", b =>
                {
                    b.HasOne("Gestran.VehicleControl.Domain.Model.Entities.CheckList", "CheckList")
                        .WithMany("CheckListItem")
                        .HasForeignKey("CheckListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gestran.VehicleControl.Domain.Model.Entities.ItemCheckList", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CheckList");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Gestran.VehicleControl.Domain.Model.Entities.CheckList", b =>
                {
                    b.Navigation("CheckListItem");
                });

            modelBuilder.Entity("Gestran.VehicleControl.Domain.Model.Entities.User", b =>
                {
                    b.Navigation("CheckLists");
                });
#pragma warning restore 612, 618
        }
    }
}
