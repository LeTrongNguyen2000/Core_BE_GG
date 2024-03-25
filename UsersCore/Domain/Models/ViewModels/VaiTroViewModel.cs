namespace UserCore.Models
{
    /// <summary>
    /// VaiTroViewModel
    /// </summary>
    public class VaiTroViewModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

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
