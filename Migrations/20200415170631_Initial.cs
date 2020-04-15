using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCore31Test2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Entity1s",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity1s", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entity2s",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Entity1Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity2s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entity2s_Entity1s_Entity1Id",
                        column: x => x.Entity1Id,
                        principalSchema: "dbo",
                        principalTable: "Entity1s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entity3s",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Entity2Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity3s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entity3s_Entity2s_Entity2Id",
                        column: x => x.Entity2Id,
                        principalSchema: "dbo",
                        principalTable: "Entity2s",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entity2s_Entity1Id",
                schema: "dbo",
                table: "Entity2s",
                column: "Entity1Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entity3s_Entity2Id",
                schema: "dbo",
                table: "Entity3s",
                column: "Entity2Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entity3s",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Entity2s",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Entity1s",
                schema: "dbo");
        }
    }
}
