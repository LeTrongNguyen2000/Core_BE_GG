using UserCore.Models;

namespace UserCore.Interfaces
{
    /// <summary>
    /// INguoiDungService
    /// </summary>
    public interface INguoiDungService
    {
        /// <summary>
        ///  thêm mới
        /// </summary>
        /// <param name="currentUser"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> Add(string currentUser, NguoiDungRequest model);

        /// <summary>
        /// Thông tin người dùng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<NguoiDungFullResponse>? GetThongTinNguoiDung(Guid id);

        /// <summary>
        /// GetNguoiDungTheoPhongBan
        /// </summary>
        /// <param name="phongBanId"></param>
        /// <returns></returns>
        Task<List<NguoiDungPhongBanResponse>> GetNguoiDungTheoPhongBan(Guid phongBanId);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentUser"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> Update(Guid id, string currentUser, NguoiDungRequest model);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        Task<bool> Delete(Guid id, string currentUser);

        /// <summary>
        /// Xóa người dùng phong ban
        /// </summary>
        /// <param name="nguoiDungPhongBanId"></param>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        Task<bool> XoaNguoiDungPhongBan(Guid nguoiDungPhongBanId, string currentUser);

        /// <summary>
        /// Kiem tra nguoi dung
        /// </summary>
        /// <param name="tenDangNhap"></param>
        /// <returns></returns>
        Task<bool> CheckExistUser(string tenDangNhap);

        /// <summary>
        /// KIểm tra người dùng update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tenDangNhap"></param>
        /// <returns></returns>
        Task<bool> CheckExistUserUpdate(Guid id, string tenDangNhap);
    }
}
