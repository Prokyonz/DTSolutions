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
        private readonly ISalesMaster _salesMaster;
        private readonly IPaymentMaster _paymentMaster;
        private readonly IContraEntryMaster _contraEntryMaster;

        public ReportController(IPurchaseMaster purchaseMaster,
            ISalesMaster salesMaster,
            IPaymentMaster paymentMaster,
            IContraEntryMaster contraEntryMaster)
        {
            _purchaseMaster = purchaseMaster;
            _salesMaster = salesMaster;
            _paymentMaster = paymentMaster;
            _contraEntryMaster = contraEntryMaster;
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

        [Route("GetSaleReport")]
        [HttpGet]
        public async Task<Response<dynamic>> GetSaleReport(string CompanyId, string FinancialYearId, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                var result = await _salesMaster.GetSalesReport(CompanyId, FinancialYearId, FromDate.Date.ToString("yyyy-MM-dd"), ToDate.Date.ToString("yyyy-MM-dd")).ConfigureAwait(false);
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

        [Route("GetPaymentReport")]
        [HttpGet]
        public async Task<Response<dynamic>> GetPaymentReport(string CompanyId, string FinancialYearId, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                var result = await _paymentMaster.GetPaymentReport(CompanyId, FinancialYearId, 0, FromDate.Date.ToString("yyyy-MM-dd"), ToDate.Date.ToString("yyyy-MM-dd"));
                result = result.OrderBy(o => o.EntryDate).ToList();

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

        [Route("GetReceiptReport")]
        [HttpGet]
        public async Task<Response<dynamic>> GetReceiptReport(string CompanyId, string FinancialYearId, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                var result = await _paymentMaster.GetPaymentReport(CompanyId, FinancialYearId, 1, FromDate.Date.ToString("yyyy-MM-dd"), ToDate.Date.ToString("yyyy-MM-dd"));
                result = result.OrderBy(o => o.EntryDate).ToList();

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

        [Route("GetContraPaymentReport")]
        [HttpGet]
        public async Task<Response<dynamic>> GetContraPaymentReport(string CompanyId, string FinancialYearId, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                var result = await _contraEntryMaster.GetContraReport(CompanyId, FinancialYearId, FromDate.Date.ToString("yyyy-MM-dd"), ToDate.Date.ToString("yyyy-MM-dd"));
                result = result.OrderBy(o => o.EntryDate).ToList();

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

        [Route("ApproveRejectStatus")]
        [HttpGet]
        //1 Approve
        //2 Reect
        public async Task<Response<dynamic>> ApproveRejectStatus(string Type, string Id, string Comment, int ApproveReject)
        {
            try
            {
                bool result = false;
                if (Type == "Purchase")
                {
                    result = await _purchaseMaster.UpdateApprovalStatus(Id, Comment, ApproveReject);
                }
                else if (Type == "Sale")
                {
                    result = await _salesMaster.UpdateApprovalStatus(Id, Comment, ApproveReject);
                }
                else if (Type == "Payment" || Type == "Receipt")
                {
                    result = await _paymentMaster.UpdateApprovalStatus(Id, Comment, ApproveReject);
                }

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
