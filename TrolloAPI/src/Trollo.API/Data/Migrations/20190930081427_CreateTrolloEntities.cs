using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrolloAPI.Data.Migrations
{
    public partial class CreateTrolloEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    Status = table.Column<string>(maxLength: 16, nullable: false),
                    Scope = table.Column<string>(maxLength: 16, nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    Order = table.Column<int>(nullable: false),
                    BoardId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListCards_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    ListCardId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_ListCards_ListCardId",
                        column: x => x.ListCardId,
                        principalTable: "ListCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ListCardId",
                table: "Cards",
                column: "ListCardId");

            migrationBuilder.CreateIndex(
                name: "IX_ListCards_BoardId",
                table: "ListCards",
                column: "BoardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "ListCards");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
