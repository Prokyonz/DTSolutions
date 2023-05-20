using Bogus.DataSets;
using DiamondTrade.API.Models.Request;
using DiamondTrade.API.Models.Response;
using EFCore.SQL.Interface;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondTrade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorMaster _calculatorMaster;
        public CalculatorController(ICalculatorMaster calculatorMaster)
        {
            _calculatorMaster = calculatorMaster;
        }

        [Route("Delete")]
        [HttpPost]
        public async Task<IActionResult> Delete(int calculatorId,string branchId)
        {
            try
            {
                var result = await _calculatorMaster.DeleteCalculatorAsync(calculatorId, branchId);

                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAllCaluculator(string CompanyId)
        {
            try
            {
                var result = await _calculatorMaster.GetAllCalculatorAsync(CompanyId);

                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> Update(List<CalculatorMaster> calculatorList)
        {
            try
            {
                var result = await _calculatorMaster.UpdateCalculatorAsync(calculatorList);

                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [Route("Add")]
        [HttpPost]
        public async Task<Response<List<CalculatorMaster>>> Add(CalculatorRequest calculator)
        {
            try
            {
                var calculatorMasterList = new List<CalculatorMaster>();

                calculator.SizeDetails.ForEach(x =>
                {
                    x.NumberDetails.ForEach(number =>
                    {
                        CalculatorMaster calculatorMaster = new CalculatorMaster();
                        calculatorMaster.BranchId = calculator.BranchId;
                        calculatorMaster.CompanyId = calculator.CompanyId;
                        calculatorMaster.FinancialYearId = calculator.FinancialYearId;
                        calculatorMaster.DealerId = calculator.BrokerId.ToUpper();
                        calculatorMaster.PartyId = calculator.PartyId.ToUpper();
                        calculatorMaster.Date = calculator.Date;
                        calculatorMaster.CreatedDate = DateTime.Now;
                        calculatorMaster.CreatedBy = calculator.UserId;
                        calculatorMaster.SizeId = x.SizeId;
                        calculatorMaster.NetCarat = calculator.NetCarat;
                        calculatorMaster.TotalCarat = x.TotalCarat;
                        calculatorMaster.IsDelete = false;
                        calculatorMaster.Rate = number.Rate;
                        calculatorMaster.Amount = number.Amount;
                        calculatorMaster.Carat = number.Carat;
                        calculatorMaster.Percentage = number.Percentage;
                        calculatorMaster.NumberId = number.NumberId;
                        calculatorMaster.Note = calculator.Note;
                        calculatorMasterList.Add(calculatorMaster);
                    });
                });

                var result = await _calculatorMaster.AddCalculatorListAsync(calculatorMasterList);

                return new Response<List<CalculatorMaster>>()
                {
                    Message = "Record has been saved successfully",
                    StatusCode = 200,
                    Success = true,
                    Data = result
                };
            }
            catch (Exception ex)
            {
                {
                    return new Response<List<CalculatorMaster>>()
                    {
                        Message = ex.Message,
                        StatusCode = 200,
                        Success = false,
                        Data = null
                    };
                }
            }
        }

        [Route("GetCalculatorReport")]
        [HttpGet]
        public async Task<IActionResult> GetCalculatorReport(string CompanyId, string FinancialYearId, string FromDate, string ToDate)
        {
            try
            {
                var result = await _calculatorMaster.GetCalculatorReport(CompanyId, FinancialYearId, FromDate, ToDate);

                var calculatorResponseModel = result.GroupBy(x => new
                {
                    x.Date.Date,
                    x.SrNo,
                    x.CompanyId,
                    x.FinancialYearId,
                    x.BranchId,
                    x.BranchName,
                    x.PartyId,
                    x.PartyName,
                    x.BrokerId,
                    x.BrokerName,
                    x.NetCarat,
                    x.Note,
                    x.UserId,
                    x.UserName
                }).Select(x => new CalculatorResponseModel()
                {
                    Date = x.Key.Date.Date,
                    SrNo = x.Key.SrNo,
                    CompanyId = x.Key.CompanyId,
                    FinancialYearId = x.Key.FinancialYearId,
                    BranchId = x.Key.BranchId,
                    BranchName  = x.Key.BranchName,
                    PartyId = x.Key.PartyId,
                    PartyName = x.Key.PartyName,
                    BrokerId = x.Key.BrokerId,
                    BrokerName = x.Key.BrokerName,
                    NetCarat = x.Key.NetCarat,
                    Note = x.Key.Note,
                    UserId = x.Key.UserId,
                    UserName = x.Key.UserName,
                    SizeDetails = x.Select(s => new Models.Response.SizeDetails()
                    {
                        SizeId = s.SizeId,
                        SizeName = s.SizeName,
                        TotalCarat = s.TotalCarat,
                        NumberDetails = new List<Models.Response.NumberDetails>()
                        {
                            new Models.Response.NumberDetails(){
                            SizeId = s.SizeId,
                            NumberId = s.NumberId,
                            Carat = s.Carat,
                            Rate = s.Rate,
                            NumberName = s.NumberName,
                            Percentage = s.Percentage,
                            Amount = s.Amount
                            },
                        }
                    }).ToList()
                });

                calculatorResponseModel = calculatorResponseModel.OrderByDescending(x => x.SrNo);
                return Ok(calculatorResponseModel);
            }
            catch(Exception Ex)
            {
                throw;
            }
        }

    }
}
