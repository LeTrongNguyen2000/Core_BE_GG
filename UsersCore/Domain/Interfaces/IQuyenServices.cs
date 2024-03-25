using UserCore.Models;

namespace UserCore.Interfaces
{
    /// <summary>
    /// IVaiTroServices
    /// </summary>
    public interface IQuyenServices
    {
        /// <summary>
        /// Get ds vai tro
        /// </summary>
        /// <returns></returns>
        Task<List<QuyenResponse>> DsQuyen();

        /// <summary>
        /// Ds quyen
        /// </summary>
        /// <returns></returns>
        Task<bool> AddQuyenVaiTro(Guid vaiTroId, string currentUser, List<VaiTroQuyenRequest> dsQuyen);

        /// <summary>
        /// Ds vai trò quyền
        /// </summary>
        /// <param name="donViId"></param>
        /// <returns></returns>
        Task<List<VaiTroQuyenResponse>> DsQuyenVaiTroDonVi(Guid donViId);

        /// <summary>
        /// Xóa quyền vai trò
        /// </summary>
        /// <returns></returns>
        Task<bool> DeleteQuyenVaiTro(Guid vaiTroId, string currentUser, List<VaiTroQuyenRequest> dsQuyen);

        /// <summary>
        /// Ds quyền người dùng (theo chức danh id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<QuyenViewModel>> QuyenNguoiDungTheoChucDanh(Guid id);
    }
}
