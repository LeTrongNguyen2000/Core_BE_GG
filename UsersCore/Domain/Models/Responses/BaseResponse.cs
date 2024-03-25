﻿namespace UserCore.Models
{
    /// <summary>
    /// BaseResponse
    /// </summary>
    public class BaseResponse
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string? NguoiTao { get; set; }

        /// <summary>
        /// ngày tạo
        /// </summary>
        public DateTime NgayTao { get; set; }

        /// <summary>
        /// người cập nhật
        /// </summary>
        public string? NguoiCapNhat { get; set; }

        /// <summary>
        /// ngày cập nhật
        /// </summary>
        public DateTime? NgayCapNhat { get; set; }

        /// <summary>
        /// đã xóa
        /// </summary>
        public bool DaXoa { get; set; }

        /// <summary>
        /// người xóa
        /// </summary>
        public string? NguoiXoa { get; set; }

        /// <summary>
        /// ngày xoa
        /// </summary>
        public DateTime? NgayXoa { get; set; }
    }
}
