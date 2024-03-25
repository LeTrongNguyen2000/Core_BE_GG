using UserCore.Models;

namespace UserCore.Interfaces
{
    public interface IDonViServices
    {
        Task<PagingModel<DonViResponse>> GetDanhSachDonViCha(bool? isAll, int page, int limit);

        Task<PagingModel<DonViResponse>> GetDonViCon(Guid donViChaId, bool? isAll, int page, int limit);

        Task<DonViResponse> Get(Guid id);

        Task<DonViResponse> Add(string currentUser, DonViRequest model);

        Task<DonViResponse> Update(Guid id, string currentUser, DonViRequest model);

        Task<bool> Delete(Guid id, string currentUser);
    }
}
