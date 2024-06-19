using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserCore.Constransts;
using UserCore.Interfaces;
using UserCore.Mappings;
using UserCore.Models;

namespace UserCore.Controllers
{
    /// <summary>
    /// DonViController
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/donvi")]
    public class DonViController : ControllerBase
    {
        /// <summary>
        /// interface service
        /// </summary>
        public readonly IDonViServices _services;

        /// <summary>
        /// Contractor DonVi
        /// </summary>
        /// <param name="services"></param>
        public DonViController(IDonViServices services)
        {
            _services = services;
        }

        /// <summary>
        /// Get chi tiết đơn vị
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

                var result = new BaseResponse<DonViResponse>
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
        /// Get danh sách đơn vị cha
        /// </summary>
        /// <param name="isAll">True: Lấy tất cả</param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetDanhSachDonViCha(bool? isAll, int page = 1, int limit = 10)
        {
            try
            {
                var data = await _services.GetDanhSachDonViCha(isAll, page, limit);

                var result = new BaseResponse<PagingModel<DonViResponse>>
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
        /// Get danh sách đơn vị con
        /// </summary>
        /// <param name="donViChaId"></param>
        /// <param name="isAll"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{donViChaId}/donvicon")]
        public async Task<IActionResult> GetDonViCon(Guid donViChaId, bool? isAll, int page = 1, int limit = 10)
        {
            try
            {
                var data = await _services.GetDonViCon(donViChaId, isAll, page, limit);

                var result = new BaseResponse<PagingModel<DonViResponse>>
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
        /// Tạo mới đơn vị
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DonViRequest model)
        {
            try
            {
                var currentUser = User.GetUserName();

                var data = await _services.Add(currentUser, model);

                var result = new BaseResponse<DonViResponse>
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
        /// Cập nhật đơn vị
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] DonViRequest model)
        {
            try
            {
                var currentUser = User.GetUserName();

                var data = await _services.Update(id, currentUser, model);

                var result = new BaseResponse<DonViResponse>
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
        /// Xóa đơn vị
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
