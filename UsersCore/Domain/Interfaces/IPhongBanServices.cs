using UserCore.Models;

namespace UserCore.Interfaces
{
    public interface IPhongBanServices
    {
        Task<PagingModel<PhongBanResponse>> DsPhongBan(Guid? donViId, bool? isAll, int page, int limit);

        Task<PagingModel<PhongBanResponse>> GetPhongBanCon(Guid phongBanChaId, bool? isAll, int page, int limit);

        Task<PhongBanResponse> Get(Guid id);

        Task<PhongBanResponse> Add(string currentUser, PhongBanRequest model);

        Task<PhongBanResponse> Update(Guid id, string currentUser, PhongBanRequest model);

        Task<bool> Delete(Guid id, string currentUser);
    }
}
