using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtelMotel.DAL.Migrations
{
    /// <inheritdoc />
    public partial class miginitKullanici : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "Rezervasyonlar");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "RezervasyonDetaylari");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "Odalar");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "OdaFiyatlari");

            migrationBuilder.DropColumn(
                name: "CreateUser",
                table: "Musteriler");

            migrationBuilder.RenameColumn(
                name: "CreateUser",
                table: "Kullanicilar",
                newName: "KullaniciId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KullaniciId",
                table: "Kullanicilar",
                newName: "CreateUser");

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "Rezervasyonlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "RezervasyonDetaylari",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "Odalar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "OdaFiyatlari",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreateUser",
                table: "Musteriler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
