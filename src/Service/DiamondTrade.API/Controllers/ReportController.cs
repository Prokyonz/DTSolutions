using DiamondTrade.API.Models.Response;
using EFCore.SQL.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondTrade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        private readonly IPurchaseMaster _purchaseMaster;
        
        public ReportController(IPurchaseMaster purchaseMaster)
        {
            _purchaseMaster = purchaseMaster;

        }

        [Route("GetPurchaseReport")]
        [HttpGet]
        public async Task<Response<dynamic>> GetPurchaseReport(string CompanyId, string FinancialYearId, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                var result = await _purchaseMaster.GetPurchaseReport(CompanyId, FinancialYearId, null, FromDate.Date.ToString("yyyy-MM-dd"), ToDate.Date.ToString("yyyy-MM-dd")).ConfigureAwait(false);
                result = result.OrderBy(o => o.SlipNo).ToList();

                return new Response<dynamic>
                {
                    StatusCode = 200,
                    Success = true,
                    Data = result
                };
            }
            catch
            {
                throw;
            }
        }
    }
}
