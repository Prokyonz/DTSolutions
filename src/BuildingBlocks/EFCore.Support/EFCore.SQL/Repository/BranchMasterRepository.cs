using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class BranchMasterRepository : IBranchMaster
    {
        private DatabaseContext _databaseContext;

        public BranchMasterRepository()
        {
        }

        public async Task<BranchMaster> AddBranchAsync(BranchMaster branchMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                try
                {
                    if (branchMaster.Id == null)
                        branchMaster.Id = Guid.NewGuid().ToString();
                    await _databaseContext.BranchMaster.AddAsync(branchMaster);
                    await _databaseContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw;
                }

                return branchMaster;
            }
        }

        public async Task<int> DeleteBranchAsync(string branchId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                try
                {
                    var resultCount = await _databaseContext.SPValidationModel.FromSqlRaw($"Validate_Records '" + branchId + "',2").ToListAsync();
                    return resultCount[0].Status;

                    //var getBranch = await _databaseContext.BranchMaster.Where(s => s.Id == branchId).FirstOrDefaultAsync();
                    //if (getBranch != null)
                    //{
                    //    getBranch.IsDelete = true;
                    //}
                    //await _databaseContext.SaveChangesAsync();
                    //return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public async Task<List<BranchMaster>> GetAllBranchAsync()
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.BranchMaster.Where(s => s.IsDelete == false).ToListAsync();
            }
        }

        public async Task<List<BranchMaster>> GetAllBranchAsync(string companyId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.BranchMaster.Where(w => w.IsDelete == false && w.CompanyId == companyId).ToListAsync();
            }
        }

        public async Task<BranchMaster> UpdateBranchAsync(BranchMaster branchMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getBranch = await _databaseContext.BranchMaster.Where(s => s.Id == branchMaster.Id).FirstOrDefaultAsync();
                if (getBranch != null)
                {
                    getBranch.Name = branchMaster.Name;
                    getBranch.Address = branchMaster.Address;
                    getBranch.Address2 = branchMaster.Address2;
                    getBranch.MobileNo = branchMaster.MobileNo;
                    getBranch.OfficeNo = branchMaster.OfficeNo;
                    getBranch.Details = branchMaster.Details;
                    getBranch.TermsCondition = branchMaster.TermsCondition;
                    getBranch.GSTNo = branchMaster.GSTNo;
                    getBranch.PanCardNo = branchMaster.PanCardNo;
                    getBranch.RegistrationNo = branchMaster.RegistrationNo;
                    getBranch.LessWeightId = branchMaster.LessWeightId;
                    getBranch.CVDWeight = branchMaster.CVDWeight;
                    getBranch.TipWeight = branchMaster.TipWeight;
                    getBranch.CreatedDate = branchMaster.CreatedDate;
                    getBranch.UpdatedDate = branchMaster.UpdatedDate;
                    getBranch.CreatedBy = branchMaster.CreatedBy;
                    getBranch.UpdatedBy = branchMaster.UpdatedBy;
                }
                await _databaseContext.SaveChangesAsync();
                return branchMaster;
            }
        }
    }
}
