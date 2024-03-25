using UserCore.Models;

namespace UserCore.Interfaces
{
    /// <summary>
    /// IVaiTroServices
    /// </summary>
    public interface IVaiTroServices
    {
        /// <summary>
        /// Get ds vai tro
        /// </summary>
        /// <param name="donViId"></param>
        /// <param name="isAll"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<PagingModel<VaiTroResponse>> DsVaiTro(Guid donViId, bool? isAll, int page, int limit);

        /// <summary>
        /// Get chi tiet
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<VaiTroResponse> Get(Guid id);

        /// <summary>
        /// Them moi
        /// </summary>
        /// <param name="currentUser"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<VaiTroResponse> Add(string currentUser, VaiTroRequest model);

        /// <summary>
        /// Cap nat
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentUser"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<VaiTroResponse> Update(Guid id, string currentUser, VaiTroRequest model);

        /// <summary>
        /// Xoa
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        Task<bool> Delete(Guid id, string currentUser);
    }
}
