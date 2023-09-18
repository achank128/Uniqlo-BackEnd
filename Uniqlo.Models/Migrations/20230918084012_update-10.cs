using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uniqlo.Models.Migrations
{
    public partial class update10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Reviews");

            migrationBuilder.AlterColumn<int>(
                name: "Fit",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_SizeId",
                table: "Reviews",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Sizes_SizeId",
                table: "Reviews",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Sizes_SizeId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_SizeId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "Reviews");

            migrationBuilder.AlterColumn<string>(
                name: "Fit",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
