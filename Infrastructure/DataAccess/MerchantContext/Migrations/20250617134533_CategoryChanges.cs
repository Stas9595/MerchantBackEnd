using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.DataAccess.MerchantContext.Migrations
{
    /// <inheritdoc />
    public partial class CategoryChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Merchants_Categories_CategoryId",
                table: "Merchants");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("49736306-53ae-4165-97c1-9990c87e6693"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("66730fda-6d11-4bb3-b1e3-204d59532754"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9dbea900-b22b-4ac4-a926-189371288d7d"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Created", "Name" },
                values: new object[,]
                {
                    { new Guid("06465c4a-ec41-4719-b623-707a69b101e6"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Food" },
                    { new Guid("19730707-bc92-40c0-9536-767ba936310a"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Services" },
                    { new Guid("e7955452-b93c-420f-a0c5-47b4117f4921"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Retail" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Merchants_Categories_CategoryId",
                table: "Merchants",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Merchants_Categories_CategoryId",
                table: "Merchants");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("06465c4a-ec41-4719-b623-707a69b101e6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("19730707-bc92-40c0-9536-767ba936310a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e7955452-b93c-420f-a0c5-47b4117f4921"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Created", "Name" },
                values: new object[,]
                {
                    { new Guid("49736306-53ae-4165-97c1-9990c87e6693"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Food" },
                    { new Guid("66730fda-6d11-4bb3-b1e3-204d59532754"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Services" },
                    { new Guid("9dbea900-b22b-4ac4-a926-189371288d7d"), new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Retail" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Merchants_Categories_CategoryId",
                table: "Merchants",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
