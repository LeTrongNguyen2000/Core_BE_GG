using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using UserCore.Entities;

namespace UserCore.EntityFrameworkCore
{
    public static class UserCoreDbContextModelCreatingExtensions
    {
        public static void ConfigureWorks(this ModelBuilder builder)
        {
            builder.Entity<NguoiDung>(b =>
            {
                b.ToTable("NguoiDung");
            });

            builder.Entity<VaiTro>(b =>
            {
                b.ToTable("VaiTro");
            });

            builder.Entity<Quyen>(b =>
            {
                b.ToTable("Quyen");
            });

            builder.Entity<DonVi>(b =>
            {
                b.ToTable("DonVi");
            });

            builder.Entity<PhongBan>(b =>
            {
                b.ToTable("PhongBan");
            });

            builder.Entity<VaiTroQuyen>(b =>
            {
                b.ToTable("VaiTroQuyen");
            });

            builder.Entity<NguoiDungVaiTro>(b =>
            {
                b.ToTable("NguoiDungVaiTro");
            });

            builder.Entity<NguoiDungPhongBan>(b =>
            {
                b.ToTable("NguoiDungPhongBan");
            });
        }
    }
}
