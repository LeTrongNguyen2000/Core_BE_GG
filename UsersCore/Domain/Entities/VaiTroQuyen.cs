namespace UserCore.Entities
{
    /// <summary>
    /// VaiTroQuyen
    /// </summary>
    public class VaiTroQuyen : BaseEntity
    {
        /// <summary>
        /// VaiTroId
        /// </summary>
        public Guid VaiTroId { get; set; }

        /// <summary>
        /// QuyenId
        /// </summary>
        public Guid QuyenId { get; set; }

        /// <summary>
        /// VaiTro
        /// </summary>
        public VaiTro VaiTro { get; set; }

        /// <summary>
        /// Quyen
        /// </summary>
        public Quyen Quyen { get; set; }
    }
}
