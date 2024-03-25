using Microsoft.EntityFrameworkCore;
using UserCore.Entities;

namespace UserCore.EntityFrameworkCore
{
    public class UserCoreDbContext : DbContext
    {
        public UserCoreDbContext(DbContextOptions<UserCoreDbContext> options) : base(options)
        {
        }
        // Define your DbSet properties for each entity
        public DbSet<VaiTro> VaiTro { get; set; }
        public DbSet<NguoiDung> NguoiDung { get; set; }
        public DbSet<PhongBan> PhongBan { get; set; }
        public DbSet<DonVi> DonVi { get; set; }
        public DbSet<Quyen> Quyen { get; set; }
        public DbSet<VaiTroQuyen> VaiTroQuyen { get; set; }
        public DbSet<NguoiDungPhongBan> NguoiDungPhong { get; set; }
        public DbSet<NguoiDungVaiTro> NguoiDungVaiTro { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureWorks();
        }
    }
}
