using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserCore.Constransts;
using UserCore.Interfaces;
using UserCore.Mappings;
using UserCore.Models;

namespace UserCore.Controllers
{
    /// <summary>
    /// VaiTroController
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api")]
    public class VaiTroController : ControllerBase
    {
        /// <summary>
        /// interface service
        /// </summary>
        public readonly IVaiTroServices _services;

        /// <summary>
        /// Contractor Vaitro
        /// </summary>
        /// <param name="services"></param>
        public VaiTroController(IVaiTroServices services)
        {
            _services = services;
        }

        /// <summary>
        /// Get chi tiết VaiTro
        /// </summary>
        /// <param name="id">Id vaitro</param>
        /// <returns></returns>
        [HttpGet]
        [Route("vaitro/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var data = await _services.Get(id);

                var result = new BaseResponse<VaiTroResponse>
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
        /// Get danh sách vai trò
        /// </summary>
        /// <param name="donViId"></param>
        /// <param name="isAll"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("donvi/{donViId}/vaitro")]
        public async Task<IActionResult> DsVaiTro(Guid donViId, bool? isAll, int page = 1, int limit = 10)
        {
            try
            {
                var data = await _services.DsVaiTro(donViId, isAll, page, limit);

                var result = new BaseResponse<PagingModel<VaiTroResponse>>
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
        /// Tạo mới vai trò
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("vaitro")]
        public async Task<IActionResult> Add([FromBody] VaiTroRequest model)
        {
            try
            {
                var currentUser = User.GetUserName();

                var data = await _services.Add(currentUser, model);

                var result = new BaseResponse<VaiTroResponse>
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
        /// Cập nhật vai trò
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("vaitro/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] VaiTroRequest model)
        {
            try
            {
                var currentUser = User.GetUserName();

                var data = await _services.Update(id, currentUser, model);

                var result = new BaseResponse<VaiTroResponse>
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
        /// Xóa vai trò
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("vaitro/{id}")]
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
