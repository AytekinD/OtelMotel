using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtelMotel.DAL.Migrations
{
    /// <inheritdoc />
    public partial class migimagepath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Kullanicilar",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Kullanicilar");
        }
    }
}
