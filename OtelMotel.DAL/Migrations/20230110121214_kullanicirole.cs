using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtelMotel.DAL.Migrations
{
    /// <inheritdoc />
    public partial class kullanicirole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciRole_Kullanicilar_KullanicilarId",
                table: "KullaniciRole");

            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciRole_Roller_RollerId",
                table: "KullaniciRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KullaniciRole",
                table: "KullaniciRole");

            migrationBuilder.DropIndex(
                name: "IX_Kullanicilar_KullaniciAdi",
                table: "Kullanicilar");

            migrationBuilder.RenameColumn(
                name: "RollerId",
                table: "KullaniciRole",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "KullanicilarId",
                table: "KullaniciRole",
                newName: "KullaniciId");

            migrationBuilder.RenameIndex(
                name: "IX_KullaniciRole_RollerId",
                table: "KullaniciRole",
                newName: "IX_KullaniciRole_RoleId");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "KullaniciRole",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "KullaniciRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "KullaniciRole",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Update",
                table: "KullaniciRole",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Soyadi",
                table: "Kullanicilar",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

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

            migrationBuilder.AlterColumn<byte[]>(
                name: "ImageData",
                table: "Kullanicilar",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DogumTarihi",
                table: "Kullanicilar",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "Cinsiyet",
                table: "Kullanicilar",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "Kullanicilar",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KullaniciRole",
                table: "KullaniciRole",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciRole_KullaniciId",
                table: "KullaniciRole",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_KullaniciAdi",
                table: "Kullanicilar",
                column: "KullaniciAdi",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciRole_Kullanicilar_KullaniciId",
                table: "KullaniciRole",
                column: "KullaniciId",
                principalTable: "Kullanicilar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciRole_Roller_RoleId",
                table: "KullaniciRole",
                column: "RoleId",
                principalTable: "Roller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciRole_Kullanicilar_KullaniciId",
                table: "KullaniciRole");

            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciRole_Roller_RoleId",
                table: "KullaniciRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KullaniciRole",
                table: "KullaniciRole");

            migrationBuilder.DropIndex(
                name: "IX_KullaniciRole_KullaniciId",
                table: "KullaniciRole");

            migrationBuilder.DropIndex(
                name: "IX_Kullanicilar_KullaniciAdi",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "KullaniciRole");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "KullaniciRole");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "KullaniciRole");

            migrationBuilder.DropColumn(
                name: "Update",
                table: "KullaniciRole");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "KullaniciRole",
                newName: "RollerId");

            migrationBuilder.RenameColumn(
                name: "KullaniciId",
                table: "KullaniciRole",
                newName: "KullanicilarId");

            migrationBuilder.RenameIndex(
                name: "IX_KullaniciRole_RoleId",
                table: "KullaniciRole",
                newName: "IX_KullaniciRole_RollerId");

            migrationBuilder.AlterColumn<string>(
                name: "Soyadi",
                table: "Kullanicilar",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciAdi",
                table: "Kullanicilar",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<byte[]>(
                name: "ImageData",
                table: "Kullanicilar",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DogumTarihi",
                table: "Kullanicilar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Cinsiyet",
                table: "Kullanicilar",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adi",
                table: "Kullanicilar",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KullaniciRole",
                table: "KullaniciRole",
                columns: new[] { "KullanicilarId", "RollerId" });

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_KullaniciAdi",
                table: "Kullanicilar",
                column: "KullaniciAdi",
                unique: true,
                filter: "[KullaniciAdi] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciRole_Kullanicilar_KullanicilarId",
                table: "KullaniciRole",
                column: "KullanicilarId",
                principalTable: "Kullanicilar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciRole_Roller_RollerId",
                table: "KullaniciRole",
                column: "RollerId",
                principalTable: "Roller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
