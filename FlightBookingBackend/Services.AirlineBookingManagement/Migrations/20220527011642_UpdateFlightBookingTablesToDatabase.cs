using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.AirlineBookingManagement.Migrations
{
    public partial class UpdateFlightBookingTablesToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingDetails",
                columns: table => new
                {
                    BookingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AirlineID = table.Column<int>(nullable: false),
                    FlightNumber = table.Column<int>(nullable: false),
                    AirlineName = table.Column<string>(nullable: true),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    MealOpted = table.Column<bool>(nullable: false),
                    NoOfPassengers = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SeatType = table.Column<string>(nullable: true),
                    PNR = table.Column<string>(nullable: true),
                    PaymentStatus = table.Column<string>(nullable: true),
                    IsCancelled = table.Column<bool>(nullable: false),
                    CreatedUserID = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetails", x => x.BookingID);
                });

            migrationBuilder.CreateTable(
                name: "BookingSeatNumberRelation",
                columns: table => new
                {
                    RefID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookingNumber = table.Column<int>(nullable: false),
                    SeatNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingSeatNumberRelation", x => x.RefID);
                    table.ForeignKey(
                        name: "FK_BookingSeatNumberRelation_BookingDetails_BookingNumber",
                        column: x => x.BookingNumber,
                        principalTable: "BookingDetails",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PassengerDetails",
                columns: table => new
                {
                    RefID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookingRefNumber = table.Column<int>(nullable: false),
                    PassengerName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerDetails", x => x.RefID);
                    table.ForeignKey(
                        name: "FK_PassengerDetails_BookingDetails_BookingRefNumber",
                        column: x => x.BookingRefNumber,
                        principalTable: "BookingDetails",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingSeatNumberRelation_BookingNumber",
                table: "BookingSeatNumberRelation",
                column: "BookingNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PassengerDetails_BookingRefNumber",
                table: "PassengerDetails",
                column: "BookingRefNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingSeatNumberRelation");

            migrationBuilder.DropTable(
                name: "PassengerDetails");

            migrationBuilder.DropTable(
                name: "BookingDetails");
        }
    }
}
