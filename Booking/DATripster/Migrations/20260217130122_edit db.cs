using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DALTripster.Migrations
{
    /// <inheritdoc />
    public partial class editdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Hotels_HotelId",
                table: "Images");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Hotels_HotelId",
                table: "Images",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Hotels_HotelId",
                table: "Images");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Hotels_HotelId",
                table: "Images",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }
    }
}
