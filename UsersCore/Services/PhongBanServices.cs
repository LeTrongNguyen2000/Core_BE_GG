using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UserCore.Entities;
using UserCore.EntityFrameworkCore;
using UserCore.Interfaces;
using UserCore.Models;

namespace UserCore.Services
{
    public class PhongBanServices : IPhongBanServices
    {
        public readonly UserCoreDbContext _dbContext;

        public readonly IMapper _mapper;

        public PhongBanServices(UserCoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id, string currentUser)
        {
            try
            {
                var entity = _dbContext.PhongBan.Find(id);

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

        public async Task<PagingModel<PhongBanResponse>> DsPhongBan(Guid? donViId, bool? isAll, int page, int limit)
        {
            try
            {
                var items = _dbContext.PhongBan.Where(x => !x.DaXoa && x.DonViId == donViId && x.PhongBanChaId == null).OrderBy(item => item.STT).AsQueryable();

                var count = items.Count();

                if (isAll == false)
                {
                    items = items
                        .OrderBy(item => item.STT)
                        .Skip((page - 1) * limit)
                        .Take(limit);
                }

                var result = new PagingModel<PhongBanResponse>();
                result.Page = page;
                result.Total = count;
                result.Items = _mapper.Map<List<PhongBanResponse>>(items);

                return await Task.FromResult(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PagingModel<PhongBanResponse>> GetPhongBanCon(Guid phongBanChaId, bool? isAll, int page, int limit)
        {
            var items = _dbContext.PhongBan.Where(x => !x.DaXoa && x.PhongBanChaId == phongBanChaId && x.PhongBanChaId == null).OrderBy(item => item.STT).AsQueryable();

            var count = items.Count();

            if (isAll == false)
            {
                items = items
                 .OrderBy(item => item.STT)
                 .Skip((page - 1) * limit)
                      .Take(limit);
            }

            var result = new PagingModel<PhongBanResponse>();
            result.Page = page;
            result.Total = count;
            result.Items = _mapper.Map<List<PhongBanResponse>>(items);

            return await Task.FromResult(result);
        }

        public async Task<PhongBanResponse> Get(Guid id)
        {
            try
            {
                var data = _dbContext.PhongBan.Find(id);

                return await Task.FromResult(_mapper.Map<PhongBanResponse>(data));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PhongBanResponse> Add(string currentUser, PhongBanRequest model)
        {
            try
            {
                var entity = _mapper.Map<PhongBan>(model);

                var maxStt = await _dbContext.PhongBan.MaxAsync(x => (int?)x.STT) ?? 0;

                entity.STT = maxStt + 1;
                entity.NguoiTao = currentUser;

                entity.STT = maxStt + 1;

                var result = _dbContext.Add(entity).Entity;

                await _dbContext.SaveChangesAsync();

                return _mapper.Map<PhongBanResponse>(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PhongBanResponse?> Update(Guid id, string currentUser, PhongBanRequest model)
        {
            try
            {
                var entity = _dbContext.PhongBan.Find(id);

                if (entity != null)
                {
                    entity.NguoiCapNhat = currentUser;
                    entity.NgayCapNhat = DateTime.Now;
                    entity.TenPhongBan = model.TenPhongBan;
                    entity.TenVietTat = model.TenVietTat;
                    entity.DonViId = model.DonViId;
                    entity.TrangThai = model.TrangThai;
                    entity.PhongBanChaId = model.PhongBanChaId;
                    entity.MaPhongBan = model.MaPhongBan;

                    var result = _dbContext.Update(entity).Entity;

                    await _dbContext.SaveChangesAsync();

                    return _mapper.Map<PhongBanResponse>(result);
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
