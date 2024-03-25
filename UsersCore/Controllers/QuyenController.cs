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
    public class QuyenController : ControllerBase
    {
        /// <summary>
        /// interface service
        /// </summary>
        public readonly IQuyenServices _services;

        /// <summary>
        /// Contractor Quyen
        /// </summary>
        /// <param name="services"></param>
        public QuyenController(IQuyenServices services)
        {
            _services = services;
        }

        /// <summary>
        /// Danh sách quyền
        /// </summary>
        /// <returns></returns>
        [Route("quyen")]
        [HttpGet]
        public async Task<IActionResult> DsQuyen()
        {
            try
            {
                var data = await _services.DsQuyen();

                var result = new BaseResponse<List<QuyenResponse>>
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
        /// Tạo phân quyền cho đối tượng (thêm nhiều quyền cùng lúc)
        /// </summary>
        /// <param name="vaiTroId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("vaitro/{vaiTroId}/dsquyen")]
        [HttpPost]
        public async Task<IActionResult> AddQuyenVaiTro(Guid vaiTroId, List<VaiTroQuyenRequest> request)
        {
            try
            {
                var currentUser = User.GetUserName();

                var data = await _services.AddQuyenVaiTro(vaiTroId, currentUser, request);

                var result = new BaseResponse<bool>
                {
                    Code = 200,
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
        /// Xóa phân quyền cho đối tượng (thêm nhiều quyền cùng lúc)
        /// </summary>
        /// <param name="vaiTroId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("vaitro/{vaiTroId}/dsquyen")]
        [HttpDelete]
        public async Task<IActionResult> DeleteQuyenVaiTro(Guid vaiTroId, List<VaiTroQuyenRequest> request)
        {
            try
            {
                var currentUser = User.GetUserName();

                var data = await _services.DeleteQuyenVaiTro(vaiTroId, currentUser, request);

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
        /// Get danh sách phân quyền nhân viên của đơn
        /// </summary>
        /// <param name="donViId"></param>
        /// <returns></returns>
        [Route("donvi/{donViId}/dsphanquyen")]
        [HttpGet]
        public async Task<IActionResult> DsQuyenVaiTroDonVi(Guid donViId)
        {
            try
            {
                var currentUser = User.GetUserName();

                var data = await _services.DsQuyenVaiTroDonVi(donViId);

                var result = new BaseResponse<List<VaiTroQuyenResponse>>
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
        /// Get danh sách các quyền của nhân viên (theo chức danh Id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("quyen/nguoidung/{id}")]
        [HttpGet]
        public async Task<IActionResult> QuyenNguoiDungTheoChucDanh(Guid id)
        {
            try
            {
                var currentUser = User.GetUserName();

                var data = await _services.QuyenNguoiDungTheoChucDanh(id);

                var result = new BaseResponse<List<QuyenViewModel>>
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
