namespace UserCore.Models
{
    /// <summary>
    /// DonViViewModel
    /// </summary>
    public class DonViViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// DonViChaId
        /// </summary>
        public Guid? DonViChaId { get; set; }

        /// <summary>
        /// MaDonVi
        /// </summary>
        public string? MaDonVi { get; set; }

        /// <summary>
        /// TenDonVi
        /// </summary>
        public string? TenDonVi { get; set; }

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
