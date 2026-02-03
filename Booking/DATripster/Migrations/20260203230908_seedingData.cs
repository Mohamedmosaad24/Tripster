using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DALTripster.Migrations
{
    /// <inheritdoc />
    public partial class seedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "Description", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 1, "12 Nile Street, Giza", "Family-friendly hotel near major attractions.", 29.9773, 31.1325, "Sunrise Hotel" },
                    { 2, "88 Marina Road, Hurghada", "Beach resort with sea view rooms and water activities.", 27.257899999999999, 33.811599999999999, "Sea Breeze Resort" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Free Wi-Fi" },
                    { 2, "Breakfast Included" },
                    { 3, "Swimming Pool" },
                    { 4, "Airport Pickup" },
                    { 5, "Gym" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "Email", "ImageUrl", "Location", "Name", "Nationality" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john@gmail.com", "https://picsum.photos/id/1005/400/400", "New York", "John Doe", "American" },
                    { 2, new DateTime(1996, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.ali@gmail.com", "https://picsum.photos/id/1027/400/400", "Cairo", "Sara Ali", "Egyptian" },
                    { 3, new DateTime(1993, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar.hassan@gmail.com", "https://picsum.photos/id/1011/400/400", "Alexandria", "Omar Hassan", "Egyptian" }
                });

            migrationBuilder.InsertData(
                table: "HotelServices",
                columns: new[] { "HotelId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 4 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl", "RoomId" },
                values: new object[] { 1, 1, "https://picsum.photos/id/1018/900/600", null });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "HotelId", "Rate", "UserId" },
                values: new object[,]
                {
                    { 1, "Very clean and great service.", 1, 5, 1 },
                    { 2, "Amazing beach view, would visit again!", 2, 4, 2 },
                    { 3, "Good for the price, but room was small.", 1, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "HotelId", "IsAvailable", "Price", "RoomType" },
                values: new object[,]
                {
                    { 1, 1, 1, true, 60.0m, "Single" },
                    { 2, 2, 1, true, 95.0m, "Double" },
                    { 3, 4, 2, true, 180.0m, "Suite" },
                    { 4, 2, 2, false, 110.0m, "Double" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CheckIn", "CheckOut", "RoomId", "TotalPrice", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 285.0m, 1 },
                    { 2, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 900.0m, 2 },
                    { 3, new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 120.0m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl", "RoomId" },
                values: new object[,]
                {
                    { 2, null, "https://picsum.photos/id/1019/900/600", 2 },
                    { 3, null, "https://picsum.photos/id/1020/900/600", 3 },
                    { 4, null, "https://picsum.photos/id/1021/900/600", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HotelServices",
                keyColumns: new[] { "HotelId", "ServiceId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "HotelServices",
                keyColumns: new[] { "HotelId", "ServiceId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "HotelServices",
                keyColumns: new[] { "HotelId", "ServiceId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "HotelServices",
                keyColumns: new[] { "HotelId", "ServiceId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "HotelServices",
                keyColumns: new[] { "HotelId", "ServiceId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "HotelServices",
                keyColumns: new[] { "HotelId", "ServiceId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "HotelServices",
                keyColumns: new[] { "HotelId", "ServiceId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
