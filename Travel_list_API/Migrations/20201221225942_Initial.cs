﻿using System;
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
                    TravelListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_TravelLists_TravelListId",
                        column: x => x.TravelListId,
                        principalTable: "TravelLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(2020, 12, 21, 23, 59, 41, 824, DateTimeKind.Local).AddTicks(3751), "client@gmail.com", "Pog", "Champ" });

            migrationBuilder.InsertData(
                table: "TravelLists",
                columns: new[] { "Id", "ClientId", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 12, 26, 23, 59, 41, 827, DateTimeKind.Local).AddTicks(1923), "Test1", new DateTime(2020, 12, 21, 23, 59, 41, 827, DateTimeKind.Local).AddTicks(1605) },
                    { 2, 1, new DateTime(2020, 12, 26, 23, 59, 41, 827, DateTimeKind.Local).AddTicks(2491), "Test2", new DateTime(2020, 12, 21, 23, 59, 41, 827, DateTimeKind.Local).AddTicks(2475) },
                    { 3, 1, new DateTime(2020, 12, 26, 23, 59, 41, 827, DateTimeKind.Local).AddTicks(2508), "Test3", new DateTime(2020, 12, 21, 23, 59, 41, 827, DateTimeKind.Local).AddTicks(2505) },
                    { 4, 1, new DateTime(2020, 12, 26, 23, 59, 41, 827, DateTimeKind.Local).AddTicks(2514), "Test4", new DateTime(2020, 12, 21, 23, 59, 41, 827, DateTimeKind.Local).AddTicks(2512) },
                    { 5, 1, new DateTime(2020, 12, 26, 23, 59, 41, 827, DateTimeKind.Local).AddTicks(2521), "Test5", new DateTime(2020, 12, 21, 23, 59, 41, 827, DateTimeKind.Local).AddTicks(2518) }
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

            migrationBuilder.CreateIndex(
                name: "IX_TravelLists_ClientId",
                table: "TravelLists",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "TravelLists");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}