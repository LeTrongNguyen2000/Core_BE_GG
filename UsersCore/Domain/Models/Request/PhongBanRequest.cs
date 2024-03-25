namespace UserCore.Models
{
    /// <summary>
    /// PhongBanRequest
    /// </summary>
    public class PhongBanRequest
    {
        /// <summary>
        /// id đơn vị
        /// </summary>
        public Guid DonViId { get; set; }

        /// <summary>
        /// id phòng ban cha
        /// </summary>
        public Guid? PhongBanChaId { get; set; }

        /// <summary>
        /// mã phòng ban
        /// </summary>
        public string? MaPhongBan { get; set; }

        /// <summary>
        /// tên phòng ban
        /// </summary>
        public string? TenPhongBan { get; set; }

        /// <summary>
        /// tên viết tắt
        /// </summary>
        public string? TenVietTat { get; set; }

        /// <summary>
        /// 0: không sử dụng, 1: sử dụng
        /// </summary>
        public int TrangThai { get; set; }
    }
}
