using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DALTripster.Migrations
{
    /// <inheritdoc />
    public partial class FixBrokenImageUrls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuestEmail", "GuestFullName", "GuestPhone" },
                values: new object[] { "ahmed.mohamed@email.com", "Ahmed Mohamed Ali", "+201234567890" });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GuestEmail", "GuestFullName", "GuestPhone" },
                values: new object[] { "fatima.hassan@email.com", "Fatima Hassan", "+201234567891" });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "GuestEmail", "GuestFullName", "GuestPhone" },
                values: new object[] { "mahmoud.abdullah@email.com", "Mahmoud Abdullah", "+201234567892" });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "GuestEmail", "GuestFullName", "GuestPhone" },
                values: new object[] { "nour.aldeen@email.com", "Nour Al-Din", "+971501234567" });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "GuestEmail", "GuestFullName", "GuestPhone" },
                values: new object[] { "sara.ahmed@email.com", "Sara Ahmed", "+966501234567" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/assets/hotelImg/hotel1.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/assets/roomImg/room-1.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/assets/hotelImg/hotel8.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/assets/hotelImg/hotel3.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/assets/hotelImg/hotel10.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/assets/hotelImg/hotel1.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/assets/hotelImg/hotel3.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "/assets/hotelImg/hotel4.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/assets/hotelImg/hotel6.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/assets/hotelImg/hotel8.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuestEmail", "GuestFullName", "GuestPhone" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GuestEmail", "GuestFullName", "GuestPhone" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "GuestEmail", "GuestFullName", "GuestPhone" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "GuestEmail", "GuestFullName", "GuestPhone" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "GuestEmail", "GuestFullName", "GuestPhone" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://example.com/hotels/golden-nile/exterior.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://example.com/hotels/golden-nile/royal-suite.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://example.com/hotels/north-coast/beach-view.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://example.com/hotels/pyramids/pyramid-view.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://example.com/hotels/red-sea/diving-center.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://example.com/images/users/ahmed.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://example.com/images/users/fatima.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://example.com/images/users/mahmoud.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://example.com/images/users/nour.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://example.com/images/users/sara.jpg");
        }
    }
}
