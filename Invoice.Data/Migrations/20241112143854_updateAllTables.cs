using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_AspNetUsers_AppUserId",
                table: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_AppUserId",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Discounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Discounts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_AppUserId",
                table: "Discounts",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_AspNetUsers_AppUserId",
                table: "Discounts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
