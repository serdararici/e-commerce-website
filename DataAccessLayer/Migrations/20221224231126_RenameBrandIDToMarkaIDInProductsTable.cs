using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class RenameBrandIDToMarkaIDInProductsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_BrandID",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "BrandID",
                table: "Products",
                newName: "MarkaID");
            migrationBuilder.CreateIndex(
    name: "IX_Products_BrandID",
    table: "Products",
    column: "BrandID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandID",
                table: "Products",
                column: "BrandID",
                principalTable: "Brands",
                principalColumn: "MarkaID",
                onDelete: ReferentialAction.Cascade);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandMarkaID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_BrandMarkaID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BrandMarkaID",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "MarkaID",
                table: "Products",
                newName: "BrandID");

            migrationBuilder.CreateIndex(
    name: "IX_Products_BrandID",
    table: "Products",
    column: "BrandID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandID",
                table: "Products",
                column: "BrandID",
                principalTable: "Brands",
                principalColumn: "MarkaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
