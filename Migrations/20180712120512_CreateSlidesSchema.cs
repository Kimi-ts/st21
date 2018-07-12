using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StCore21.Migrations
{
    public partial class CreateSlidesSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SliderItems",
                columns: table => new
                {
                    SliderItemId = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    OrderNumber = table.Column<int>(nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SliderItems", x => x.SliderItemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SliderItems");
        }
    }
}
