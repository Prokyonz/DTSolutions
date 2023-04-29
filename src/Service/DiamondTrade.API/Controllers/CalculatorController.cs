using Bogus.DataSets;
using DiamondTrade.API.Models.Request;
using DiamondTrade.API.Models.Response;
using EFCore.SQL.Interface;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using System;
using System.Collections.Generic;
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
        public async Task<IActionResult> GetAllCaluculator()
        {
            try
            {
                var result = await _calculatorMaster.GetAllCalculatorAsync();

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
                        calculatorMaster.DealerId = calculator.BrokerId;
                        calculatorMaster.PartyId = calculator.PartyId;
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

    }
}
