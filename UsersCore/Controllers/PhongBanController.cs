using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserCore.Constransts;
using UserCore.Interfaces;
using UserCore.Mappings;
using UserCore.Models;

namespace UserCore.Controllers
{
    /// <summary>
    /// Phong Ban Controller
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/phongban")]
    public class PhongBanController : ControllerBase
    {
        /// <summary>
        /// interface service
        /// </summary>
        public readonly IPhongBanServices _services;

        /// <summary>
        /// Constructor PhongBanController
        /// </summary>
        /// <param name="services">service</param>
        public PhongBanController(IPhongBanServices services)
        {
            _services = services;
        }

        /// <summary>
        /// Chi tiết phòng ban
        /// </summary>
        /// <param name="id">Id đơn vị</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var data = await _services.Get(id);

                var result = new BaseResponse<PhongBanResponse>
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
        /// Danh sách phòng ban
        /// </summary>
        /// <param name="donViId"></param>
        /// <param name="isAll"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> DsPhongBan(Guid? donViId, bool? isAll, int page = 1, int limit = 10)
        {
            try
            {
                var data = await _services.DsPhongBan(donViId, isAll, page, limit);

                var result = new BaseResponse<PagingModel<PhongBanResponse>>
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
        /// Danh sách phòng ban con
        /// </summary>
        /// <param name="phongBanChaId"></param>
        /// <param name="isAll"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{phongBanChaId}/phongbancon")]
        public async Task<IActionResult> GetPhongBanCon(Guid phongBanChaId, bool? isAll, int page = 1, int limit = 10)
        {
            try
            {
                var data = await _services.GetPhongBanCon(phongBanChaId, isAll, page, limit);

                var result = new BaseResponse<PagingModel<PhongBanResponse>>
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
        /// Tạo mới phòng ban
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PhongBanRequest model)
        {
            try
            {
                var currentUser = User.GetUserName();

                var data = await _services.Add(currentUser, model);

                var result = new BaseResponse<PhongBanResponse>
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
        /// Cập nhật phòng ban
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] PhongBanRequest model)
        {
            try
            {
                var currentUser = User.GetUserName();

                var data = await _services.Update(id, currentUser, model);

                var result = new BaseResponse<PhongBanResponse>
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
        /// Xóa phòng ban
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
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
    }
}
