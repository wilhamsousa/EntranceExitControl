using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cronis.VehicleControl.Infra.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckListOption",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckListOption", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CheckList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehiclePlate = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckList_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CheckListItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CheckListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CheckListOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckListItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckListItem_CheckListOption_CheckListOptionId",
                        column: x => x.CheckListOptionId,
                        principalTable: "CheckListOption",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CheckListItem_CheckList_CheckListId",
                        column: x => x.CheckListId,
                        principalTable: "CheckList",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckList_UserId",
                table: "CheckList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckList_VehiclePlate_StartDateTime",
                table: "CheckList",
                columns: new[] { "VehiclePlate", "StartDateTime" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CheckListItem_CheckListId",
                table: "CheckListItem",
                column: "CheckListId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckListItem_CheckListOptionId",
                table: "CheckListItem",
                column: "CheckListOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Name",
                table: "User",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckListItem");

            migrationBuilder.DropTable(
                name: "CheckListOption");

            migrationBuilder.DropTable(
                name: "CheckList");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
