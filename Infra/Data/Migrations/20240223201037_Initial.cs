using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    ID_BOOK = table.Column<Guid>(type: "uuid", nullable: false),
                    BOOK_NAME = table.Column<string>(type: "text", nullable: true),
                    BOOK_AUTHOR = table.Column<string>(type: "text", nullable: true),
                    BOOK_RESUME = table.Column<string>(type: "text", nullable: true),
                    BOOK_PLUBLICATION = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.ID_BOOK);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");
        }
    }
}
