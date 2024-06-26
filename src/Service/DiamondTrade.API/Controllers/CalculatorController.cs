﻿using Bogus.DataSets;
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
        public async Task<IActionResult> Delete(int calculatorId, string branchId)
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

                if (calculator.SrNo > 0)
                {
                    await _calculatorMaster.DeleteCalculatorHistoryAsync(calculator.BranchId, calculator.CompanyId, calculator.FinancialYearId, calculator.SrNo);
                }

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
                    //x.SizeId // Group by SizeId as well
                }).Select(x => new CalculatorResponseModel()
                {
                    Date = x.Key.Date.Date,
                    SrNo = x.Key.SrNo,
                    CompanyId = x.Key.CompanyId,
                    FinancialYearId = x.Key.FinancialYearId,
                    BranchId = x.Key.BranchId,
                    BranchName = x.Key.BranchName,
                    PartyId = x.Key.PartyId,
                    PartyName = x.Key.PartyName,
                    BrokerId = x.Key.BrokerId,
                    BrokerName = x.Key.BrokerName,
                    NetCarat = x.Key.NetCarat,
                    Note = x.Key.Note,
                    UserId = x.Key.UserId,
                    UserName = x.Key.UserName,
                    SizeDetails = x.GroupBy(s => s.SizeId)
                        .Select(s => new Models.Response.SizeDetails()
                        {
                            SizeId = s.Key,
                            SizeName = s.First().SizeName,
                            TotalCarat = s.First().TotalCarat,
                            NumberDetails = s.Select(n => new Models.Response.NumberDetails()
                            {
                                SizeId = n.SizeId,
                                NumberId = n.NumberId,
                                Carat = n.Carat,
                                Rate = n.Rate,
                                NumberName = n.NumberName,
                                Percentage = n.Percentage,
                                Amount = n.Amount
                            }).ToList()
                        }).ToList()
                });


                calculatorResponseModel = calculatorResponseModel.OrderByDescending(x => x.SrNo);
                return Ok(calculatorResponseModel);
            }
            catch (Exception Ex)
            {
                throw;
            }
        }

    }
}
