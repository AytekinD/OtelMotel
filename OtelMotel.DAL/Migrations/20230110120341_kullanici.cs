using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtelMotel.DAL.Migrations
{
    /// <inheritdoc />
    public partial class kullanici : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Kullanicilar_KullaniciAdi",
                table: "Kullanicilar");

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciAdi",
                table: "Kullanicilar",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_KullaniciAdi",
                table: "Kullanicilar",
                column: "KullaniciAdi",
                unique: true,
                filter: "[KullaniciAdi] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Kullanicilar_KullaniciAdi",
                table: "Kullanicilar");

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciAdi",
                table: "Kullanicilar",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_KullaniciAdi",
                table: "Kullanicilar",
                column: "KullaniciAdi",
                unique: true);
        }
    }
}
