using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Utravs.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addUnique_Seat_Flight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bookings_FlightId",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "Unique_Seat_Flight",
                table: "Bookings",
                columns: new[] { "FlightId", "SeatNumber" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Unique_Seat_Flight",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FlightId",
                table: "Bookings",
                column: "FlightId");
        }
    }
}
