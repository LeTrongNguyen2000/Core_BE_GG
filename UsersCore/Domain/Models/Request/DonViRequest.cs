namespace UserCore.Models
{
    /// <summary>
    /// DonViRequest
    /// </summary>
    public class DonViRequest
    {
        /// <summary>
        /// id đơn vị cha
        /// </summary>
        public Guid? DonViChaId { get; set; }

        /// <summary>
        /// mã đơn vị
        /// </summary>
        public string? MaDonVi { get; set; }

        /// <summary>
        /// tên đơn vị
        /// </summary>
        public string? TenDonVi { get; set; }

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
