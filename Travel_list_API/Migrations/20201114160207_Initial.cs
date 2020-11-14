using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel_list_API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TravelLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    Added = table.Column<bool>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    TravelListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_TravelLists_TravelListId",
                        column: x => x.TravelListId,
                        principalTable: "TravelLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    TravelListId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_TravelLists_TravelListId",
                        column: x => x.TravelListId,
                        principalTable: "TravelLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TravelLists",
                columns: new[] { "Id", "Date", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 11, 14, 17, 2, 7, 302, DateTimeKind.Local).AddTicks(264), "Test1" },
                    { 2, new DateTime(2020, 11, 14, 17, 2, 7, 303, DateTimeKind.Local).AddTicks(7518), "Test2" },
                    { 3, new DateTime(2020, 11, 14, 17, 2, 7, 303, DateTimeKind.Local).AddTicks(7544), "Test3" },
                    { 4, new DateTime(2020, 11, 14, 17, 2, 7, 303, DateTimeKind.Local).AddTicks(7550), "Test4" },
                    { 5, new DateTime(2020, 11, 14, 17, 2, 7, 303, DateTimeKind.Local).AddTicks(7553), "Test5" }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "Added", "Amount", "Category", "Name", "TravelListId" },
                values: new object[,]
                {
                    { 1, false, 1, 0, "Item 1", 1 },
                    { 2, true, 2, 0, "Item 2", 1 },
                    { 3, true, 5, 0, "Item 3", 2 },
                    { 4, false, 3, 0, "Item 4", 2 },
                    { 5, false, 1, 0, "Item 5", 3 },
                    { 6, true, 8, 0, "Item 6", 4 },
                    { 7, false, 6, 0, "Item 7", 4 },
                    { 8, true, 9, 0, "Item 8", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_TravelListId",
                table: "Item",
                column: "TravelListId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_TravelListId",
                table: "Task",
                column: "TravelListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "TravelLists");
        }
    }
}
