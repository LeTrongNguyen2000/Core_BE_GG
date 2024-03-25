using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserCore.Entities;
using UserCore.EntityFrameworkCore;
using UserCore.Interfaces;
using UserCore.Models;

namespace UserCore.Services
{
    /// <summary>
    /// QuyenServices
    /// </summary>
    public class QuyenServices : IQuyenServices
    {
        /// <summary>
        /// connetion
        /// </summary>
        public readonly UserCoreDbContext _dbContext;

        /// <summary>
        /// Mapper
        /// </summary>
        public readonly IMapper _mapper;

        /// <summary>
        /// Contractor VaiTroServices
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public QuyenServices(UserCoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Ds quyen
        /// </summary>
        /// <returns></returns>
        public async Task<List<QuyenResponse>> DsQuyen()
        {
            try
            {
                var items = _dbContext.Quyen.Where(x => !x.DaXoa && x.TrangThai == 1).OrderBy(item => item.STT).ToList();

                return await Task.FromResult(_mapper.Map<List<QuyenResponse>>(items));
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// UpdateQuyenVaiTro
        /// </summary>
        /// <returns></returns>
        public async Task<bool> AddQuyenVaiTro(Guid vaiTroId, string currentUser, List<VaiTroQuyenRequest> dsQuyen)
        {
            try
            {
                var dsVaiTroQuyen = _dbContext.VaiTroQuyen.Where(x => x.VaiTroId == vaiTroId);

                foreach (var quyen in dsQuyen)
                {
                    var query = dsVaiTroQuyen.FirstOrDefault(x => x.VaiTroId == vaiTroId && x.QuyenId == quyen.QuyenId);

                    if (query == null)
                    {
                        var entity = new VaiTroQuyen
                        {
                            Id = Guid.NewGuid(),
                            VaiTroId = vaiTroId,
                            QuyenId = quyen.QuyenId,
                            NgayTao = DateTime.Now,
                            NguoiTao = currentUser
                        };

                        _dbContext.Add(entity);
                    }
                    else
                    {
                        query.DaXoa = false;
                        query.NguoiXoa = string.Empty;
                        query.NgayXoa = null;

                        _dbContext.Update(query);
                    }
                }

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Xóa quyền vai trò
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DeleteQuyenVaiTro(Guid vaiTroId, string currentUser, List<VaiTroQuyenRequest> dsQuyen)
        {
            try
            {
                var dsVaiTroQuyen = _dbContext.VaiTroQuyen.Where(x => x.VaiTroId == vaiTroId);

                foreach (var quyen in dsQuyen)
                {
                    var query = dsVaiTroQuyen.FirstOrDefault(x => x.VaiTroId == vaiTroId && x.QuyenId == quyen.QuyenId);

                    if (query != null)
                    {
                        query.DaXoa = true;
                        query.NgayXoa = DateTime.Now;
                        query.NguoiXoa = currentUser;

                        _dbContext.Update(query);
                    }
                }

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Ds vai trò quyền trong đơn vị
        /// </summary>
        /// <param name="donViId"></param>
        /// <returns></returns>
        public async Task<List<VaiTroQuyenResponse>> DsQuyenVaiTroDonVi(Guid donViId)
        {
            try
            {
                var dsVaiTro = _dbContext.VaiTro.Where(x => !x.DaXoa && x.DonViId == donViId)
                                                .Include(i => i.DsVaiTroQuyen.Where(x => !x.DaXoa))
                                                    .ThenInclude(th => th.Quyen);

                var result = _mapper.Map<List<VaiTroQuyenResponse>>(dsVaiTro.ToList());

                return await Task.FromResult(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Ds quyền người dùng (theo chức danh id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<QuyenViewModel>> QuyenNguoiDungTheoChucDanh(Guid id)
        {
            try
            {
                IQueryable<NguoiDungVaiTro> includedQuery = _dbContext.NguoiDungVaiTro
                                                .Include(i => i.VaiTro)
                                                    .ThenInclude(th => th.DsVaiTroQuyen)
                                                    .ThenInclude(x => x.Quyen);

                var query = includedQuery.FirstOrDefault(x => !x.DaXoa && x.NguoiDungPhongBanId == id);

                if (query != null)
                {
                    var result = _mapper.Map<List<QuyenViewModel>>(query.VaiTro.DsVaiTroQuyen);

                    return await Task.FromResult(result);
                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
