using DiamondTrade.API.Models;
using DiamondTrade.API.Models.Request;
using DiamondTrade.API.Models.Response;
using EFCore.SQL.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace DiamondTrade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserMaster _userMaster;
        public AuthController(IUserMaster userMaster)
        {
            _userMaster = userMaster;
        }

        [Route("login")]
        [HttpPost]
        public async Task<Response<LoginResponseModel>> Login([FromBody] Login login)
        {
            try
            {
                var result = await _userMaster.Login(login.UserName, login.Password);
                if (result.UserMaster != null)
                {
                    Response<LoginResponseModel> loginResponseModel = new Response<LoginResponseModel>();
                    loginResponseModel.Data = new LoginResponseModel
                    {
                        Id = result.UserMaster.Id
                    };
                    loginResponseModel.Success = true;
                    loginResponseModel.StatusCode = (int)HttpStatusCode.OK;
                    return loginResponseModel;
                }
                else
                {
                    return new Response<LoginResponseModel>
                    {
                        Success = false,
                        StatusCode = (int)HttpStatusCode.NotAcceptable
                    };
                }
                //return Ok(result);

            }
            catch
            {
                throw;
            }
        }
    }

}
