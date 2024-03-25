namespace UserCore.Models
{
    /// <summary>
    /// DonViResponse
    /// </summary>
    public class DonViResponse : BaseResponse
    {
        /// <summary>
        /// đơn vị cha id
        /// </summary>
        public Guid? DonViChaId { get; set; }

        /// <summary>
        /// mã đơn vị
        /// </summary>
        public string? MaDonVi { get; set; }

        /// <summary>
        /// Tên đơn vị
        /// </summary>
        public string? TenDonVi { get; set; }

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
