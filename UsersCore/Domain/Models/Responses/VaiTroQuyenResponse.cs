﻿namespace UserCore.Models
{
    /// <summary>
    /// Response VaiTroQuyenResponse
    /// </summary>
    public class VaiTroQuyenResponse
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

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
        /// DsQuyen
        /// </summary>
        public List<QuyenViewModel>? DsQuyen { get; set; }
    }
}
