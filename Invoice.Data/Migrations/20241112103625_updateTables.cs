using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoice.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_AspNetUsers_AppUserId",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_AspNetUsers_AppUserId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_AspNetUsers_AppUserId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_AppUserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Taxes_AspNetUsers_AppUserId",
                table: "Taxes");

            migrationBuilder.DropIndex(
                name: "IX_Taxes_AppUserId",
                table: "Taxes");

            migrationBuilder.DropIndex(
                name: "IX_Products_AppUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Payments_AppUserId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_AppUserId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceItems_AppUserId",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Taxes");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "InvoiceItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Taxes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Payments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Invoices",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "InvoiceItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Taxes_AppUserId",
                table: "Taxes",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AppUserId",
                table: "Products",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_AppUserId",
                table: "Payments",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_AppUserId",
                table: "Invoices",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_AppUserId",
                table: "InvoiceItems",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_AspNetUsers_AppUserId",
                table: "InvoiceItems",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_AspNetUsers_AppUserId",
                table: "Invoices",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_AspNetUsers_AppUserId",
                table: "Payments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_AppUserId",
                table: "Products",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Taxes_AspNetUsers_AppUserId",
                table: "Taxes",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
