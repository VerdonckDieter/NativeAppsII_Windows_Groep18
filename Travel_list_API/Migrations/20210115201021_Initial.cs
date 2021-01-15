using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel_list_API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelLists_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelListId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_TravelLists_TravelListId",
                        column: x => x.TravelListId,
                        principalTable: "TravelLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelListId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    Added = table.Column<bool>(nullable: false),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_TravelLists_TravelListId",
                        column: x => x.TravelListId,
                        principalTable: "TravelLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Itineraries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelListId = table.Column<int>(nullable: false),
                    StartLatitude = table.Column<double>(nullable: false),
                    StartLongitude = table.Column<double>(nullable: false),
                    EndLatitude = table.Column<double>(nullable: false),
                    EndLongitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itineraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Itineraries_TravelLists_TravelListId",
                        column: x => x.TravelListId,
                        principalTable: "TravelLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelListId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_TravelLists_TravelListId",
                        column: x => x.TravelListId,
                        principalTable: "TravelLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(2021, 1, 15, 21, 10, 21, 86, DateTimeKind.Local).AddTicks(5753), "client@gmail.com", "Pog", "Champ" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "LastName" },
                values: new object[] { 2, new DateTime(2021, 1, 15, 21, 10, 21, 88, DateTimeKind.Local).AddTicks(3668), "client2@gmail.com", "Ayaya", "Clap" });

            migrationBuilder.InsertData(
                table: "TravelLists",
                columns: new[] { "Id", "ClientId", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 1, 20, 21, 10, 21, 89, DateTimeKind.Local).AddTicks(3608), "Spanje", new DateTime(2021, 1, 15, 21, 10, 21, 89, DateTimeKind.Local).AddTicks(3277) },
                    { 2, 1, new DateTime(2021, 1, 20, 21, 10, 21, 89, DateTimeKind.Local).AddTicks(4174), "Frankrijk", new DateTime(2021, 1, 15, 21, 10, 21, 89, DateTimeKind.Local).AddTicks(4153) },
                    { 3, 1, new DateTime(2021, 1, 20, 21, 10, 21, 89, DateTimeKind.Local).AddTicks(4191), "Nederland", new DateTime(2021, 1, 15, 21, 10, 21, 89, DateTimeKind.Local).AddTicks(4188) },
                    { 4, 2, new DateTime(2021, 1, 20, 21, 10, 21, 89, DateTimeKind.Local).AddTicks(4197), "Duitsland", new DateTime(2021, 1, 15, 21, 10, 21, 89, DateTimeKind.Local).AddTicks(4195) },
                    { 5, 2, new DateTime(2021, 1, 20, 21, 10, 21, 89, DateTimeKind.Local).AddTicks(4203), "Noorwegen", new DateTime(2021, 1, 15, 21, 10, 21, 89, DateTimeKind.Local).AddTicks(4201) }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "TravelListId" },
                values: new object[,]
                {
                    { 1, "Opmaak", 1 },
                    { 8, "Kledij", 2 },
                    { 6, "Technologie", 2 },
                    { 5, "Opmaak", 2 },
                    { 7, "Bad", 2 },
                    { 4, "Kledij", 1 },
                    { 3, "Bad", 1 },
                    { 2, "Technologie", 1 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Added", "Amount", "Category", "Name", "TravelListId" },
                values: new object[,]
                {
                    { 2, true, 2, "Technologie", "Laptop", 1 },
                    { 7, false, 6, "Kledij", "Broek", 4 },
                    { 3, true, 5, "Bad", "Handdoek", 2 },
                    { 4, false, 3, "Bad", "Tandenborstel", 2 },
                    { 5, false, 1, "Technologie", "Batterij", 3 },
                    { 6, true, 8, "Bad", "Shampoo", 4 },
                    { 1, false, 1, "Opmaak", "Kam", 1 },
                    { 8, true, 9, "Kledij", "Sjaal", 5 }
                });

            migrationBuilder.InsertData(
                table: "Itineraries",
                columns: new[] { "Id", "EndLatitude", "EndLongitude", "StartLatitude", "StartLongitude", "TravelListId" },
                values: new object[,]
                {
                    { 1, 41.385063000000002, 2.1734040000000001, 51.054340000000003, 3.7174239999999998, 1 },
                    { 2, 48.856613000000003, 2.3522219999999998, 51.054340000000003, 3.7174239999999998, 2 },
                    { 3, 52.370215999999999, 4.895168, 51.054340000000003, 3.7174239999999998, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_TravelListId",
                table: "Categories",
                column: "TravelListId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_TravelListId",
                table: "Items",
                column: "TravelListId");

            migrationBuilder.CreateIndex(
                name: "IX_Itineraries_TravelListId",
                table: "Itineraries",
                column: "TravelListId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TravelListId",
                table: "Tasks",
                column: "TravelListId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelLists_ClientId",
                table: "TravelLists",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Itineraries");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "TravelLists");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
