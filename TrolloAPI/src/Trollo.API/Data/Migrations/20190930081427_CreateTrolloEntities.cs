using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trollo.API.Data.Migrations
{
    public partial class CreateTrolloEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Boards",
                table => new
                {
                    Id = table.Column<Guid>(),
                    CreatedAt = table.Column<DateTime>(),
                    ModifiedAt = table.Column<DateTime>(),
                    Title = table.Column<string>(maxLength: 255),
                    Status = table.Column<string>(maxLength: 16),
                    Scope = table.Column<string>(maxLength: 16),
                    UserId = table.Column<Guid>()
                },
                constraints: table => { table.PrimaryKey("PK_Boards", x => x.Id); });

            migrationBuilder.CreateTable(
                "ListCards",
                table => new
                {
                    Id = table.Column<Guid>(),
                    CreatedAt = table.Column<DateTime>(),
                    ModifiedAt = table.Column<DateTime>(),
                    Title = table.Column<string>(maxLength: 255),
                    Order = table.Column<int>(),
                    BoardId = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListCards", x => x.Id);
                    table.ForeignKey(
                        "FK_ListCards_Boards_BoardId",
                        x => x.BoardId,
                        "Boards",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Cards",
                table => new
                {
                    Id = table.Column<Guid>(),
                    CreatedAt = table.Column<DateTime>(),
                    ModifiedAt = table.Column<DateTime>(),
                    Title = table.Column<string>(maxLength: 255),
                    Description = table.Column<string>(nullable: true),
                    Order = table.Column<int>(),
                    ListCardId = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        "FK_Cards_ListCards_ListCardId",
                        x => x.ListCardId,
                        "ListCards",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Cards_ListCardId",
                "Cards",
                "ListCardId");

            migrationBuilder.CreateIndex(
                "IX_ListCards_BoardId",
                "ListCards",
                "BoardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Cards");

            migrationBuilder.DropTable(
                "ListCards");

            migrationBuilder.DropTable(
                "Boards");
        }
    }
}