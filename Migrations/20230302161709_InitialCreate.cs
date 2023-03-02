using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReservationApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpeningTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ClosingTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tables_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "ClosingTime", "Name", "OpeningTime" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 23, 0, 0, 0), "ABC Restaurant", new TimeSpan(0, 15, 0, 0, 0) },
                    { 2, new TimeSpan(0, 22, 0, 0, 0), "DEF Restaurant", new TimeSpan(0, 16, 0, 0, 0) },
                    { 3, new TimeSpan(0, 21, 0, 0, 0), "GHI Restaurant", new TimeSpan(0, 17, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "ABC Restaurant Address 1", 1 },
                    { 2, "DEF Restaurant Address 1", 2 },
                    { 3, "GHI Restaurant Address 1", 3 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "LocationId", "Size" },
                values: new object[,]
                {
                    { 1, 1, "Small" },
                    { 2, 1, "Small" },
                    { 3, 1, "Medium" },
                    { 4, 1, "Medium" },
                    { 5, 1, "Large" },
                    { 6, 2, "Small" },
                    { 7, 2, "Small" },
                    { 8, 2, "Medium" },
                    { 9, 2, "Medium" },
                    { 10, 2, "Medium" },
                    { 11, 2, "Large" },
                    { 12, 2, "Large" },
                    { 13, 3, "Small" },
                    { 14, 3, "Medium" },
                    { 15, 3, "Medium" },
                    { 16, 3, "Large" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_RestaurantId",
                table: "Locations",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableId",
                table: "Reservations",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_LocationId",
                table: "Tables",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
