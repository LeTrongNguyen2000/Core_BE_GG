namespace UserCore.Models
{
    /// <summary>
    /// NguoiDungPhongBanRequest
    /// </summary>
    public class NguoiDungPhongBanRequest
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Id phòng ban
        /// </summary>
        public Guid PhongBanId { get; set; }

        /// <summary>
        /// là phòng ban chính
        /// </summary>
        public bool PhongBanChinh { get; set; }

        /// <summary>
        /// NguoiDungVaiTro
        /// </summary>
        public required NguoiDungVaiTroRequest NguoiDungVaiTro { get; set; }
    }
}
