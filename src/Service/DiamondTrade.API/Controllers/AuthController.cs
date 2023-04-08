using DiamondTrade.API.Models.Request;
using DiamondTrade.API.Models.Response;
using EFCore.SQL.Interface;
using EFCore.SQL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DiamondTrade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserMaster _userMaster;
        private IPurchaseMaster _purchaseMaster;
        public AuthController(IUserMaster userMaster,
            IPurchaseMaster purchaseMaster)
        {
            _userMaster = userMaster;
            _purchaseMaster = purchaseMaster;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            try
            {
                //var result = await _userMaster.Login(login.UserName, login.Password);

                //LoginResponseModel loginResponseModel = new LoginResponseModel();
                //loginResponseModel.Id = result.UserMaster.Id;

                //return Ok(loginResponseModel);

                var result = await _purchaseMaster.GetAllPurchaseAsync("ff8d3c9b-957b-46d1-b661-560ae4a2433e", "146c24c5-6663-4f3d-bdfd-80469275c898");

                result.ForEach(element =>
                {
                    element.Image1 = null;
                    element.Image2 = null;
                    element.Image3 = null;
                });

                var minResult = result;

                var json = JsonConvert.SerializeObject(minResult);

                return Ok(json);

            }
            catch (Exception Ex)
            {

                throw;
            }
        }
    }

    public class LoginResponseModel
    {
        public string Id { get; set; }
        
    }
}
