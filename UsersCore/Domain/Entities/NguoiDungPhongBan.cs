namespace UserCore.Entities
{
    /// <summary>
    /// NguoiDungPhongBan
    /// </summary>
    public class NguoiDungPhongBan : BaseEntity
    {
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
        /// NguoiDung
        /// </summary>
        public required NguoiDung NguoiDung { get; set; }

        /// <summary>
        /// PhongBan
        /// </summary>
        public required PhongBan PhongBan { get; set; }

        /// <summary>
        /// NguoiDungVaiTro
        /// </summary>
        public required NguoiDungVaiTro NguoiDungVaiTro { get; set; }
    }
}
