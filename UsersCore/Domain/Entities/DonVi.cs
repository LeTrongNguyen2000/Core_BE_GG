namespace UserCore.Entities
{
    /// <summary>
    /// DonVi
    /// </summary>
    public class DonVi : BaseEntity
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
        /// tên đơn vị
        /// </summary>
        public string? TenDonVi { get; set; }

        /// <summary>
        /// tên viết tắt
        /// </summary>
        public string? TenVietTat { get; set; }

        /// <summary>
        /// số thứ tự
        /// </summary>
        public int STT { get; set; }

        /// <summary>
        /// 0: không sử dụng, 1: sử dụng
        /// </summary>
        public int TrangThai { get; set; }

        /// <summary>
        /// ds ohong ban
        /// </summary>
        public List<PhongBan>? DsPhongBan { get; set; }

        /// <summary>
        /// ds vai trò
        /// </summary>
        public List<VaiTro>? DsVaiTro { get; set; }
    }
}
