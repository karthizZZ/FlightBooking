using Microsoft.EntityFrameworkCore.Migrations;

namespace Services.AirlineInventoryManagement.Migrations
{
    public partial class UpdateFlightInventoryTablesToDatabase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AirlineSeatCostRelation_AirlineSchedule_AirlineID",
                table: "AirlineSeatCostRelation");

            migrationBuilder.DropIndex(
                name: "IX_AirlineSeatCostRelation_AirlineID",
                table: "AirlineSeatCostRelation");

            migrationBuilder.DropColumn(
                name: "AirlineID",
                table: "AirlineSeatCostRelation");

            migrationBuilder.CreateIndex(
                name: "IX_AirlineSeatCostRelation_FlightID",
                table: "AirlineSeatCostRelation",
                column: "FlightID");

            migrationBuilder.AddForeignKey(
                name: "FK_AirlineSeatCostRelation_AirlineSchedule_FlightID",
                table: "AirlineSeatCostRelation",
                column: "FlightID",
                principalTable: "AirlineSchedule",
                principalColumn: "AirlineID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AirlineSeatCostRelation_AirlineSchedule_FlightID",
                table: "AirlineSeatCostRelation");

            migrationBuilder.DropIndex(
                name: "IX_AirlineSeatCostRelation_FlightID",
                table: "AirlineSeatCostRelation");

            migrationBuilder.AddColumn<int>(
                name: "AirlineID",
                table: "AirlineSeatCostRelation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AirlineSeatCostRelation_AirlineID",
                table: "AirlineSeatCostRelation",
                column: "AirlineID");

            migrationBuilder.AddForeignKey(
                name: "FK_AirlineSeatCostRelation_AirlineSchedule_AirlineID",
                table: "AirlineSeatCostRelation",
                column: "AirlineID",
                principalTable: "AirlineSchedule",
                principalColumn: "AirlineID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
