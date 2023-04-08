using DiamondTrade.API.Models.Request;
using EFCore.SQL.Interface;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
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

        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CalculatorMaster calculatorData)
        {
            try
            {
                var result = await _calculatorMaster.AddCalculatorAsync(calculatorData);

                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [Route("Delete")]
        [HttpPost]
        public async Task<IActionResult> Delete(int calculatorId)
        {
            try
            {
                var result = await _calculatorMaster.DeleteCalculatorAsync(calculatorId);

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
    }
}
