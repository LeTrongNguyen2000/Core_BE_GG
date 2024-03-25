namespace UserCore.Models
{
    /// <summary>
    /// Response VaiTro
    /// </summary>
    public class VaiTroResponse : BaseResponse
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
        /// 0: không sử dụng, 1: sử dụng
        /// </summary>
        public int TrangThai { get; set; }
    }
}
