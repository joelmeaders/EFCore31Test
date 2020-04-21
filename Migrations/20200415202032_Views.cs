using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCore31Test2.Migrations
{
    public partial class Views : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Entity3s_Entity2Id",
                schema: "dbo",
                table: "Entity3s");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Entity1s",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("36471298-e1ff-4516-b1c9-add01e95de06"), "My First Entity1" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Entity1s",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("1e3942dd-e344-4da6-a822-d5e93e265626"), "My Second Entity1" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Entity2s",
                columns: new[] { "Id", "Entity1Id", "Name" },
                values: new object[] { new Guid("4e8d3154-092c-4360-b4ba-67547aa997f5"), new Guid("36471298-e1ff-4516-b1c9-add01e95de06"), "My First Entity2" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Entity2s",
                columns: new[] { "Id", "Entity1Id", "Name" },
                values: new object[] { new Guid("6bd309a0-243f-4f24-a4f2-b6dab18bc4ff"), new Guid("1e3942dd-e344-4da6-a822-d5e93e265626"), "My Second Entity2" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Entity3s",
                columns: new[] { "Id", "Entity2Id", "Name" },
                values: new object[] { new Guid("411241d5-4c77-4307-963b-ad316a37fccd"), new Guid("4e8d3154-092c-4360-b4ba-67547aa997f5"), "My First Entity3" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Entity3s",
                columns: new[] { "Id", "Entity2Id", "Name" },
                values: new object[] { new Guid("34c5d5f6-1bc1-4b28-85a7-5cd71cb4b5fc"), new Guid("4e8d3154-092c-4360-b4ba-67547aa997f5"), "My Second Entity3" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Entity3s",
                columns: new[] { "Id", "Entity2Id", "Name" },
                values: new object[] { new Guid("15196e1b-f4d7-4059-9681-a9f8ef632c12"), new Guid("6bd309a0-243f-4f24-a4f2-b6dab18bc4ff"), "My Third Entity3" });

            migrationBuilder.CreateIndex(
                name: "IX_Entity3s_Entity2Id",
                schema: "dbo",
                table: "Entity3s",
                column: "Entity2Id");

            migrationBuilder.Sql("CREATE VIEW [dbo].[ViewEntity1Entity2] " +
                "AS " +
                "SELECT        dbo.Entity1s.Id AS Entity1Id, dbo.Entity1s.Name AS Entity1Name, dbo.Entity2s.Id AS Entity2Id, dbo.Entity2s.Name AS Entity2Name " +
                "FROM            dbo.Entity1s INNER JOIN " +
                "dbo.Entity2s ON dbo.Entity1s.Id = dbo.Entity2s.Entity1Id " +
                "GO");

            migrationBuilder.Sql("CREATE VIEW [dbo].[ViewEntity2Entity3] " +
                "AS " +
                "SELECT        dbo.Entity2s.Id AS Entity2Id, dbo.Entity2s.Name AS Entity2Name, dbo.Entity3s.Id AS Entity3Id, dbo.Entity3s.Name AS Entity3Name " +
                "FROM            dbo.Entity2s LEFT OUTER JOIN " +
                "dbo.Entity3s ON dbo.Entity2s.Id = dbo.Entity3s.Entity2Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW [dbo].[ViewEntity2Entity3]");

            migrationBuilder.Sql("DROP VIEW [dbo].[ViewEntity1Entity2]");

            migrationBuilder.DropIndex(
                name: "IX_Entity3s_Entity2Id",
                schema: "dbo",
                table: "Entity3s");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Entity3s",
                keyColumn: "Id",
                keyValue: new Guid("15196e1b-f4d7-4059-9681-a9f8ef632c12"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Entity3s",
                keyColumn: "Id",
                keyValue: new Guid("34c5d5f6-1bc1-4b28-85a7-5cd71cb4b5fc"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Entity3s",
                keyColumn: "Id",
                keyValue: new Guid("411241d5-4c77-4307-963b-ad316a37fccd"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Entity2s",
                keyColumn: "Id",
                keyValue: new Guid("4e8d3154-092c-4360-b4ba-67547aa997f5"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Entity2s",
                keyColumn: "Id",
                keyValue: new Guid("6bd309a0-243f-4f24-a4f2-b6dab18bc4ff"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Entity1s",
                keyColumn: "Id",
                keyValue: new Guid("1e3942dd-e344-4da6-a822-d5e93e265626"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Entity1s",
                keyColumn: "Id",
                keyValue: new Guid("36471298-e1ff-4516-b1c9-add01e95de06"));

            migrationBuilder.CreateIndex(
                name: "IX_Entity3s_Entity2Id",
                schema: "dbo",
                table: "Entity3s",
                column: "Entity2Id",
                unique: true);
        }
    }
}
