using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Travel_list_API.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "TravelLists");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "TravelLists",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "TravelLists",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TravelLists",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 11, 24, 17, 51, 17, 841, DateTimeKind.Local).AddTicks(2026), new DateTime(2020, 11, 19, 17, 51, 17, 839, DateTimeKind.Local).AddTicks(4530) });

            migrationBuilder.UpdateData(
                table: "TravelLists",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 11, 24, 17, 51, 17, 841, DateTimeKind.Local).AddTicks(2471), new DateTime(2020, 11, 19, 17, 51, 17, 841, DateTimeKind.Local).AddTicks(2457) });

            migrationBuilder.UpdateData(
                table: "TravelLists",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 11, 24, 17, 51, 17, 841, DateTimeKind.Local).AddTicks(2484), new DateTime(2020, 11, 19, 17, 51, 17, 841, DateTimeKind.Local).AddTicks(2480) });

            migrationBuilder.UpdateData(
                table: "TravelLists",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 11, 24, 17, 51, 17, 841, DateTimeKind.Local).AddTicks(2490), new DateTime(2020, 11, 19, 17, 51, 17, 841, DateTimeKind.Local).AddTicks(2487) });

            migrationBuilder.UpdateData(
                table: "TravelLists",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2020, 11, 24, 17, 51, 17, 841, DateTimeKind.Local).AddTicks(2496), new DateTime(2020, 11, 19, 17, 51, 17, 841, DateTimeKind.Local).AddTicks(2493) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "TravelLists");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "TravelLists");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "TravelLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "TravelLists",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2020, 11, 14, 17, 2, 7, 302, DateTimeKind.Local).AddTicks(264));

            migrationBuilder.UpdateData(
                table: "TravelLists",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2020, 11, 14, 17, 2, 7, 303, DateTimeKind.Local).AddTicks(7518));

            migrationBuilder.UpdateData(
                table: "TravelLists",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2020, 11, 14, 17, 2, 7, 303, DateTimeKind.Local).AddTicks(7544));

            migrationBuilder.UpdateData(
                table: "TravelLists",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2020, 11, 14, 17, 2, 7, 303, DateTimeKind.Local).AddTicks(7550));

            migrationBuilder.UpdateData(
                table: "TravelLists",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2020, 11, 14, 17, 2, 7, 303, DateTimeKind.Local).AddTicks(7553));
        }
    }
}
