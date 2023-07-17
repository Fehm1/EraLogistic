using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class SettingTableChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Settings",
                newName: "Youtube");

            migrationBuilder.RenameColumn(
                name: "Key",
                table: "Settings",
                newName: "HeaderLogo");

            migrationBuilder.AddColumn<string>(
                name: "AboutUsDescription",
                table: "Settings",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutUsWhiteTitle",
                table: "Settings",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutUsYellowTitle",
                table: "Settings",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Settings",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Settings",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Settings",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FooterLogo",
                table: "Settings",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GoogleMapsLocation",
                table: "Settings",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Settings",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LinkedIn",
                table: "Settings",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OurPackageDescription",
                table: "Settings",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OurPackageWhiteTitle",
                table: "Settings",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OurPackageYellowTitle",
                table: "Settings",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OurServiceDescription",
                table: "Settings",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OurServiceWhiteTitle",
                table: "Settings",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OurServiceYellowTitle",
                table: "Settings",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Settings",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "Settings",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoDescription",
                table: "Settings",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoLink",
                table: "Settings",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoLittleDescription",
                table: "Settings",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoWhiteTitle",
                table: "Settings",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoYellowTitle",
                table: "Settings",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WhatsApp",
                table: "Settings",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutUsDescription",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AboutUsWhiteTitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AboutUsYellowTitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "FooterLogo",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "GoogleMapsLocation",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "LinkedIn",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "OurPackageDescription",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "OurPackageWhiteTitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "OurPackageYellowTitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "OurServiceDescription",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "OurServiceWhiteTitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "OurServiceYellowTitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "VideoDescription",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "VideoLink",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "VideoLittleDescription",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "VideoWhiteTitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "VideoYellowTitle",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "WhatsApp",
                table: "Settings");

            migrationBuilder.RenameColumn(
                name: "Youtube",
                table: "Settings",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "HeaderLogo",
                table: "Settings",
                newName: "Key");
        }
    }
}
