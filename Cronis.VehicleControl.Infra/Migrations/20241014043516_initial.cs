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
            migrationBuilder.DropForeignKey(
                name: "FK_CheckList_User",
                table: "CheckList");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckListItem_CheckList_CheckListId",
                table: "CheckListItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckListItem_Item_ItemId",
                table: "CheckListItem");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.RenameIndex(
                name: "IX_Name",
                table: "User",
                newName: "IX_User_Name");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "CheckListItem",
                newName: "CheckListOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckListItem_ItemId",
                table: "CheckListItem",
                newName: "IX_CheckListItem_CheckListOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_VehiclePlateStartDateTime",
                table: "CheckList",
                newName: "IX_CheckList_VehiclePlate_StartDateTime");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CheckList_User_UserId",
                table: "CheckList",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckListItem_CheckListOption_CheckListOptionId",
                table: "CheckListItem",
                column: "CheckListOptionId",
                principalTable: "CheckListOption",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckListItem_CheckList_CheckListId",
                table: "CheckListItem",
                column: "CheckListId",
                principalTable: "CheckList",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckList_User_UserId",
                table: "CheckList");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckListItem_CheckListOption_CheckListOptionId",
                table: "CheckListItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CheckListItem_CheckList_CheckListId",
                table: "CheckListItem");

            migrationBuilder.DropTable(
                name: "CheckListOption");

            migrationBuilder.RenameIndex(
                name: "IX_User_Name",
                table: "User",
                newName: "IX_Name");

            migrationBuilder.RenameColumn(
                name: "CheckListOptionId",
                table: "CheckListItem",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckListItem_CheckListOptionId",
                table: "CheckListItem",
                newName: "IX_CheckListItem_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CheckList_VehiclePlate_StartDateTime",
                table: "CheckList",
                newName: "IX_VehiclePlateStartDateTime");

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CheckList_User",
                table: "CheckList",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckListItem_CheckList_CheckListId",
                table: "CheckListItem",
                column: "CheckListId",
                principalTable: "CheckList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckListItem_Item_ItemId",
                table: "CheckListItem",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
