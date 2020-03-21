using Microsoft.EntityFrameworkCore.Migrations;

namespace ByTraveller.EntityFramework.Migrations
{
    public partial class modifiedthecardmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Cards");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Cards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Cards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ImageId",
                table: "Cards",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Images_ImageId",
                table: "Cards",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
