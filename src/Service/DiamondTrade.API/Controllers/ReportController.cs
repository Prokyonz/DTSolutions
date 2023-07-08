using DiamondTrade.API.Models.Request;
using DiamondTrade.API.Models.Response;
using EFCore.SQL.Interface;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities.Model;
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
        private readonly ISalaryMaster _salaryMaster;
        private readonly IAccountToAssortMaster _accountToAssortMaster;
        private readonly IRejectionInOutMaster _rejectionInOutMaster;
        private readonly IKapanMaster _kapanMaster;
        public ReportController(IPurchaseMaster purchaseMaster,
            ISalesMaster salesMaster,
            IPaymentMaster paymentMaster,
            IContraEntryMaster contraEntryMaster,
            IExpenseMaster expenseMaster,
            IPartyMaster partyMaster,
            ISalaryMaster salaryMaster,
            IAccountToAssortMaster accountToAssortMaster,
            IRejectionInOutMaster rejectionInOutMaster,
            IKapanMaster kapanMaster)
        {
            _purchaseMaster = purchaseMaster;
            _salesMaster = salesMaster;
            _paymentMaster = paymentMaster;
            _contraEntryMaster = contraEntryMaster;
            _expenseMaster = expenseMaster;
            _partyMaster = partyMaster;
            _salaryMaster = salaryMaster;
            _accountToAssortMaster = accountToAssortMaster;
            _rejectionInOutMaster = rejectionInOutMaster;
            _kapanMaster = kapanMaster;
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

        //[Route("ExportPDFPurchaseReport")]
        //[HttpGet]
        //public async Task<IActionResult> ExportPDFPurchaseReport(string CompanyId, string FinancialYearId, DateTime FromDate, DateTime ToDate)
        //{
        //    try
        //    {
        //        var result = await _purchaseMaster.GetPurchaseReport(CompanyId, FinancialYearId, null, FromDate.Date.ToString("yyyy-MM-dd"), ToDate.Date.ToString("yyyy-MM-dd")).ConfigureAwait(false);
        //        result = result.OrderBy(o => o.SlipNo).ToList();

        //        PropertyInfo[] properties = typeof(PurchaseSPModel).GetProperties();

        //        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        //        // Extract column names
        //        List<string> columnNames = new List<string>();
        //        foreach (PropertyInfo property in properties)
        //        {
        //            columnNames.Add(property.Name);
        //        }

        //        using (ExcelPackage excelPackage = new ExcelPackage())
        //        {
        //            // Create a new Excel worksheet
        //            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

        //            // Set column headers
        //            for (int col = 1; col <= columnNames.Count; col++)
        //            {
        //                worksheet.Cells[1, col].Value = columnNames[col - 1];
        //            }

        //            // Populate data rows
        //            int row = 2;
        //            foreach (PurchaseSPModel item in result)
        //            {
        //                for (int col = 1; col <= columnNames.Count; col++)
        //                {
        //                    PropertyInfo property = properties[col - 1];
        //                    object value = property.GetValue(item);
        //                    worksheet.Cells[row, col].Value = value;
        //                }
        //                row++;
        //            }

        //            // Auto-fit columns
        //            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

        //            // Create a new PDF document
        //            iTextSharp.text.Document document = new iTextSharp.text.Document();

        //            // Create a new PDF writer
        //            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("path_to_temp_pdf_file.pdf", FileMode.Create));

        //            // Open the PDF document
        //            document.Open();

        //            // Create a new PDF table based on the Excel data
        //            PdfPTable table = new PdfPTable(worksheet.Dimension.Columns);
        //            for (int i = 1; i <= worksheet.Dimension.Rows; i++)
        //            {
        //                for (int j = 1; j <= worksheet.Dimension.Columns; j++)
        //                {
        //                    PdfPCell cell = new PdfPCell(new Phrase(worksheet.Cells[i, j].Value?.ToString() ?? ""));
        //                    table.AddCell(cell);
        //                }
        //            }

        //            // Add the PDF table to the PDF document
        //            document.Add(table);

        //            // Close the PDF document
        //            document.Close();

        //            // Return the file path or any relevant response
        //            return Ok("path_to_temp_pdf_file.pdf");
        //        }

        //        // Return the file path or any relevant response
        //        //return Ok("path_to_temp_pdf_file.pdf");
        //        //return new Response<dynamic>
        //        //{
        //        //    StatusCode = 200,
        //        //    Success = true,
        //        //    Data = result
        //        //};
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}


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

        [Route("GetPFReport")]
        [HttpGet]
        public async Task<Response<dynamic>> GetPFReport(string CompanyId, string financialYearId)
        {
            try
            {
                var result = await _purchaseMaster.GetPFReportAsync(CompanyId, financialYearId, 1);

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

        [Route("GetWeeklyPurchaseReport")]
        [HttpGet]
        public async Task<Response<dynamic>> GetWeeklyPurchaseReport(string CompanyId, string financialYearId)
        {
            try
            {
                var result = await _purchaseMaster.GetWeeklyPurchaseReportAsync(CompanyId, financialYearId);

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

        [Route("GetWeeklyPurchaseDetailReport")]
        [HttpGet]
        public async Task<Response<dynamic>> GetWeeklyPurchaseDetailReport(string currentWeek, string CompanyId, string financialYearId)
        {
            try
            {
                var result = await _purchaseMaster.GetPurchaseReport(CompanyId, financialYearId, currentWeek);

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

        [Route("GetSalariesReport")]
        [HttpGet]
        public async Task<Response<dynamic>> GetSalariesReport(string CompanyId, string financialYearId)
        {
            try
            {
                var result = await _salaryMaster.GetSalaries(CompanyId, financialYearId);

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

        [Route("GetBalanceSheetReport")]
        [HttpGet]
        public async Task<Response<dynamic>> GetBalanceSheetReport(string CompanyId, string financialYearId, int balanceSheetType)
        {
            try
            {
                var result = await _paymentMaster.GetBalanceSheetReportAsync(CompanyId, financialYearId, 2);

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

        [Route("GetProfitLossReport")]
        [HttpGet]
        public async Task<Response<dynamic>> GetProfitLossReport(string CompanyId, string financialYearId, int profitLossReportType)
        {
            try
            {
                var result = await _paymentMaster.GetProfitLossReportAsync(CompanyId, financialYearId, 2);

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

        [Route("GetStockKapanReport")]
        [HttpGet]
        public async Task<Response<dynamic>> GetStockKapanReport(string CompanyId, string financialYearId)
        {
            try
            {
                var result = await _accountToAssortMaster.GetStockReportAsync(CompanyId, financialYearId);

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

        [Route("GetStockNumberReport")]
        [HttpGet]
        public async Task<Response<dynamic>> GetStockNumberReport(string CompanyId, string financialYearId)
        {
            try
            {
                var result = await _accountToAssortMaster.GetNumberReportAsync(CompanyId, financialYearId);

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

        [Route("GetStockReport")]
        [HttpGet]
        public async Task<Response<dynamic>> GetStockReport(string CompanyId, string financialYearId)
        {
            try
            {
                var stockReport = await _accountToAssortMaster.GetStockReportAsync(CompanyId, financialYearId);
                var numberReport = await _accountToAssortMaster.GetNumberReportAsync(CompanyId, financialYearId);

                decimal inwardAmount = 0;
                decimal inwardWeight = 0;
                decimal inwardRate = 0;

                decimal outwardAmount = 0;
                decimal outwardWeight = 0;
                decimal outwardRate = 0;

                if (stockReport.Any())
                {
                    inwardAmount = stockReport.Sum(s => s.InwardAmount);
                    inwardWeight = stockReport.Sum(s => s.InwardNetWeight);
                    inwardRate = stockReport.Average(a => a.InwardRate);

                    outwardAmount = stockReport.Sum(s => s.OutwardAmount);
                    outwardWeight = stockReport.Sum(s => s.OutwardNetWeight);
                    outwardRate = stockReport.Sum(s => s.OutwardRate);
                }

                decimal inwardAmountN = 0;
                decimal inwardWeightN = 0;
                decimal inwardRateN = 0;

                decimal outwardAmountN = 0;
                decimal outwardWeightN = 0;
                decimal outwardRateN = 0;
                if (numberReport.Any())
                {
                    inwardAmountN = numberReport.Sum(s => s.InwardAmount);
                    inwardWeightN = numberReport.Sum(s => s.InwardNetWeight);
                    inwardRateN = numberReport.Average(a => a.InwardRate);

                    outwardAmountN = numberReport.Sum(s => s.OutwardAmount);
                    outwardWeightN = numberReport.Sum(s => s.OutwardNetWeight);
                    outwardRateN = numberReport.Sum(s => s.OutwardRate);
                }

                List<StockReportMasterGrid> stockReportMasterGrids = new List<StockReportMasterGrid>()
                    {
                        new StockReportMasterGrid()
                        {
                            Id = 1,
                            Name = "Kapan",
                            Rate = Math.Round((inwardRate - outwardRate),2),
                            TotalWeight = inwardWeight - outwardWeight,
                            TotalAmount = inwardAmount - outwardAmount
                        },
                        new StockReportMasterGrid()
                        {
                            Id = 2,
                            Name = "Number",
                            Rate = Math.Round(inwardRateN - outwardRateN,2),
                            TotalWeight = inwardWeightN - outwardWeightN,
                            TotalAmount = inwardAmountN - outwardAmountN
                        },
                    };
                return new Response<dynamic>
                {
                    StatusCode = 200,
                    Success = true,
                    Data = stockReportMasterGrids
                };
            }
            catch
            {
                throw;
            }
        }

        [Route("GetRejectionInReport")]
        [HttpGet]
        public async Task<Response<dynamic>> GetRejectionInReport(string CompanyId, string financialYearId)
        {
            try
            {
                var result = await _rejectionInOutMaster.GetRejectionSendReceiveReport(CompanyId, financialYearId, TransType: 1);

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

        [Route("GetRejectionOutReport")]
        [HttpGet]
        public async Task<Response<dynamic>> GetRejectionOutReport(string CompanyId, string financialYearId)
        {
            try
            {
                var result = await _rejectionInOutMaster.GetRejectionSendReceiveReport(CompanyId, financialYearId, TransType: 2);

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

        [Route("GetKapanLagadReport")]
        [HttpGet]
        public async Task<Response<dynamic>> GetKapanLagadReport(string kapanId)
        {
            try
            {
                var result = await _kapanMaster.GetKapanLagadReport(kapanId);

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
