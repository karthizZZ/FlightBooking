using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.AirlineInventoryManagement.Migrations
{
    public partial class UpdateFlightInventoryTablesToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirlineBrand",
                columns: table => new
                {
                    AirlineBrandID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrandName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineBrand", x => x.AirlineBrandID);
                });

            migrationBuilder.CreateTable(
                name: "AirlineComapny",
                columns: table => new
                {
                    AirlineCompanyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineComapny", x => x.AirlineCompanyID);
                });

            migrationBuilder.CreateTable(
                name: "AirlineInstrument",
                columns: table => new
                {
                    AirlineInstrumentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InstrumentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineInstrument", x => x.AirlineInstrumentID);
                });

            migrationBuilder.CreateTable(
                name: "Airport",
                columns: table => new
                {
                    AirportID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AirportName = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    AirportCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airport", x => x.AirportID);
                });

            migrationBuilder.CreateTable(
                name: "SeatType",
                columns: table => new
                {
                    SeatTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SeatType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatType", x => x.SeatTypeID);
                });

            migrationBuilder.CreateTable(
                name: "AirlineSchedule",
                columns: table => new
                {
                    AirlineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlightNumber = table.Column<int>(nullable: false),
                    AirlineBrand = table.Column<int>(nullable: false),
                    AirlineInstrument = table.Column<int>(nullable: false),
                    AirlineCompany = table.Column<int>(nullable: false),
                    FromLocation = table.Column<int>(nullable: true),
                    ToLocation = table.Column<int>(nullable: true),
                    startTime = table.Column<DateTime>(nullable: false),
                    endTime = table.Column<DateTime>(nullable: false),
                    mealType = table.Column<string>(nullable: true),
                    IsDaily = table.Column<bool>(nullable: false),
                    IsWeekly = table.Column<bool>(nullable: false),
                    IsWeekends = table.Column<bool>(nullable: false),
                    IsSpecificDays = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsBlocked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineSchedule", x => x.AirlineID);
                    table.ForeignKey(
                        name: "FK_AirlineSchedule_AirlineBrand_AirlineBrand",
                        column: x => x.AirlineBrand,
                        principalTable: "AirlineBrand",
                        principalColumn: "AirlineBrandID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AirlineSchedule_AirlineComapny_AirlineCompany",
                        column: x => x.AirlineCompany,
                        principalTable: "AirlineComapny",
                        principalColumn: "AirlineCompanyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AirlineSchedule_AirlineInstrument_AirlineInstrument",
                        column: x => x.AirlineInstrument,
                        principalTable: "AirlineInstrument",
                        principalColumn: "AirlineInstrumentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AirlineSchedule_Airport_FromLocation",
                        column: x => x.FromLocation,
                        principalTable: "Airport",
                        principalColumn: "AirportID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AirlineSchedule_Airport_ToLocation",
                        column: x => x.ToLocation,
                        principalTable: "Airport",
                        principalColumn: "AirportID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AirlineScheduleDayRelation",
                columns: table => new
                {
                    RefID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AirlineScheduleID = table.Column<int>(nullable: false),
                    AirlineID = table.Column<int>(nullable: false),
                    weekDay = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineScheduleDayRelation", x => x.RefID);
                    table.ForeignKey(
                        name: "FK_AirlineScheduleDayRelation_AirlineSchedule_AirlineID",
                        column: x => x.AirlineID,
                        principalTable: "AirlineSchedule",
                        principalColumn: "AirlineID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AirlineSeatCostRelation",
                columns: table => new
                {
                    RefID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlightID = table.Column<int>(nullable: false),
                    AirlineID = table.Column<int>(nullable: true),
                    SeatTypeID = table.Column<int>(nullable: false),
                    NoOfSeats = table.Column<int>(nullable: false),
                    TicketCost = table.Column<double>(nullable: false),
                    Tax = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirlineSeatCostRelation", x => x.RefID);
                    table.ForeignKey(
                        name: "FK_AirlineSeatCostRelation_AirlineSchedule_AirlineID",
                        column: x => x.AirlineID,
                        principalTable: "AirlineSchedule",
                        principalColumn: "AirlineID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AirlineSeatCostRelation_SeatType_SeatTypeID",
                        column: x => x.SeatTypeID,
                        principalTable: "SeatType",
                        principalColumn: "SeatTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirlineSchedule_AirlineBrand",
                table: "AirlineSchedule",
                column: "AirlineBrand");

            migrationBuilder.CreateIndex(
                name: "IX_AirlineSchedule_AirlineCompany",
                table: "AirlineSchedule",
                column: "AirlineCompany");

            migrationBuilder.CreateIndex(
                name: "IX_AirlineSchedule_AirlineInstrument",
                table: "AirlineSchedule",
                column: "AirlineInstrument");

            migrationBuilder.CreateIndex(
                name: "IX_AirlineSchedule_FromLocation",
                table: "AirlineSchedule",
                column: "FromLocation");

            migrationBuilder.CreateIndex(
                name: "IX_AirlineSchedule_ToLocation",
                table: "AirlineSchedule",
                column: "ToLocation");

            migrationBuilder.CreateIndex(
                name: "IX_AirlineScheduleDayRelation_AirlineID",
                table: "AirlineScheduleDayRelation",
                column: "AirlineID");

            migrationBuilder.CreateIndex(
                name: "IX_AirlineSeatCostRelation_AirlineID",
                table: "AirlineSeatCostRelation",
                column: "AirlineID");

            migrationBuilder.CreateIndex(
                name: "IX_AirlineSeatCostRelation_SeatTypeID",
                table: "AirlineSeatCostRelation",
                column: "SeatTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirlineScheduleDayRelation");

            migrationBuilder.DropTable(
                name: "AirlineSeatCostRelation");

            migrationBuilder.DropTable(
                name: "AirlineSchedule");

            migrationBuilder.DropTable(
                name: "SeatType");

            migrationBuilder.DropTable(
                name: "AirlineBrand");

            migrationBuilder.DropTable(
                name: "AirlineComapny");

            migrationBuilder.DropTable(
                name: "AirlineInstrument");

            migrationBuilder.DropTable(
                name: "Airport");
        }
    }
}
