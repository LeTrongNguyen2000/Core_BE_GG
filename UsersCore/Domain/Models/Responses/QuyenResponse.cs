namespace UserCore.Models
{
    /// <summary>
    /// QuyenResponse
    /// </summary>
    public class QuyenResponse : BaseResponse
    {
        /// <summary>
        /// ma quyen
        /// </summary>
        public string? MaQuyen { get; set; }

        /// <summary>
        ///  mo ta
        /// </summary>
        public string? MoTa { get; set; }

        /// <summary>
        /// trang thai
        /// </summary>
        public int TrangThai { get; set; }

        /// <summary>
        /// STT
        /// </summary>
        public int STT { get; set; }
    }
}
