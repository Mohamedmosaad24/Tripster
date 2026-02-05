using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DALTripster.Migrations
{
    /// <inheritdoc />
    public partial class addedImgs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "hotel1.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageUrl", "RoomId" },
                values: new object[] { "room-1.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageUrl", "RoomId" },
                values: new object[] { "room-2.jpg", 2 });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageUrl", "RoomId" },
                values: new object[] { "room-3.jpg", 3 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl", "RoomId" },
                values: new object[,]
                {
                    { 5, null, "room-4.jpg", 4 },
                    { 6, 1, "hotel3.jpg", null },
                    { 7, 1, "hotel4.jpg", null },
                    { 8, 1, "hotel7.jpg", null },
                    { 9, 2, "hotel8.jpg", null },
                    { 10, 2, "hotel9.jpg", null },
                    { 11, 2, "hotel10.jpg", null },
                    { 12, 2, "hotel11.jpg", null },
                    { 13, 2, "hotel12.jpg", null },
                    { 14, 1, "hotel6.jpg", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://picsum.photos/id/1018/900/600");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageUrl", "RoomId" },
                values: new object[] { "https://picsum.photos/id/1019/900/600", 2 });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageUrl", "RoomId" },
                values: new object[] { "https://picsum.photos/id/1020/900/600", 3 });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageUrl", "RoomId" },
                values: new object[] { "https://picsum.photos/id/1021/900/600", 4 });
        }
    }
}
