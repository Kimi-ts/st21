using Microsoft.EntityFrameworkCore.Migrations;

namespace StCore21.Migrations
{
    public partial class CreateSiteConfigSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PageDataItems",
                columns: table => new
                {
                    PageDataId = table.Column<string>(nullable: false),
                    PageName = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    MetaDescription = table.Column<string>(nullable: false),
                    MetaKeywords = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageDataItems", x => x.PageDataId);
                });

            migrationBuilder.CreateTable(
                name: "SiteConfig",
                columns: table => new
                {
                    SiteConfigId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PartnerPhones = table.Column<string>(nullable: false),
                    ClientPhones = table.Column<string>(nullable: false),
                    PartnerEmails = table.Column<string>(nullable: false),
                    ClientEmails = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    PostCode = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    OpenHours = table.Column<string>(nullable: false),
                    CloseHours = table.Column<string>(nullable: false),
                    WorkingDaysString = table.Column<string>(nullable: false),
                    WorkingDays = table.Column<string>(nullable: false),
                    OfficialLicence = table.Column<string>(nullable: false),
                    OfficialInfo = table.Column<string>(nullable: false),
                    Copyright = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteConfig", x => x.SiteConfigId);
                });

            migrationBuilder.CreateTable(
                name: "SocialNetworkItems",
                columns: table => new
                {
                    SocialNetworkItemId = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    IconClass = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialNetworkItems", x => x.SocialNetworkItemId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PageDataItems");

            migrationBuilder.DropTable(
                name: "SiteConfig");

            migrationBuilder.DropTable(
                name: "SocialNetworkItems");
        }
    }
}
