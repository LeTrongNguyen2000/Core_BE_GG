﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserCore.EntityFrameworkCore;

#nullable disable

namespace UserCore.Migrations
{
    [DbContext(typeof(UserCoreDbContext))]
    partial class UserCoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UserCore.Entities.DonVi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<Guid?>("DonViChaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MaDonVi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiCapNhat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NguoiTao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NguoiXoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("STT")
                        .HasColumnType("int");

                    b.Property<string>("TenDonVi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenVietTat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DonVi", (string)null);
                });

            modelBuilder.Entity("UserCore.Entities.NguoiDung", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AnhDaiDien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiCapNhat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NguoiTao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NguoiXoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDangNhap")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNguoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("NguoiDung", (string)null);
                });

            modelBuilder.Entity("UserCore.Entities.NguoiDungPhongBan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiCapNhat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("NguoiDungId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NguoiTao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NguoiXoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhongBanChinh")
                        .HasColumnType("bit");

                    b.Property<Guid>("PhongBanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("STT")
                        .HasColumnType("int");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NguoiDungId");

                    b.HasIndex("PhongBanId");

                    b.ToTable("NguoiDungPhongBan", (string)null);
                });

            modelBuilder.Entity("UserCore.Entities.NguoiDungVaiTro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiCapNhat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("NguoiDungPhongBanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NguoiTao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NguoiXoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.Property<Guid>("VaiTroId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VaiTroId");

                    b.ToTable("NguoiDungVaiTro", (string)null);
                });

            modelBuilder.Entity("UserCore.Entities.PhongBan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<Guid>("DonViId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MaPhongBan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiCapNhat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NguoiTao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NguoiXoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PhongBanChaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("STT")
                        .HasColumnType("int");

                    b.Property<string>("TenPhongBan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenVietTat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DonViId");

                    b.ToTable("PhongBan", (string)null);
                });

            modelBuilder.Entity("UserCore.Entities.Quyen", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<string>("MaQuyen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiCapNhat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NguoiTao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NguoiXoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Quyen", (string)null);
                });

            modelBuilder.Entity("UserCore.Entities.VaiTro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<Guid>("DonViId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MaVaiTro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiCapNhat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NguoiTao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NguoiXoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("STT")
                        .HasColumnType("int");

                    b.Property<string>("TenVaiTro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrangThai")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DonViId");

                    b.ToTable("VaiTro", (string)null);
                });

            modelBuilder.Entity("UserCore.Entities.VaiTroQuyen", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("DaXoa")
                        .HasColumnType("bit");

                    b.Property<string>("MaQuyen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayCapNhat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayXoa")
                        .HasColumnType("datetime2");

                    b.Property<string>("NguoiCapNhat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NguoiTao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NguoiXoa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("QuyenId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VaiTroId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QuyenId");

                    b.HasIndex("VaiTroId");

                    b.ToTable("VaiTroQuyen", (string)null);
                });

            modelBuilder.Entity("UserCore.Entities.NguoiDungPhongBan", b =>
                {
                    b.HasOne("UserCore.Entities.NguoiDung", "NguoiDung")
                        .WithMany()
                        .HasForeignKey("NguoiDungId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserCore.Entities.PhongBan", "PhongBan")
                        .WithMany()
                        .HasForeignKey("PhongBanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NguoiDung");

                    b.Navigation("PhongBan");
                });

            modelBuilder.Entity("UserCore.Entities.NguoiDungVaiTro", b =>
                {
                    b.HasOne("UserCore.Entities.VaiTro", null)
                        .WithMany("NguoiDungVaiTro")
                        .HasForeignKey("VaiTroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserCore.Entities.PhongBan", b =>
                {
                    b.HasOne("UserCore.Entities.DonVi", "DonVi")
                        .WithMany("PhongBan")
                        .HasForeignKey("DonViId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonVi");
                });

            modelBuilder.Entity("UserCore.Entities.VaiTro", b =>
                {
                    b.HasOne("UserCore.Entities.DonVi", "DonVi")
                        .WithMany("VaiTro")
                        .HasForeignKey("DonViId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonVi");
                });

            modelBuilder.Entity("UserCore.Entities.VaiTroQuyen", b =>
                {
                    b.HasOne("UserCore.Entities.Quyen", "Quyen")
                        .WithMany()
                        .HasForeignKey("QuyenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserCore.Entities.VaiTro", "VaiTro")
                        .WithMany("VaiTroQuyen")
                        .HasForeignKey("VaiTroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quyen");

                    b.Navigation("VaiTro");
                });

            modelBuilder.Entity("UserCore.Entities.DonVi", b =>
                {
                    b.Navigation("PhongBan");

                    b.Navigation("VaiTro");
                });

            modelBuilder.Entity("UserCore.Entities.VaiTro", b =>
                {
                    b.Navigation("NguoiDungVaiTro");

                    b.Navigation("VaiTroQuyen");
                });
#pragma warning restore 612, 618
        }
    }
}
