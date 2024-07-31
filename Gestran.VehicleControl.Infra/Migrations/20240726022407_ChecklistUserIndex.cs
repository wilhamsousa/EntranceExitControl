using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gestran.VehicleControl.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ChecklistUserIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckList_User_UserId",
                table: "CheckList");

            migrationBuilder.AlterColumn<string>(
                name: "VehiclePlate",
                table: "CheckList",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePlateStartDateTime",
                table: "CheckList",
                columns: new[] { "VehiclePlate", "StartDateTime" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CheckList_User",
                table: "CheckList",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckList_User",
                table: "CheckList");

            migrationBuilder.DropIndex(
                name: "IX_VehiclePlateStartDateTime",
                table: "CheckList");

            migrationBuilder.AlterColumn<string>(
                name: "VehiclePlate",
                table: "CheckList",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckList_User_UserId",
                table: "CheckList",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
