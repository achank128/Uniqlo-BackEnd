using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uniqlo.Models.Migrations
{
    public partial class update6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageType",
                table: "CollectionPosts",
                newName: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "CollectionPosts",
                newName: "ImageType");
        }
    }
}
