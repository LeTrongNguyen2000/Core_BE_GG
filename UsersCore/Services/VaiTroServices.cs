using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserCore.Entities;
using UserCore.EntityFrameworkCore;
using UserCore.Interfaces;
using UserCore.Models;

namespace UserCore.Services
{
    /// <summary>
    /// VaiTroServices
    /// </summary>
    public class VaiTroServices : IVaiTroServices
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
        public VaiTroServices(UserCoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Them moi
        /// </summary>
        /// <param name="currentUser"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<VaiTroResponse> Add(string currentUser, VaiTroRequest model)
        {
            try
            {
                var entity = _mapper.Map<VaiTro>(model);
                entity.NguoiTao = currentUser;

                var maxStt = await _dbContext.VaiTro.MaxAsync(x => (int?)x.STT) ?? 0;

                entity.STT = maxStt + 1;

                var result = _dbContext.Add(entity).Entity;

                await _dbContext.SaveChangesAsync();

                return _mapper.Map<VaiTroResponse>(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Xoa
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        public async Task<bool> Delete(Guid id, string currentUser)
        {
            try
            {
                var entity = _dbContext.VaiTro.Find(id);

                if (entity != null)
                {
                    entity.NguoiXoa = currentUser;
                    entity.DaXoa = true;
                    entity.NgayXoa = DateTime.Now;

                    _dbContext.Update(entity);
                    await _dbContext.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Ds vai tro
        /// </summary>
        /// <param name="donViId"></param>
        /// <param name="isAll"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<PagingModel<VaiTroResponse>> DsVaiTro(Guid donViId, bool? isAll, int page, int limit)
        {
            try
            {
                var items = _dbContext.VaiTro.Where(x => !x.DaXoa && x.DonViId == donViId).OrderBy(item => item.STT).AsQueryable();

                var count = items.Count();

                if (isAll == false)
                {
                    items = items.OrderBy(item => item.STT)
                         .Skip((page - 1) * limit)
                         .Take(limit);
                }

                var result = new PagingModel<VaiTroResponse>();
                result.Page = page;
                result.Total = count;
                result.Items = _mapper.Map<List<VaiTroResponse>>(items);

                return await Task.FromResult(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<VaiTroResponse> Get(Guid id)
        {
            try
            {
                var data = _dbContext.VaiTro.Find(id);

                return await Task.FromResult(_mapper.Map<VaiTroResponse>(data));
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentUser"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<VaiTroResponse> Update(Guid id, string currentUser, VaiTroRequest model)
        {
            try
            {
                var entity = _dbContext.VaiTro.Find(id);

                if (entity != null)
                {
                    entity.NguoiCapNhat = currentUser;
                    entity.NgayCapNhat = DateTime.Now;
                    entity.TenVaiTro = model.TenVaiTro;
                    entity.MaVaiTro = model.MaVaiTro;
                    entity.TrangThai = model.TrangThai;
                    entity.DonViId = model.DonViId;

                    var result = _dbContext.Update(entity).Entity;

                    await _dbContext.SaveChangesAsync();

                    return _mapper.Map<VaiTroResponse>(result);
                }

                return new VaiTroResponse();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
