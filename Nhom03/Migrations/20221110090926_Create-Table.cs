using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nhom03.Migrations
{
    public partial class CreateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loaisanphams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenloai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trangthai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loaisanphams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taikhoans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dangnhap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Matkhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diachi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hoten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quanly = table.Column<bool>(type: "bit", nullable: false),
                    Hinhanh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trangthai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taikhoans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sanphams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tensanpham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dongia = table.Column<int>(type: "int", nullable: false),
                    Tonkho = table.Column<int>(type: "int", nullable: false),
                    LoaisanphamId = table.Column<int>(type: "int", nullable: false),
                    Hinhanh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trangthai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanphams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sanphams_Loaisanphams_LoaisanphamId",
                        column: x => x.LoaisanphamId,
                        principalTable: "Loaisanphams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hoadons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mahoadon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaikhoanId = table.Column<int>(type: "int", nullable: false),
                    Ngaylap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diachinhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sdtnhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tongcong = table.Column<int>(type: "int", nullable: false),
                    Trangthai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoadons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hoadons_Taikhoans_TaikhoanId",
                        column: x => x.TaikhoanId,
                        principalTable: "Taikhoans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Giohangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaikhoanId = table.Column<int>(type: "int", nullable: false),
                    SanphamId = table.Column<int>(type: "int", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giohangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Giohangs_Sanphams_SanphamId",
                        column: x => x.SanphamId,
                        principalTable: "Sanphams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Giohangs_Taikhoans_TaikhoanId",
                        column: x => x.TaikhoanId,
                        principalTable: "Taikhoans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chitiethoadons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoadonId = table.Column<int>(type: "int", nullable: false),
                    SanphamId = table.Column<int>(type: "int", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    Dongia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chitiethoadons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chitiethoadons_Hoadons_HoadonId",
                        column: x => x.HoadonId,
                        principalTable: "Hoadons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chitiethoadons_Sanphams_SanphamId",
                        column: x => x.SanphamId,
                        principalTable: "Sanphams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chitiethoadons_HoadonId",
                table: "Chitiethoadons",
                column: "HoadonId");

            migrationBuilder.CreateIndex(
                name: "IX_Chitiethoadons_SanphamId",
                table: "Chitiethoadons",
                column: "SanphamId");

            migrationBuilder.CreateIndex(
                name: "IX_Giohangs_SanphamId",
                table: "Giohangs",
                column: "SanphamId");

            migrationBuilder.CreateIndex(
                name: "IX_Giohangs_TaikhoanId",
                table: "Giohangs",
                column: "TaikhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Hoadons_TaikhoanId",
                table: "Hoadons",
                column: "TaikhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Sanphams_LoaisanphamId",
                table: "Sanphams",
                column: "LoaisanphamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chitiethoadons");

            migrationBuilder.DropTable(
                name: "Giohangs");

            migrationBuilder.DropTable(
                name: "Hoadons");

            migrationBuilder.DropTable(
                name: "Sanphams");

            migrationBuilder.DropTable(
                name: "Taikhoans");

            migrationBuilder.DropTable(
                name: "Loaisanphams");
        }
    }
}
