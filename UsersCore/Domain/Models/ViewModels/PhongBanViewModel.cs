namespace UserCore.Models
{
    /// <summary>
    /// PhongBanViewModel
    /// </summary>
    public class PhongBanViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { set; get; }

        /// <summary>
        /// DonViId
        /// </summary>
        public Guid DonViId { get; set; }

        /// <summary>
        /// PhongBanChaId
        /// </summary>
        public Guid? PhongBanChaId { get; set; }

        /// <summary>
        /// MaPhongBan
        /// </summary>
        public string? MaPhongBan { get; set; }

        /// <summary>
        /// TenPhongBan
        /// </summary>
        public string? TenPhongBan { get; set; }

        /// <summary>
        /// TenVietTat
        /// </summary>
        public string? TenVietTat { get; set; }

        /// <summary>
        /// STT
        /// </summary>
        public int STT { get; set; }

        /// <summary>
        /// 0: không sử dụng, 1: sử dụng
        /// </summary>
        public int TrangThai { get; set; }
    }
}
