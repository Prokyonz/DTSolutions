using DiamondTrade.API.Models.Request;
using DiamondTrade.API.Models.Response;
using EFCore.SQL.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DiamondTrade.API.Models.Enum.Enum;

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
        private readonly IExpenseMaster _expenseMaster;
        private readonly IPartyMaster _partyMaster;
        private readonly ILoanMaster _loanMaster;
        public ReportController(IPurchaseMaster purchaseMaster,
            ISalesMaster salesMaster,
            IPaymentMaster paymentMaster,
            IContraEntryMaster contraEntryMaster,
            IExpenseMaster expenseMaster,
            IPartyMaster partyMaster)
        {
            _purchaseMaster = purchaseMaster;
            _salesMaster = salesMaster;
            _paymentMaster = paymentMaster;
            _contraEntryMaster = contraEntryMaster;
            _expenseMaster = expenseMaster;
            _partyMaster = partyMaster;
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

        [Route("GetPurchaseTotal")]
        [HttpGet]
        public async Task<Response<dynamic>> GetPurchaseTotal(string CompanyId, string FinancialYearId, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                var result = await _purchaseMaster.GetPurchaseTotal(CompanyId, FinancialYearId, null, FromDate.Date.ToString("yyyy-MM-dd"), ToDate.Date.ToString("yyyy-MM-dd"));

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

        [Route("GetSaleTotal")]
        [HttpGet]
        public async Task<Response<dynamic>> GetSaleTotal(string CompanyId, string FinancialYearId, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                var result = await _salesMaster.GetSalesTotal(CompanyId, FinancialYearId, FromDate.Date.ToString("yyyy-MM-dd"), ToDate.Date.ToString("yyyy-MM-dd"));

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

        [Route("GetPaymentOrReceiptTotal")]
        [HttpGet]
        public async Task<Response<dynamic>> GetPaymentOrReceiptReport(string CompanyId, string FinancialYearId, DateTime FromDate, DateTime ToDate, int TransType)
        {
            try
            {
                var result = await _paymentMaster.GetPaymentOrReceiptTotal(CompanyId, FinancialYearId, TransType, FromDate.Date.ToString("yyyy-MM-dd"), ToDate.Date.ToString("yyyy-MM-dd"));

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

        [Route("GetExpenseReport")]
        [HttpGet]
        public async Task<Response<dynamic>> GetExpenseReport(string CompanyId, string FinancialYearId, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                var result = await _expenseMaster.GetExpenseReport(CompanyId, FinancialYearId, FromDate.ToString("yyyy-MM-dd"), ToDate.ToString("yyyy-MM-dd"));
                result = result.OrderBy(o => o.SrNo).ToList();

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

        [Route("GetMixedReport")]
        [HttpGet]
        public async Task<Response<dynamic>> GetMixedReport(string CompanyId, string FinancialYearId, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                var result = await _paymentMaster.GetMixedReportAsync(CompanyId, FinancialYearId, FromDate.ToString("yyyy-MM-dd"), ToDate.ToString("yyyy-MM-dd"));
                result = result.OrderBy(o => o.CreatedDate).ToList();

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

        [Route("GetLedgerReport")]
        [HttpGet]
        public async Task<Response<dynamic>> GetLedgerReport(string CompanyId, string FinancialYearId)
        {
            try
            {
                var result = await _partyMaster.GetLedgerReport(CompanyId, FinancialYearId);
                result = result.OrderBy(o => o.Name).ToList();

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

        [Route("GetCashBankReport")]
        [HttpGet]
        public async Task<Response<dynamic>> GetCashBankReport(string CompanyId, string FinancialYearId, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                var result = await _paymentMaster.GetCashBankReportAsync(CompanyId, FinancialYearId, FromDate.ToString("yyyy-MM-dd"), ToDate.ToString("yyyy-MM-dd"));
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
        [HttpPost]
        //1 Approve
        //2 Reject
        public async Task<Response<dynamic>> ApproveRejectStatus(ApproveRejectRequest approveRejectRequest)
        {
            try
            {
                bool result = false;
                if (approveRejectRequest.ReportType == ReportType.Purchase)
                {
                    result = await _purchaseMaster.UpdateApprovalStatus(approveRejectRequest.Id, approveRejectRequest.Comment, approveRejectRequest.Status);
                }
                else if (approveRejectRequest.ReportType == ReportType.Sale)
                {
                    result = await _salesMaster.UpdateApprovalStatus(approveRejectRequest.Id, approveRejectRequest.Comment, approveRejectRequest.Status);
                }
                else if (approveRejectRequest.ReportType == ReportType.Payment || approveRejectRequest.ReportType == ReportType.Receipt)
                {
                    result = await _paymentMaster.UpdateApprovalStatus(approveRejectRequest.Id, approveRejectRequest.Comment, approveRejectRequest.Status);
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

        [Route("GetPayableReport")]
        [HttpGet]
        public async Task<Response<dynamic>> GetPayableReport(string CompanyId, string FinancialYearId)
        {
            try
            {
                var result = await _paymentMaster.GetPayableReceivalbeReport(CompanyId, FinancialYearId, 0);

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

        [Route("GetReceivableReport")]
        [HttpGet]
        public async Task<Response<dynamic>> GetReceivableReport(string CompanyId, string FinancialYearId)
        {
            try
            {
                var result = await _paymentMaster.GetPayableReceivalbeReport(CompanyId, FinancialYearId, 1);

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


        [Route("GetLoanReport")]
        [HttpGet]
        public async Task<Response<dynamic>> GetLoanReport(string CompanyId)
        {
            try
            {
                var result = await _loanMaster.GetLoanReportAsync(CompanyId);

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
