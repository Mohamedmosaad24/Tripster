using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DALTripster.Migrations
{
    /// <inheritdoc />
    public partial class fixdataseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "Description", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 1, "Nile Corniche, Cairo, Egypt", "Luxury 5-star hotel overlooking the Nile River with stunning views and world-class facilities", 30.0444, 31.235700000000001, "Golden Nile Hotel" },
                    { 2, "KM 120, North Coast, Egypt", "Elegant beachfront resort on the Mediterranean Sea offering an unforgettable relaxation experience", 30.891300000000001, 29.743400000000001, "North Coast Resort" },
                    { 3, "Pyramid Street, Giza, Egypt", "Historic hotel near the Pyramids combining authenticity with modern comfort", 29.979199999999999, 31.1342, "Royal Pyramids Hotel" },
                    { 4, "Tourist Promenade, Sharm El Sheikh, Egypt", "World-class diving resort on the Red Sea with spectacular coral reefs", 27.257899999999999, 33.811599999999999, "Red Sea Resort" },
                    { 5, "Alexandria Corniche, Alexandria, Egypt", "Luxury boutique hotel on the Mediterranean coast with rich historical heritage", 31.200099999999999, 29.918700000000001, "Alexandria Palace" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Free WiFi" },
                    { 2, "Outdoor Pool" },
                    { 3, "Spa & Wellness Center" },
                    { 4, "Fitness Center" },
                    { 5, "Fine Dining Restaurant" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "Email", "ImageUrl", "Location", "Name", "Nationality" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed.mohamed@email.com", "https://example.com/images/users/ahmed.jpg", "Cairo, Egypt", "Ahmed Mohamed Ali", "Egyptian" },
                    { 2, new DateTime(1988, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "fatima.hassan@email.com", "https://example.com/images/users/fatima.jpg", "Alexandria, Egypt", "Fatima Hassan", "Egyptian" },
                    { 3, new DateTime(1992, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "mahmoud.abdullah@email.com", "https://example.com/images/users/mahmoud.jpg", "Giza, Egypt", "Mahmoud Abdullah", "Egyptian" },
                    { 4, new DateTime(1985, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "nour.aldeen@email.com", "https://example.com/images/users/nour.jpg", "Dubai, UAE", "Nour Al-Din", "Emirati" },
                    { 5, new DateTime(1995, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.ahmed@email.com", "https://example.com/images/users/sara.jpg", "Riyadh, Saudi Arabia", "Sara Ahmed", "Saudi" }
                });

            migrationBuilder.InsertData(
                table: "HotelServices",
                columns: new[] { "HotelId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 5 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 4 },
                    { 3, 5 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 5, 1 },
                    { 5, 3 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl", "RoomId" },
                values: new object[,]
                {
                    { 1, 1, "https://example.com/hotels/golden-nile/exterior.jpg", null },
                    { 3, 2, "https://example.com/hotels/north-coast/beach-view.jpg", null },
                    { 4, 3, "https://example.com/hotels/pyramids/pyramid-view.jpg", null },
                    { 5, 4, "https://example.com/hotels/red-sea/diving-center.jpg", null }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "HotelId", "Rate", "UserId" },
                values: new object[,]
                {
                    { 1, "Excellent hotel! Outstanding service and the Nile view is fantastic. Highly recommended.", 1, 5, 1 },
                    { 2, "Good hotel with excellent location. Rooms are clean but breakfast needs improvement.", 1, 4, 2 },
                    { 3, "Amazing beach resort! Clean beach and modern facilities. Unforgettable experience.", 2, 5, 3 },
                    { 4, "Perfect location next to the Pyramids. Historic and luxurious hotel. Exceptional service.", 3, 5, 4 },
                    { 5, "Great hotel for diving. Excellent facilities but rooms need renovation.", 4, 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "HotelId", "IsAvailable", "NumberOFBathRoom", "Price", "RoomType", "Sqm", "TypeOfBed" },
                values: new object[,]
                {
                    { 1, 4, 1, true, 2, 3500.00m, "Royal Suite", 85.5f, 1 },
                    { 2, 2, 1, true, 1, 2200.00m, "Deluxe Nile View Room", 45f, 1 },
                    { 3, 4, 2, true, 2, 3200.00m, "Beach Front Chalet", 75f, 1 },
                    { 4, 2, 3, true, 1, 2500.00m, "Pyramid View Room", 50f, 2 },
                    { 5, 2, 4, true, 1, 1900.00m, "Divers Room", 40f, 2 }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CheckIn", "CheckOut", "RoomId", "TotalPrice", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 11000.00m, 1 },
                    { 2, new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 11000.00m, 2 },
                    { 3, new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 16000.00m, 3 },
                    { 4, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 15000.00m, 4 },
                    { 5, new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 9500.00m, 5 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl", "RoomId" },
                values: new object[] { 2, 1, "https://example.com/hotels/golden-nile/royal-suite.jpg", 1 });
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
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 5);

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
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "HotelServices",
                keyColumns: new[] { "HotelId", "ServiceId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "HotelServices",
                keyColumns: new[] { "HotelId", "ServiceId" },
                keyValues: new object[] { 1, 5 });

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
                table: "HotelServices",
                keyColumns: new[] { "HotelId", "ServiceId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "HotelServices",
                keyColumns: new[] { "HotelId", "ServiceId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "HotelServices",
                keyColumns: new[] { "HotelId", "ServiceId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "HotelServices",
                keyColumns: new[] { "HotelId", "ServiceId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "HotelServices",
                keyColumns: new[] { "HotelId", "ServiceId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "HotelServices",
                keyColumns: new[] { "HotelId", "ServiceId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "HotelServices",
                keyColumns: new[] { "HotelId", "ServiceId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "HotelServices",
                keyColumns: new[] { "HotelId", "ServiceId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "HotelServices",
                keyColumns: new[] { "HotelId", "ServiceId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "HotelServices",
                keyColumns: new[] { "HotelId", "ServiceId" },
                keyValues: new object[] { 5, 5 });

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
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5);

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
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
