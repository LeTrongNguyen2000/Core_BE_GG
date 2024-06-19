using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserCore.Entities;
using UserCore.EntityFrameworkCore;
using UserCore.Interfaces;
using UserCore.Models;

namespace UserCore.Services
{
    public class DonViServices : IDonViServices
    {
        public readonly UserCoreDbContext _dbContext;

        public readonly IMapper _mapper;

        public DonViServices(UserCoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="currentUser"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<DonViResponse> Add(string currentUser, DonViRequest model)
        {
            try
            {
                var entity = _mapper.Map<DonVi>(model);
                entity.NguoiTao = currentUser;

                var maxStt = await _dbContext.DonVi.MaxAsync(x => (int?)x.STT) ?? 0;

                entity.STT = maxStt + 1;

                var result = _dbContext.Add(entity).Entity;

                await _dbContext.SaveChangesAsync();

                return _mapper.Map<DonViResponse>(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Delete(Guid id, string currentUser)
        {
            try
            {
                var entity = _dbContext.DonVi.Find(id);

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

        public async Task<DonViResponse> Get(Guid id)
        {
            try
            {
                var data = _dbContext.DonVi.Find(id);

                return await Task.FromResult(_mapper.Map<DonViResponse>(data));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Get(string id)
        {
            
        }

        public async Task<DonViResponse> Update(Guid id, string currentUser, DonViRequest model)
        {
            try
            {
                var entity = _dbContext.DonVi.Find(id);

                if (entity != null)
                {
                    entity.NguoiCapNhat = currentUser;
                    entity.NgayCapNhat = DateTime.Now;
                    entity.TenDonVi = model.TenDonVi;
                    entity.MaDonVi = model.MaDonVi;
                    entity.TenVietTat = model.TenVietTat;
                    entity.DonViChaId = model.DonViChaId;
                    entity.TrangThai = model.TrangThai;

                    var result = _dbContext.Update(entity).Entity;

                    await _dbContext.SaveChangesAsync();

                    return _mapper.Map<DonViResponse>(result);
                }

                return new DonViResponse();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PagingModel<DonViResponse>> GetDanhSachDonViCha(bool? isAll, int page, int limit)
        {
            try
            {
                var items = _dbContext.DonVi.Where(x => !x.DaXoa && x.DonViChaId == null).OrderBy(item => item.STT).AsQueryable();

                var count = items.Count();

                if (isAll == false)
                {
                    items = items.OrderBy(item => item.STT)
                          .Skip((page - 1) * limit)
                          .Take(limit);
                }


                var result = new PagingModel<DonViResponse>();
                result.Page = page;
                result.Total = count;
                result.Items = _mapper.Map<List<DonViResponse>>(items);

                return await Task.FromResult(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PagingModel<DonViResponse>> GetDonViCon(Guid donViChaId, bool? isAll, int page, int limit)
        {
            try
            {
                var items = _dbContext.DonVi.Where(x => !x.DaXoa && x.DonViChaId == donViChaId).OrderBy(item => item.STT).AsQueryable();
                var count = items.Count();
                if (isAll == false)
                {
                    items = items.OrderBy(item => item.STT)
                         .Skip((page - 1) * limit)
                         .Take(limit);
                }

                var result = new PagingModel<DonViResponse>();
                result.Page = page;
                result.Total = count;
                result.Items = _mapper.Map<List<DonViResponse>>(items);

                return await Task.FromResult(result);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
