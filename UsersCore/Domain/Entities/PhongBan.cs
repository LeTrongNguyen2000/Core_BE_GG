namespace UserCore.Entities
{
    /// <summary>
    /// Entity phong ban
    /// </summary>
    public class PhongBan : BaseEntity
    {
        /// <summary>
        /// Gets, sets DonViId
        /// </summary>
        public Guid DonViId { get; set; }

        /// <summary>
        /// Gets, sets PhonBanChaId
        /// </summary>
        public Guid? PhongBanChaId { get; set; }

        /// <summary>
        /// Gets, Gets ma PhongBan
        /// </summary>
        public string? MaPhongBan { get; set; }

        /// <summary>
        /// Gets, sets TenPhongBan
        /// </summary>
        public string? TenPhongBan { get; set; }

        /// <summary>
        /// Gets, Sets, TenVietTat
        /// </summary>
        public string? TenVietTat { get; set; }

        /// <summary>
        /// Gets, Sets Ten Viet tat
        /// </summary>
        public int STT { get; set; }

        /// <summary>
        /// 0: không sử dụng, 1: sử dụng
        /// </summary>
        public int TrangThai { get; set; }

        /// <summary>
        /// Gets, Sets, Dơn vi
        /// </summary>
        public DonVi? DonVi { get; set; }
    }
}
