﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nhom03.Data;

#nullable disable

namespace Nhom03.Migrations
{
    [DbContext(typeof(Nhom03Context))]
    partial class Nhom03ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Nhom03.Models.Chitiethoadon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Dongia")
                        .HasColumnType("int");

                    b.Property<int>("HoadonId")
                        .HasColumnType("int");

                    b.Property<int>("SanphamId")
                        .HasColumnType("int");

                    b.Property<int>("Soluong")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HoadonId");

                    b.HasIndex("SanphamId");

                    b.ToTable("Chitiethoadons");
                });

            modelBuilder.Entity("Nhom03.Models.Giohang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("SanphamId")
                        .HasColumnType("int");

                    b.Property<int>("Soluong")
                        .HasColumnType("int");

                    b.Property<int>("TaikhoanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SanphamId");

                    b.HasIndex("TaikhoanId");

                    b.ToTable("Giohangs");
                });

            modelBuilder.Entity("Nhom03.Models.Hoadon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Diachinhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mahoadon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Ngaylap")
                        .HasColumnType("datetime2");

                    b.Property<string>("Sdtnhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaikhoanId")
                        .HasColumnType("int");

                    b.Property<int>("Tongcong")
                        .HasColumnType("int");

                    b.Property<bool>("Trangthai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("TaikhoanId");

                    b.ToTable("Hoadons");
                });

            modelBuilder.Entity("Nhom03.Models.Loaisanpham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Tenloai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Trangthai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Loaisanphams");
                });

            modelBuilder.Entity("Nhom03.Models.Sanpham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Dongia")
                        .HasColumnType("int");

                    b.Property<string>("Hinhanh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoaisanphamId")
                        .HasColumnType("int");

                    b.Property<string>("Mota")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tensanpham")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tonkho")
                        .HasColumnType("int");

                    b.Property<bool>("Trangthai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("LoaisanphamId");

                    b.ToTable("Sanphams");
                });

            modelBuilder.Entity("Nhom03.Models.Taikhoan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Dangnhap")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diachi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hinhanh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hoten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Matkhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Quanly")
                        .HasColumnType("bit");

                    b.Property<string>("Sdt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Trangthai")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Taikhoans");
                });

            modelBuilder.Entity("Nhom03.Models.Chitiethoadon", b =>
                {
                    b.HasOne("Nhom03.Models.Hoadon", "Hoadon")
                        .WithMany("Chitiethoadons")
                        .HasForeignKey("HoadonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nhom03.Models.Sanpham", "Sanpham")
                        .WithMany("Chitiethoadons")
                        .HasForeignKey("SanphamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hoadon");

                    b.Navigation("Sanpham");
                });

            modelBuilder.Entity("Nhom03.Models.Giohang", b =>
                {
                    b.HasOne("Nhom03.Models.Sanpham", "Sanpham")
                        .WithMany("Giohangs")
                        .HasForeignKey("SanphamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nhom03.Models.Taikhoan", "Taikhoan")
                        .WithMany("Giohangs")
                        .HasForeignKey("TaikhoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sanpham");

                    b.Navigation("Taikhoan");
                });

            modelBuilder.Entity("Nhom03.Models.Hoadon", b =>
                {
                    b.HasOne("Nhom03.Models.Taikhoan", "Taikhoan")
                        .WithMany("Hoadons")
                        .HasForeignKey("TaikhoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Taikhoan");
                });

            modelBuilder.Entity("Nhom03.Models.Sanpham", b =>
                {
                    b.HasOne("Nhom03.Models.Loaisanpham", "Loaisanpham")
                        .WithMany("Sanphams")
                        .HasForeignKey("LoaisanphamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loaisanpham");
                });

            modelBuilder.Entity("Nhom03.Models.Hoadon", b =>
                {
                    b.Navigation("Chitiethoadons");
                });

            modelBuilder.Entity("Nhom03.Models.Loaisanpham", b =>
                {
                    b.Navigation("Sanphams");
                });

            modelBuilder.Entity("Nhom03.Models.Sanpham", b =>
                {
                    b.Navigation("Chitiethoadons");

                    b.Navigation("Giohangs");
                });

            modelBuilder.Entity("Nhom03.Models.Taikhoan", b =>
                {
                    b.Navigation("Giohangs");

                    b.Navigation("Hoadons");
                });
#pragma warning restore 612, 618
        }
    }
}