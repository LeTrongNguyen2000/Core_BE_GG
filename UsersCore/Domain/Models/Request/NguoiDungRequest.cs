namespace UserCore.Models
{
    /// <summary>
    /// NguoiDungRequest
    /// </summary>
    public class NguoiDungRequest
    {
        /// <summary>
        /// Ten nguoi dung
        /// </summary>
        public string? TenNguoiDung { get; set; }

        /// <summary>
        /// ten dang nhap
        /// </summary>
        public required string TenDangNhap { get; set; }

        /// <summary>
        /// MatKhau
        /// </summary>
        public string? MatKhau { get; set; }

        /// <summary>
        /// Sdt
        /// </summary>
        public string? SoDienThoai { get; set; }

        /// <summary>
        /// email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// anh dai dien
        /// </summary>
        public string? AnhDaiDien { get; set; }

        /// <summary>
        /// ngay sinh
        /// </summary>
        public DateTime? NgaySinh { get; set; }

        /// <summary>
        /// 0: không sử dụng, 1: sử dụng
        /// </summary>
        public int TrangThai { get; set; }

        /// <summary>
        /// NguoiDungPhong
        /// </summary>
        public required List<NguoiDungPhongBanRequest> NguoiDungPhongBan { get; set; }
    }
}
