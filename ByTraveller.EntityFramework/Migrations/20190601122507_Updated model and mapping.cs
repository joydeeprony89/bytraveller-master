using Microsoft.EntityFrameworkCore.Migrations;

namespace ByTraveller.EntityFramework.Migrations
{
    public partial class Updatedmodelandmapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Images_CardGalleryImageId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_CardGalleryImageId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "RedirectUrl",
                table: "SubMenuItems");

            migrationBuilder.DropColumn(
                name: "CardGalleryImageId",
                table: "Cards");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubMenuItems",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HeaderSubMenus",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HeaderMainMenus",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Cards",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cards",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Cards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PlaceDescription",
                table: "CardDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CardDetails",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Images_ImageId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_ImageId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Cards");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubMenuItems",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "RedirectUrl",
                table: "SubMenuItems",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HeaderSubMenus",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HeaderMainMenus",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Cards",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cards",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AddColumn<int>(
                name: "CardGalleryImageId",
                table: "Cards",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PlaceDescription",
                table: "CardDetails",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CardDetails",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CardGalleryImageId",
                table: "Cards",
                column: "CardGalleryImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Images_CardGalleryImageId",
                table: "Cards",
                column: "CardGalleryImageId",
                principalTable: "Images",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
