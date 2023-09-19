using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Uniqlo.Models.Migrations
{
    public partial class update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "WardId",
                table: "UserAddresses");

            migrationBuilder.RenameColumn(
                name: "Details",
                table: "Shipments",
                newName: "Note");

            migrationBuilder.AddColumn<string>(
                name: "DistrictCode",
                table: "UserAddresses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProvinceCode",
                table: "UserAddresses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WardCode",
                table: "UserAddresses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "administrative_regions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name_en = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    code_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_name_en = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrative_regions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "administrative_units",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    full_name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    short_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    short_name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_name_en = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrative_units", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "provinces",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    full_name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    administrative_unit_id = table.Column<int>(type: "int", nullable: false),
                    administrative_region_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provinces", x => x.code);
                    table.ForeignKey(
                        name: "FK_provinces_administrative_regions_administrative_region_id",
                        column: x => x.administrative_region_id,
                        principalTable: "administrative_regions",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_provinces_administrative_units_administrative_unit_id",
                        column: x => x.administrative_unit_id,
                        principalTable: "administrative_units",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "districts",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    full_name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    province_code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    administrative_unit_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_districts", x => x.code);
                    table.ForeignKey(
                        name: "FK_districts_administrative_units_administrative_unit_id",
                        column: x => x.administrative_unit_id,
                        principalTable: "administrative_units",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_districts_provinces_province_code",
                        column: x => x.province_code,
                        principalTable: "provinces",
                        principalColumn: "code");
                });

            migrationBuilder.CreateTable(
                name: "wards",
                columns: table => new
                {
                    code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    full_name_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    district_code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    administrative_unit_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wards", x => x.code);
                    table.ForeignKey(
                        name: "FK_wards_administrative_units_administrative_unit_id",
                        column: x => x.administrative_unit_id,
                        principalTable: "administrative_units",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_wards_districts_district_code",
                        column: x => x.district_code,
                        principalTable: "districts",
                        principalColumn: "code");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_DistrictCode",
                table: "UserAddresses",
                column: "DistrictCode");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_ProvinceCode",
                table: "UserAddresses",
                column: "ProvinceCode");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_WardCode",
                table: "UserAddresses",
                column: "WardCode");

            migrationBuilder.CreateIndex(
                name: "IX_districts_administrative_unit_id",
                table: "districts",
                column: "administrative_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_districts_province_code",
                table: "districts",
                column: "province_code");

            migrationBuilder.CreateIndex(
                name: "IX_provinces_administrative_region_id",
                table: "provinces",
                column: "administrative_region_id");

            migrationBuilder.CreateIndex(
                name: "IX_provinces_administrative_unit_id",
                table: "provinces",
                column: "administrative_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_wards_administrative_unit_id",
                table: "wards",
                column: "administrative_unit_id");

            migrationBuilder.CreateIndex(
                name: "IX_wards_district_code",
                table: "wards",
                column: "district_code");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_districts_DistrictCode",
                table: "UserAddresses",
                column: "DistrictCode",
                principalTable: "districts",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_provinces_ProvinceCode",
                table: "UserAddresses",
                column: "ProvinceCode",
                principalTable: "provinces",
                principalColumn: "code");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAddresses_wards_WardCode",
                table: "UserAddresses",
                column: "WardCode",
                principalTable: "wards",
                principalColumn: "code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresses_districts_DistrictCode",
                table: "UserAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresses_provinces_ProvinceCode",
                table: "UserAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAddresses_wards_WardCode",
                table: "UserAddresses");

            migrationBuilder.DropTable(
                name: "wards");

            migrationBuilder.DropTable(
                name: "districts");

            migrationBuilder.DropTable(
                name: "provinces");

            migrationBuilder.DropTable(
                name: "administrative_regions");

            migrationBuilder.DropTable(
                name: "administrative_units");

            migrationBuilder.DropIndex(
                name: "IX_UserAddresses_DistrictCode",
                table: "UserAddresses");

            migrationBuilder.DropIndex(
                name: "IX_UserAddresses_ProvinceCode",
                table: "UserAddresses");

            migrationBuilder.DropIndex(
                name: "IX_UserAddresses_WardCode",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "DistrictCode",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "ProvinceCode",
                table: "UserAddresses");

            migrationBuilder.DropColumn(
                name: "WardCode",
                table: "UserAddresses");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Shipments",
                newName: "Details");

            migrationBuilder.AddColumn<string>(
                name: "DistrictId",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProvinceId",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WardId",
                table: "UserAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
