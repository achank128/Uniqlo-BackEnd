using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uniqlo.Models.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Units",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameVi",
                table: "Units",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Sizes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameVi",
                table: "Sizes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionVi",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaterialsEn",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaterialsVi",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameVi",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OverviewEn",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OverviewVi",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "GenderTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameVi",
                table: "GenderTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "Coupons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionVi",
                table: "Coupons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleEn",
                table: "Coupons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleVi",
                table: "Coupons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Colors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameVi",
                table: "Colors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentEn",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentVi",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionVi",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsShow",
                table: "Collections",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameVi",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "CollectionPosts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionVi",
                table: "CollectionPosts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleEn",
                table: "CollectionPosts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleVi",
                table: "CollectionPosts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionEn",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionVi",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameVi",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "NameVi",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "NameVi",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DescriptionVi",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MaterialsEn",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MaterialsVi",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NameVi",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OverviewEn",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OverviewVi",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "GenderTypes");

            migrationBuilder.DropColumn(
                name: "NameVi",
                table: "GenderTypes");

            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "DescriptionVi",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "TitleEn",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "TitleVi",
                table: "Coupons");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "NameVi",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "ContentEn",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "ContentVi",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "DescriptionVi",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "IsShow",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "NameVi",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "CollectionPosts");

            migrationBuilder.DropColumn(
                name: "DescriptionVi",
                table: "CollectionPosts");

            migrationBuilder.DropColumn(
                name: "TitleEn",
                table: "CollectionPosts");

            migrationBuilder.DropColumn(
                name: "TitleVi",
                table: "CollectionPosts");

            migrationBuilder.DropColumn(
                name: "DescriptionEn",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DescriptionVi",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "NameVi",
                table: "Categories");
        }
    }
}
