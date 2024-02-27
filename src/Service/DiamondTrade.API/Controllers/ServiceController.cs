using DiamondTrade.API.Models.Response;
using EFCore.SQL.Interface;
using EFCore.SQL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using System;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DiamondTrade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly ISizeMaster _sizeMaster;
        private readonly INumberMaster _numberMaster;
        private readonly IPriceMasterMobile _priceMaster;
        private readonly IPartyMaster _partyMaster;
        private readonly IBranchMaster _branchMaster;
        private readonly ICompanyMaster _companyMaster;
        private readonly IFinancialYearMaster _financialYearMaster;
        private readonly ICalculatorMaster _calculatorMaster;

        public ServiceController(ISizeMaster sizeMaster, INumberMaster numberMaster,
            IPriceMasterMobile priceMaster, IPartyMaster partyMaster, IBranchMaster branchMaster, ICompanyMaster companyMaster,
            IFinancialYearMaster financialYearMaster,
            ICalculatorMaster calculatorMaster)
        {
            _sizeMaster = sizeMaster;
            _numberMaster = numberMaster;
            _priceMaster = priceMaster;
            _partyMaster = partyMaster;
            _branchMaster = branchMaster;
            _companyMaster = companyMaster;
            _financialYearMaster = financialYearMaster;
            _calculatorMaster = calculatorMaster;
        }

        [Route("GetParty-calculator")]
        [HttpGet]
        public async Task<Response<dynamic>> GetPartyCalculator(string CompanyId)
        {
            try
            {
                var result = await _calculatorMaster.GetCalculatorMasterParties(CompanyId);

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

        [Route("GetDealer-calculator")]
        [HttpGet]
        public async Task<Response<dynamic>> GetDealerCalculator(string CompanyId)
        {
            try
            {
                var result = await _calculatorMaster.GetCalculatorMasterBrokers(CompanyId);

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

        [Route("GetParty")]
        [HttpGet]
        public async Task<Response<dynamic>> GetParty(string CompanyId)
        {
            try
            {

                var result = await _partyMaster.GetAllPartyAsync(CompanyId, new int[] { PartyTypeMaster.PartySale, PartyTypeMaster.PartyBuy });

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

        [Route("GetDealer")]
        [HttpGet]
        public async Task<Response<dynamic>> GetDealer(string CompanyId)
        {
            try
            {
                var result = await _partyMaster.GetAllPartyAsync(CompanyId, new int[] { PartyTypeMaster.Broker });
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

        [Route("GetBranch")]
        [HttpGet]
        public async Task<Response<dynamic>> GetBranch(string CompanyId)
        {
            try
            {
                var result = await _branchMaster.GetAllBranchAsync(CompanyId);
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

        [Route("GetSize")]
        [HttpGet]
        public async Task<Response<dynamic>> GetSize()
        {
            try
            {
                var result = await _priceMaster.GetAllSizesAsync();
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

        [Route("GetNumber")]
        [HttpGet]
        public async Task<Response<dynamic>> GetNumber()
        {
            try
            {
                var result = await _priceMaster.GetAllNumberAsync();
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

        [Route("GetPriceBySize")]
        [HttpGet]
        public async Task<Response<dynamic>> GetNumber(string size,string companyId)
        {
            try
            {
                var result = await _priceMaster.GetPriceBySize(Uri.UnescapeDataString(size), companyId);
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

        [Route("GetNumberPrice")]
        [HttpGet]
        public async Task<Response<dynamic>> GetNumberPrice(string companyId, string categoryId, string sizeId, string numberId)
        {
            try
            {
                var result = await _priceMaster.GetPricesAsync(companyId, categoryId, sizeId, numberId);

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

        [Route("GetAllNumberPrice")]
        [HttpGet]
        public async Task<Response<dynamic>> GetAllNumberPrice(string companyId, string categoryId)
        {
            try
            {
                var result = await _priceMaster.GetAllPricesAsync(companyId, categoryId);

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

        [Route("GetAllCompany")]
        [HttpGet]
        public async Task<Response<dynamic>> GetAllCompany(string userId)
        {
            try
            {
                var result = await _companyMaster.GetUserCompanyMappingAsync(userId);
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


        

        [Route("GetAllBranch")]
        [HttpGet]
        public async Task<Response<dynamic>> GetAllBranch()
        {
            try
            {
                var result = await _branchMaster.GetAllBranchAsync();
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

        [Route("GetAllFinancialYear")]
        [HttpGet]
        public async Task<Response<dynamic>> GetAllFinancialYear()
        {
            try
            {
                var result = await _financialYearMaster.GetAllFinancialYear();
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

        [Route("GetAllBranchByCompanyId")]
        [HttpGet]
        public async Task<Response<dynamic>> GetAllBranchByCompanyId(string companyId)
        {
            try
            {
                var result = await _branchMaster.GetAllBranchByCompanyIdAsync(companyId);
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