using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserCore.Entities;
using UserCore.EntityFrameworkCore;
using UserCore.Interfaces;
using UserCore.Models;

namespace UserCore.Services
{
    /// <summary>
    /// NguoiDungServices
    /// </summary>
    public class NguoiDungServices : INguoiDungService
    {
        /// <summary>
        /// dbContext
        /// </summary>
        public readonly UserCoreDbContext _dbContext;

        /// <summary>
        /// mapper
        /// </summary>
        public readonly IMapper _mapper;

        /// <summary>
        /// Contractor NguoiDungServices
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public NguoiDungServices(UserCoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Thêm mới người dùng
        /// </summary>
        /// <param name="currentUser"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Add(string currentUser, NguoiDungRequest model)
        {
            try
            {
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(model.MatKhau, BCrypt.Net.BCrypt.GenerateSalt());

                var entity = _mapper.Map<NguoiDung>(model);

                entity.MatKhau = passwordHash;
                entity.NguoiTao = currentUser;

                var result = _dbContext.Add(entity).Entity;

                await _dbContext.SaveChangesAsync();

                return await Task.FromResult(true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Kiem tra nguoi dung
        /// </summary>
        /// <param name="tenDangNhap"></param>
        /// <returns></returns>
        public Task<bool> CheckExistUser(string tenDangNhap)
        {
            var checkExist = _dbContext.NguoiDung.FirstOrDefault(x => !x.DaXoa && x.TenDangNhap !== tenDangNhap);

            if (checkExist == null)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        /// <summary>
        /// KIểm tra người dùng update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tenDangNhap"></param>
        /// <returns></returns>
        public Task<bool> CheckExistUserUpdate(Guid id, string tenDangNhap)
        {
            var checkExist = _dbContext.NguoiDung.FirstOrDefault(x => !x.DaXoa && x.TenDangNhap == tenDangNhap && x.Id != id);

            if (checkExist == null)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        /// <summary>
        /// Cập nhật
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentUser"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Update(Guid id, string currentUser, NguoiDungRequest model)
        {
            try
            {
                IQueryable<NguoiDung> includedQuery = _dbContext.NguoiDung;

                includedQuery = includedQuery.Include(nd => nd.DsNguoiDungPhongBan);

                includedQuery = includedQuery.Include(nd => nd.DsNguoiDungPhongBan)
                .ThenInclude(ndvt => ndvt.NguoiDungVaiTro);

                var query = includedQuery.FirstOrDefault(x => x.Id == id);

                if (query != null)
                {
                    query.TenDangNhap = model.TenDangNhap;
                    query.TenNguoiDung = model.TenNguoiDung;
                    query.SoDienThoai = model.SoDienThoai;
                    query.Email = model.Email;
                    query.AnhDaiDien = model.AnhDaiDien;
                    query.NguoiCapNhat = currentUser;
                    query.NgayCapNhat = DateTime.Now;

                    if (model.MatKhau != null)
                    {
                        query.MatKhau = BCrypt.Net.BCrypt.HashPassword(model.MatKhau, BCrypt.Net.BCrypt.GenerateSalt());
                    }

                    var nguoiDungPhongBanCanXoa = new List<NguoiDungPhongBan>();

                    // Cập nhật người dùng phòng ban cũ
                    foreach (var childEntity in query.DsNguoiDungPhongBan)
                    {
                        var nguoiDungPhongBanRequest = model.NguoiDungPhongBan.FirstOrDefault(x => x.Id == childEntity.Id);

                        if (nguoiDungPhongBanRequest != null)
                        {
                            childEntity.PhongBanId = nguoiDungPhongBanRequest.PhongBanId;
                            childEntity.PhongBanChinh = nguoiDungPhongBanRequest.PhongBanChinh;
                            childEntity.NguoiDungVaiTro.VaiTroId = nguoiDungPhongBanRequest.NguoiDungVaiTro.VaiTroId;
                            childEntity.NguoiDungVaiTro.DaXoa = false;
                        }
                        else
                        {
                            nguoiDungPhongBanCanXoa.Add(childEntity);
                        }
                    }

                    // Xóa người dùng phòng ban cũ
                    foreach (var item in nguoiDungPhongBanCanXoa)
                    {
                        query.DsNguoiDungPhongBan.Remove(item);
                    }

                    // Add phòng ban mới
                    foreach (var item in model.NguoiDungPhongBan.Where(x => x.Id == null))
                    {
                        query.DsNguoiDungPhongBan.Add(_mapper.Map<NguoiDungPhongBan>(item));
                    }

                    await _dbContext.SaveChangesAsync();
                }

                return await Task.FromResult(true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Xóa người dùng
        /// </summary>
        /// <param name="id"></param>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        public async Task<bool> Delete(Guid id, string currentUser)
        {
            try
            {
                IQueryable<NguoiDung> includedQuery = _dbContext.NguoiDung;

                includedQuery = includedQuery.Include(nd => nd.DsNguoiDungPhongBan);
                includedQuery = includedQuery.Include(nd => nd.DsNguoiDungPhongBan)
                                                .ThenInclude(ndvt => ndvt.NguoiDungVaiTro);

                var query = includedQuery.FirstOrDefault(x => x.Id == id);

                if (query != null)
                {
                    query.NguoiXoa = currentUser;
                    query.NgayXoa = DateTime.Now;
                    query.DaXoa = true;

                    // Cập nhật người dùng phòng ban cũ
                    foreach (var childEntity in query.DsNguoiDungPhongBan)
                    {
                        childEntity.DaXoa = true;

                        childEntity.NguoiDungVaiTro.DaXoa = true;
                    }

                    await _dbContext.SaveChangesAsync();
                }

                return await Task.FromResult(true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Xóa người dùng phong ban
        /// </summary>
        /// <param name="nguoiDungPhongBanId"></param>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        public async Task<bool> XoaNguoiDungPhongBan(Guid nguoiDungPhongBanId, string currentUser)
        {
            try
            {
                IQueryable<NguoiDungPhongBan> includedQuery = _dbContext.NguoiDungPhong;

                includedQuery = includedQuery.Include(nd => nd.NguoiDungVaiTro);

                var query = includedQuery.FirstOrDefault(x => x.Id == nguoiDungPhongBanId);

                if (query != null)
                {
                    query.NguoiXoa = currentUser;
                    query.NgayXoa = DateTime.Now;
                    query.DaXoa = true;
                    query.NguoiDungVaiTro.DaXoa = true;

                    await _dbContext.SaveChangesAsync();
                }

                return await Task.FromResult(true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// GetThongTinNguoiDung
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<NguoiDungFullResponse>? GetThongTinNguoiDung(Guid id)
        {
            try
            {
                var query = _dbContext.NguoiDung.FirstOrDefault(x => x.Id == id);

                if (query != null)
                {
                    IQueryable<NguoiDung> includedQuery = _dbContext.NguoiDung;

                    includedQuery = includedQuery.Include(nd => nd.DsNguoiDungPhongBan.Where(x => !x.DaXoa))
                                                 .ThenInclude(pb => pb.PhongBan)
                                                 .ThenInclude(dv => dv.DonVi);

                    includedQuery = includedQuery.Include(nd => nd.DsNguoiDungPhongBan)
                                                 .ThenInclude(ndvt => ndvt.NguoiDungVaiTro)
                    .ThenInclude(vt => vt.VaiTro);

                    query = includedQuery.FirstOrDefault(x => x.Id == id && !x.DaXoa);

                    if (query != null)
                    {
                        return await Task.FromResult(_mapper.Map<NguoiDungFullResponse>(query));
                    }
                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// GetNguoiDungTheoPhongBan
        /// </summary>
        /// <param name="phongBanId"></param>
        /// <returns></returns>
        public async Task<List<NguoiDungPhongBanResponse>> GetNguoiDungTheoPhongBan(Guid phongBanId)
        {
            try
            {
                IQueryable<NguoiDung> includedQuery = _dbContext.NguoiDung;

                includedQuery = includedQuery.Include(nd => nd.DsNguoiDungPhongBan)
                                             .ThenInclude(pb => pb.PhongBan)
                                             .ThenInclude(dv => dv.DonVi);

                includedQuery = includedQuery.Include(nd => nd.DsNguoiDungPhongBan)
                                             .ThenInclude(ndvt => ndvt.NguoiDungVaiTro)
                .ThenInclude(vt => vt.VaiTro);

                var query = includedQuery.Where(x => x.DsNguoiDungPhongBan.Any(a => a.PhongBanId == phongBanId));

                return await Task.FromResult(_mapper.Map<List<NguoiDungPhongBanResponse>>(query));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
