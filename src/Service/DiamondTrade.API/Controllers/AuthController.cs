using DiamondTrade.API.Models;
using DiamondTrade.API.Models.Request;
using EFCore.SQL.Interface;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            try
            {
                var result = await _userMaster.Login(login.UserName, login.Password);

                LoginResponseModel loginResponseModel = new LoginResponseModel();
                loginResponseModel.Id = result.UserMaster.Id;

                return Ok(loginResponseModel);
            }
            catch
            {
                throw;
            }
        }
    }
  
}
