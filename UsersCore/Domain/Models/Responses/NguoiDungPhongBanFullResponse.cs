namespace UserCore.Models
{
    /// <summary>
    /// NguoiDungPhongBanResponse
    /// </summary>
    public class NguoiDungPhongBanFullResponse
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Stt
        /// </summary>
        public int STT { get; set; }

        /// <summary>
        /// NguoiDungId
        /// </summary>
        public Guid NguoiDungId { get; set; }

        /// <summary>
        /// PhongBanId
        /// </summary>
        public Guid PhongBanId { get; set; }

        /// <summary>
        /// PhongBanChinh
        /// </summary>
        public bool PhongBanChinh { get; set; }

        /// <summary>
        /// 0: không sử dụng, 1: sử dụng
        /// </summary>
        public int TrangThai { get; set; } = 1;

        /// <summary>
        /// PhongBan
        /// </summary>
        public PhongBanViewModel? PhongBan { get; set; }

        /// <summary>
        /// Dơn Vị
        /// </summary>
        public DonViViewModel? DonVi { get; set; }

        /// <summary>
        /// NguoiDungVaiTro
        /// </summary>
        public VaiTroViewModel? VaiTro { get; set; }
    }
}
