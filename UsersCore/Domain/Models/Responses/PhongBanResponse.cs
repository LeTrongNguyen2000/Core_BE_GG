namespace UserCore.Models
{
    /// <summary>
    /// PhongBanResponse
    /// </summary>
    public class PhongBanResponse : BaseResponse
    {
        /// <summary>
        /// đơn vị id
        /// </summary>
        public Guid DonViId { get; set; }

        /// <summary>
        /// phòng ban cha id
        /// </summary>
        public Guid? PhongBanChaId { get; set; }

       /// <summary>
       /// Mã phong ban
       /// </summary>
        public string? MaPhongBan { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string? TenPhongBan { get; set; }

        /// <summary>
        /// Tên viết tắt
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
