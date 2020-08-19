using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageBoard.Migrations
{
    public partial class DataSeedingForPostMessagesUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "BoardId", "Description", "Name" },
                values: new object[,]
                {
                    { 2, "A place where we can share cute things our pets have done", "Pets" },
                    { 3, "Trading nutrition tips, recipes, and support", "Diet/Nutrition" },
                    { 4, "A friendly chat about what video games we are playing these days", "Video Games" },
                    { 5, "Best places to eat around Portland", "Eats!" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "BoardId", "DatePosted", "Title" },
                values: new object[] { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "JavaScript" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "BoardId", "DatePosted", "Title" },
                values: new object[] { 3, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dogs" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "BoardId",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Body", "DatePosted", "Heading", "PostId" },
                values: new object[] { 1, "JK! C# Rocks.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C# Sucks!", 1 });
        }
    }
}
