using Microsoft.EntityFrameworkCore.Migrations;

namespace TwitterStatsBlazorApp.Server.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TwitterStats",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwitterStats", x => x.Key);
                });

            migrationBuilder.InsertData(
                table: "TwitterStats",
                columns: new[] { "Key", "Value" },
                values: new object[,]
                {
                    { "TotalNumberOfTweets", "0" },
                    { "AverageTweetsPerHour", "0" },
                    { "AverageTweetsPerMinute", "0" },
                    { "AverageTweetsPerSecond", "0" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TwitterStats");
        }
    }
}
