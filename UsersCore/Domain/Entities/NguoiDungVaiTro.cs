namespace UserCore.Entities
{
    /// <summary> 
    /// Entity NguoiDungVaiTro
    /// </summary>
    public class NguoiDungVaiTro : BaseEntity
    {
        /// <summary>
        /// NguoiDungPhongBanId
        /// </summary>
        public Guid NguoiDungPhongBanId { get; set; }

        /// <summary>
        /// VaiTroId
        /// </summary>
        public Guid VaiTroId { get; set; }

        /// <summary>
        /// 0: không sử dụng, 1: sử dụng
        /// </summary>
        public int TrangThai { get; set; } = 1;

        /// <summary>
        /// vaiTro
        /// </summary>
        public VaiTro VaiTro { get; set; }
    }
}
