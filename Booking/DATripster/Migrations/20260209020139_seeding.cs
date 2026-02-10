using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DALTripster.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "Description", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 1, "Copenhagen, Denmark", "Modern hotel in city center", 55.685000000000002, 12.561, "Hotel Norrebro" },
                    { 2, "Hurghada, Egypt", "Resort with sea view", 27.257899999999999, 33.811599999999999, "Sea View Resort" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Free Wi-Fi" },
                    { 2, "Breakfast Included" },
                    { 3, "Swimming Pool" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "Email", "ImageUrl", "Location", "Name", "Nationality" },
                values: new object[,]
                {
                    { 1, new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "islam@test.com", "/assets/users/user1.jpg", "Egypt", "Islam Soliman", "Egyptian" },
                    { 2, new DateTime(1990, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "john@test.com", null, "USA", "John Doe", "American" }
                });

            migrationBuilder.InsertData(
                table: "HotelServices",
                columns: new[] { "HotelId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "HotelId", "Rate", "UserId" },
                values: new object[,]
                {
                    { 1, "Excellent stay!", 1, 5, 1 },
                    { 2, "Very good service", 2, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "HotelId", "IsAvailable", "NumberOFBathRoom", "Price", "RoomType", "Sqm", "TypeOfBed" },
                values: new object[,]
                {
                    { 1, 1, 1, true, 1, 120m, "Single Room", 18f, 1 },
                    { 2, 2, 1, true, 1, 180m, "Double Room", 25f, 2 },
                    { 3, 3, 1, true, 2, 250m, "Suite", 35f, 1 },
                    { 4, 4, 1, true, 2, 300m, "Family Room", 40f, 2 },
                    { 5, 2, 1, true, 1, 220m, "Deluxe Room", 30f, 1 },
                    { 6, 2, 1, true, 1, 260m, "King Room", 32f, 1 },
                    { 7, 2, 1, true, 1, 240m, "Queen Room", 28f, 2 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CheckIn", "CheckOut", "RoomId", "TotalPrice", "UserId" },
                values: new object[] { 1, new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 240m, 1 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl", "RoomId" },
                values: new object[,]
                {
                    { 1, null, "/assets/RoomImg/room-1.jpg", 1 },
                    { 2, null, "/assets/RoomImg/room-2.jpg", 2 },
                    { 3, null, "/assets/RoomImg/room-3.jpg", 3 },
                    { 4, null, "/assets/RoomImg/room-4.jpg", 4 },
                    { 5, null, "/assets/RoomImg/room-5.jpg", 5 },
                    { 6, null, "/assets/RoomImg/room-6.jpg", 6 },
                    { 7, null, "/assets/RoomImg/room-7.jpg", 7 }
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
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "HotelServices",
                keyColumns: new[] { "HotelId", "ServiceId" },
                keyValues: new object[] { 2, 3 });

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
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

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
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7);

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
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
