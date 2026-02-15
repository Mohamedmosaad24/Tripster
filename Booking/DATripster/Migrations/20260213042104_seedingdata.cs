using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DALTripster.Migrations
{
    /// <inheritdoc />
    public partial class seedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Rooms_RoomId",
                table: "Images");

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
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Description", "Latitude", "Longitude" },
                values: new object[] { "Cairo", "Luxury 5-star hotel", 0.0, 0.0 });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Description", "Latitude", "Longitude" },
                values: new object[] { "North Coast", "Beachfront resort", 0.0, 0.0 });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "Description", "Latitude", "Longitude" },
                values: new object[] { "Giza", "Historic hotel", 0.0, 0.0 });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "Description", "Latitude", "Longitude" },
                values: new object[] { "Sharm El Sheikh", "Diving resort", 0.0, 0.0 });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "Description", "Latitude", "Longitude" },
                values: new object[] { "Alexandria", "Boutique hotel", 0.0, 0.0 });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HotelId", "ImageUrl", "RoomId" },
                values: new object[] { 2, "/assets/hotelImg/hotel2.jpg", null });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HotelId", "ImageUrl" },
                values: new object[] { 3, "/assets/hotelImg/hotel3.jpg" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HotelId", "ImageUrl" },
                values: new object[] { 4, "/assets/hotelImg/hotel4.jpg" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "HotelId", "ImageUrl" },
                values: new object[] { 5, "/assets/hotelImg/hotel6.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl", "RoomId" },
                values: new object[,]
                {
                    { 6, 1, "/assets/roomImg/room-1.jpg", 1 },
                    { 7, 1, "/assets/roomImg/room-2.jpg", 2 },
                    { 8, 1, "/assets/roomImg/room-3.jpg", 3 },
                    { 9, 2, "/assets/roomImg/room-4.jpg", 4 },
                    { 10, 2, "/assets/roomImg/room-5.jpg", 5 }
                });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Capacity", "NumberOFBathRoom", "Price", "RoomType", "Sqm", "TypeOfBed" },
                values: new object[] { 2, 1, 1200m, "Standard", 28f, 0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Price", "RoomType", "Sqm", "TypeOfBed" },
                values: new object[] { 1800m, "Deluxe", 38f, 0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HotelId", "Price", "RoomType", "Sqm", "TypeOfBed" },
                values: new object[] { 1, 2800m, "Suite", 55f, 0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HotelId", "Price", "RoomType", "Sqm", "TypeOfBed" },
                values: new object[] { 2, 1300m, "Standard", 30f, 0 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "HotelId", "Price", "RoomType", "Sqm", "TypeOfBed" },
                values: new object[] { 2, 2000m, "Deluxe", 42f, 0 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "HotelId", "IsAvailable", "NumberOFBathRoom", "Price", "RoomType", "Sqm", "TypeOfBed" },
                values: new object[,]
                {
                    { 6, 4, 2, true, 2, 3200m, "Suite", 65f, 0 },
                    { 7, 2, 3, true, 1, 1100m, "Standard", 26f, 0 },
                    { 8, 2, 3, true, 1, 1700m, "Deluxe", 40f, 0 },
                    { 9, 4, 3, true, 2, 2600m, "Suite", 52f, 0 },
                    { 10, 2, 4, true, 1, 1400m, "Standard", 32f, 0 },
                    { 11, 2, 4, true, 1, 2100m, "Deluxe", 45f, 0 },
                    { 12, 4, 4, true, 2, 3500m, "Suite", 70f, 0 },
                    { 13, 2, 5, true, 1, 1000m, "Standard", 25f, 0 },
                    { 14, 2, 5, true, 1, 1600m, "Deluxe", 36f, 0 },
                    { 15, 4, 5, true, 2, 2400m, "Suite", 50f, 0 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "ImageUrl", "Location", "Name" },
                values: new object[] { "ahmed@email.com", "/assets/userImgs/user1.jpg", "Cairo", "Ahmed Mohamed" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "ImageUrl", "Location" },
                values: new object[] { "fatima@email.com", "/assets/userImgs/user2.jpg", "Alexandria" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "ImageUrl", "Location" },
                values: new object[] { "mahmoud@email.com", "/assets/userImgs/user3.jpg", "Giza" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "ImageUrl", "RoomId" },
                values: new object[,]
                {
                    { 11, 2, "/assets/roomImg/room-6.jpg", 6 },
                    { 12, 3, "/assets/roomImg/room-7.jpg", 7 },
                    { 13, 3, "/assets/roomImg/room-1.jpg", 8 },
                    { 14, 3, "/assets/roomImg/room-2.jpg", 9 },
                    { 15, 4, "/assets/roomImg/room-3.jpg", 10 },
                    { 16, 4, "/assets/roomImg/room-4.jpg", 11 },
                    { 17, 4, "/assets/roomImg/room-5.jpg", 12 },
                    { 18, 5, "/assets/roomImg/room-6.jpg", 13 },
                    { 19, 5, "/assets/roomImg/room-7.jpg", 14 },
                    { 20, 5, "/assets/roomImg/room-1.jpg", 15 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Rooms_RoomId",
                table: "Images",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Rooms_RoomId",
                table: "Images");

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

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CheckIn", "CheckOut", "GuestEmail", "GuestFullName", "GuestPhone", "RoomId", "TotalPrice", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed.mohamed@email.com", "Ahmed Mohamed Ali", "+201234567890", 1, 11000.00m, 1 },
                    { 2, new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "fatima.hassan@email.com", "Fatima Hassan", "+201234567891", 2, 11000.00m, 2 },
                    { 3, new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "mahmoud.abdullah@email.com", "Mahmoud Abdullah", "+201234567892", 3, 16000.00m, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "Description", "Latitude", "Longitude" },
                values: new object[] { "Nile Corniche, Cairo, Egypt", "Luxury 5-star hotel overlooking the Nile River with stunning views and world-class facilities", 30.0444, 31.235700000000001 });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "Description", "Latitude", "Longitude" },
                values: new object[] { "KM 120, North Coast, Egypt", "Elegant beachfront resort on the Mediterranean Sea offering an unforgettable relaxation experience", 30.891300000000001, 29.743400000000001 });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Address", "Description", "Latitude", "Longitude" },
                values: new object[] { "Pyramid Street, Giza, Egypt", "Historic hotel near the Pyramids combining authenticity with modern comfort", 29.979199999999999, 31.1342 });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Address", "Description", "Latitude", "Longitude" },
                values: new object[] { "Tourist Promenade, Sharm El Sheikh, Egypt", "World-class diving resort on the Red Sea with spectacular coral reefs", 27.257899999999999, 33.811599999999999 });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Address", "Description", "Latitude", "Longitude" },
                values: new object[] { "Alexandria Corniche, Alexandria, Egypt", "Luxury boutique hotel on the Mediterranean coast with rich historical heritage", 31.200099999999999, 29.918700000000001 });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HotelId", "ImageUrl", "RoomId" },
                values: new object[] { 1, "/assets/roomImg/room-1.jpg", 1 });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HotelId", "ImageUrl" },
                values: new object[] { 2, "/assets/hotelImg/hotel8.jpg" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HotelId", "ImageUrl" },
                values: new object[] { 3, "/assets/hotelImg/hotel3.jpg" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "HotelId", "ImageUrl" },
                values: new object[] { 4, "/assets/hotelImg/hotel10.jpg" });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "HotelId", "Rate", "UserId" },
                values: new object[,]
                {
                    { 1, "Excellent hotel! Outstanding service and the Nile view is fantastic. Highly recommended.", 1, 5, 1 },
                    { 2, "Good hotel with excellent location. Rooms are clean but breakfast needs improvement.", 1, 4, 2 },
                    { 3, "Amazing beach resort! Clean beach and modern facilities. Unforgettable experience.", 2, 5, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Capacity", "NumberOFBathRoom", "Price", "RoomType", "Sqm", "TypeOfBed" },
                values: new object[] { 4, 2, 3500.00m, "Royal Suite", 85.5f, 1 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Price", "RoomType", "Sqm", "TypeOfBed" },
                values: new object[] { 2200.00m, "Deluxe Nile View Room", 45f, 1 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HotelId", "Price", "RoomType", "Sqm", "TypeOfBed" },
                values: new object[] { 2, 3200.00m, "Beach Front Chalet", 75f, 1 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HotelId", "Price", "RoomType", "Sqm", "TypeOfBed" },
                values: new object[] { 3, 2500.00m, "Pyramid View Room", 50f, 2 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "HotelId", "Price", "RoomType", "Sqm", "TypeOfBed" },
                values: new object[] { 4, 1900.00m, "Divers Room", 40f, 2 });

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "ImageUrl", "Location", "Name" },
                values: new object[] { "ahmed.mohamed@email.com", "/assets/hotelImg/hotel1.jpg", "Cairo, Egypt", "Ahmed Mohamed Ali" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "ImageUrl", "Location" },
                values: new object[] { "fatima.hassan@email.com", "/assets/hotelImg/hotel3.jpg", "Alexandria, Egypt" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "ImageUrl", "Location" },
                values: new object[] { "mahmoud.abdullah@email.com", "/assets/hotelImg/hotel4.jpg", "Giza, Egypt" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateOfBirth", "Email", "ImageUrl", "Location", "Name", "Nationality" },
                values: new object[,]
                {
                    { 4, new DateTime(1985, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "nour.aldeen@email.com", "/assets/hotelImg/hotel6.jpg", "Dubai, UAE", "Nour Al-Din", "Emirati" },
                    { 5, new DateTime(1995, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.ahmed@email.com", "/assets/hotelImg/hotel8.jpg", "Riyadh, Saudi Arabia", "Sara Ahmed", "Saudi" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "CheckIn", "CheckOut", "GuestEmail", "GuestFullName", "GuestPhone", "RoomId", "TotalPrice", "UserId" },
                values: new object[,]
                {
                    { 4, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "nour.aldeen@email.com", "Nour Al-Din", "+971501234567", 4, 15000.00m, 4 },
                    { 5, new DateTime(2026, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.ahmed@email.com", "Sara Ahmed", "+966501234567", 5, 9500.00m, 5 }
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
                table: "Reviews",
                columns: new[] { "Id", "Comment", "HotelId", "Rate", "UserId" },
                values: new object[,]
                {
                    { 4, "Perfect location next to the Pyramids. Historic and luxurious hotel. Exceptional service.", 3, 5, 4 },
                    { 5, "Great hotel for diving. Excellent facilities but rooms need renovation.", 4, 4, 5 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Rooms_RoomId",
                table: "Images",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
