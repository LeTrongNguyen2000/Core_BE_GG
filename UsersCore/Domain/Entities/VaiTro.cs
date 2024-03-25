namespace UserCore.Entities
{
    /// <summary>
    /// Entity Vai tro
    /// </summary>
    public class VaiTro : BaseEntity
    {
        /// <summary>
        /// Gets, Sets donviid
        /// </summary>
        public Guid DonViId { get; set; }

        /// <summary>
        /// Gets, sets MaVaiTro
        /// </summary>
        public string? MaVaiTro { get; set; }

        /// <summary>
        /// Gets, sets TenVaiTro
        /// </summary>
        public string? TenVaiTro { get; set; }

        /// <summary>
        /// Gets, Set Stt
        /// </summary>
        public int STT { get; set; }

        /// <summary>
        /// 0: không sử dụng, 1: sử dụng
        /// </summary>
        public int TrangThai { get; set; }

        /// <summary>
        /// đơn vị
        /// </summary>
        public DonVi DonVi { get; set; }

        /// <summary>
        /// ds vai trò quyền
        /// </summary>
        public List<VaiTroQuyen> DsVaiTroQuyen { get; set; }

        /// <summary>
        /// ds nguoi dung vai tro
        /// </summary>
        public List<NguoiDungVaiTro> DsNguoiDungVaiTro { get; set; }
    }
}
