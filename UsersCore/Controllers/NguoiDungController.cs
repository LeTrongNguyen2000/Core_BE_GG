using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserCore.Constransts;
using UserCore.Interfaces;
using UserCore.Mappings;
using UserCore.Models;

namespace UserCore.Controllers
{
    /// <summary>
    /// QuyenController
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api")]
    public class NguoiDungController : ControllerBase
    {
        /// <summary>
        /// interface service
        /// </summary>
        public readonly INguoiDungService _services;

        /// <summary>
        /// Contractor Quyen
        /// </summary>
        /// <param name="services"></param>
        public NguoiDungController(INguoiDungService services)
        {
            _services = services;
        }

        /// <summary>
        /// Thêm người dùng
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("nguoidung")]
        public async Task<IActionResult> Add(NguoiDungRequest model)
        {
            try
            {
                var checkExist = await _services.CheckExistUser(model.TenDangNhap);

                if (checkExist)
                {
                    return BadRequest("Tên đăng nhập đã tồn tại");
                }

                var currentUser = User.GetUserName();

                var data = await _services.Add(currentUser, model);

                var result = new BaseResponse<bool>
                {
                    Code = 201,
                    Message = ApiMessage.Added,
                    Result = data
                };

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Cập nhật người dùng
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("nguoidung/{id}")]
        public async Task<IActionResult> Update(Guid id, NguoiDungRequest model)
        {
            try
            {
                var checkExist = await _services.CheckExistUserUpdate(id, model.TenDangNhap);

                if (checkExist)
                {
                    return BadRequest("Tên đăng nhập đã tồn tại");
                }

                var currentUser = User.GetUserName();

                var data = await _services.Update(id, currentUser, model);

                var result = new BaseResponse<bool>
                {
                    Code = 200,
                    Message = ApiMessage.Updated,
                    Result = data
                };

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Xóa người dùng
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("nguoidung/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var currentUser = User.GetUserName();

                var data = await _services.Delete(id, currentUser);

                var result = new BaseResponse<bool>
                {
                    Code = 200,
                    Message = ApiMessage.Deleted,
                    Result = data
                };

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Xóa người dùng phòng ban (theo nguoiDungPhongBanId (chức danh id))
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("nguoidungphongban/{nguoiDungPhongBanId}")]
        public async Task<IActionResult> XoaNguoiDungPhongBan(Guid nguoiDungPhongBanId)
        {
            try
            {
                var currentUser = User.GetUserName();

                var data = await _services.XoaNguoiDungPhongBan(nguoiDungPhongBanId, currentUser);

                var result = new BaseResponse<bool>
                {
                    Code = 200,
                    Message = ApiMessage.Deleted,
                    Result = data
                };

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Thông tin người dùng hiện tại
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("nguoidung/me")]
        public async Task<IActionResult> GetThongTinNguoiDung()
        {
            try
            {
                var currentUserId = Guid.Parse(User.GetUserId());

                var data = await _services.GetThongTinNguoiDung(currentUserId);

                var result = new BaseResponse<NguoiDungFullResponse>
                {
                    Code = 200,
                    Message = ApiMessage.GetOk,
                    Result = data
                };

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get chi tiết người dùng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("nguoidung/{id}")]
        public async Task<IActionResult> GetChiTietNguoiDung(Guid id)
        {
            try
            {
                var data = await _services.GetThongTinNguoiDung(id);

                var result = new BaseResponse<NguoiDungFullResponse>
                {
                    Code = 200,
                    Message = ApiMessage.GetOk,
                    Result = data
                };

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Danh sách người dùng theo phòng ban
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("phongban/{phongBanId}/nguoidung")]
        public async Task<IActionResult> GetThongTinNguoiDung(Guid phongBanId)
        {
            try
            {
                var data = await _services.GetNguoiDungTheoPhongBan(phongBanId);

                var result = new BaseResponse<List<NguoiDungPhongBanResponse>>
                {
                    Code = 200,
                    Message = ApiMessage.GetOk,
                    Result = data
                };

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
