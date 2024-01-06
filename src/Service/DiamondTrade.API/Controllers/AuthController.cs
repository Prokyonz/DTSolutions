using DiamondTrade.API.Models;
using DiamondTrade.API.Models.Request;
using DiamondTrade.API.Models.Response;
using DocumentFormat.OpenXml.Spreadsheet;
using EFCore.SQL.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DiamondTrade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserMaster _userMaster;
        private IApprovalPermissionMaster _approvalPermissionMaster;
        public AuthController(IUserMaster userMaster, IApprovalPermissionMaster approvalPermissionMaster)
        {
            _userMaster = userMaster;
            _approvalPermissionMaster = approvalPermissionMaster;
        }

        [Route("ping")]
        [HttpGet]
        public bool Ping()
        {
            return true;
        }

        [Route("pingDB")]
        [HttpGet]
        public bool PingDB()
        {
            return _userMaster.DBTest();
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

        [Route("GetPermissionList")]
        [HttpGet]
        public async Task<Response<dynamic>> GetPermissionList(string userid)
        {
            List<string> permissions = new List<string>();
            try
            {
                var result = await _userMaster.GetUserPermissions(userid);
                if (result.Any())
                {
                    //for (int i = 0; i < result.Count; i++)
                    //{
                    //    switch (result[i].KeyName)
                    //    {
                    //        //Reports Menu - Transaction
                    //        case "purchase_report":
                    //        case "sales_report":
                    //        case "payment_report":
                    //        case "receipt_report":
                    //        case "contra_report":
                    //        case "expense_report":
                    //        case "loan_report":
                    //        case "mixed_report":
                    //        case "process_reports":
                    //        case "jangad_reports":
                    //        case "stock_report":
                    //            permissions.Add(result[i].KeyName);
                    //            break;
                    //    }
                    //}
                    return new Response<dynamic>
                    {
                        StatusCode = 200,
                        Success = true,
                        Data = result.Select(x => x.KeyName).ToList()
                    };
                }
                else
                {
                    return new Response<dynamic>
                    {
                        Success = false,
                        StatusCode = (int)HttpStatusCode.NotAcceptable
                    };
                }
            }
            catch
            {
                throw;
            }
        }


        [Route("GetPermission")]
        [HttpGet]
        public async Task<Response<dynamic>> GetPermission(string userid, string keyname)
        {
            List<string> permissions = new List<string>();
            try
            {
                var result = await _approvalPermissionMaster.GetPermission();
                if (result.Any(x => x.UserId.Contains(userid) && x.KeyName == keyname))
                {
                    return new Response<dynamic>
                    {
                        StatusCode = 200,
                        Success = true,
                        Data = true
                    };
                }
                else
                {
                    return new Response<dynamic>
                    {
                        Success = false,
                        StatusCode = (int)HttpStatusCode.NotAcceptable
                    };
                }
            }
            catch
            {
                throw;
            }
        }
    }

}
