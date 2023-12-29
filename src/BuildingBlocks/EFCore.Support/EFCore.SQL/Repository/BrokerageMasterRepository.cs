using EFCore.SQL.DBContext;
using EFCore.SQL.Interface;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Repository
{
    public class BrokerageMasterRepository : IBrokerageMaster
    {
        private DatabaseContext _databaseContext;

        public BrokerageMasterRepository()
        {
            
        }

        public async Task<List<BrokerageMaster>> GetAllBrokerageAsync(string CompanyId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.BrokerageMaster.Where(b => b.IsDelete == false).ToListAsync();
            }
        }

        public async Task<BrokerageMaster> AddBrokerageAsync(BrokerageMaster brokerageMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                if (brokerageMaster.Id == null)
                    brokerageMaster.Id = Guid.NewGuid().ToString();
                await _databaseContext.BrokerageMaster.AddAsync(brokerageMaster);
                await _databaseContext.SaveChangesAsync();
                return brokerageMaster;
            }
        }

        public async Task<int> DeleteBrokerageAsync(string brokerageId, bool isPermanantDetele = false)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var resultCount = await _databaseContext.SPValidationModel.FromSqlRaw($"Validate_Records '" + brokerageId + "',11").ToListAsync();
                return resultCount[0].Status;
                //var getBrokerage = await _databaseContext.BrokerageMaster.Where(b => b.Id == brokerageId).FirstOrDefaultAsync();
                //if (getBrokerage != null)
                //{
                //    if (isPermanantDetele)
                //        _databaseContext.BrokerageMaster.Remove(getBrokerage);
                //    else
                //        getBrokerage.IsDelete = true;
                //    await _databaseContext.SaveChangesAsync();

                //    return true;
                //}

                //return false;
            }
        }


        public async Task<BrokerageMaster> UpdateBrokerageAsync(BrokerageMaster brokerageMaster)
        {
            using (_databaseContext = new DatabaseContext())
            {
                var getBrokerage = await _databaseContext.BrokerageMaster.Where(b => b.Id == brokerageMaster.Id).FirstOrDefaultAsync();
                if (getBrokerage != null)
                {
                    getBrokerage.Name = brokerageMaster.Name;
                    getBrokerage.Percentage = brokerageMaster.Percentage;
                    getBrokerage.UpdatedDate = brokerageMaster.UpdatedDate;
                    getBrokerage.UpdatedBy = brokerageMaster.UpdatedBy;
                }
                await _databaseContext.SaveChangesAsync();
                return brokerageMaster;
            }
        }

        public async Task<BrokerageMaster> GetBrokerageAsync(string brokerageId)
        {
            using (_databaseContext = new DatabaseContext())
            {
                return await _databaseContext.BrokerageMaster.Where(b => b.IsDelete == false && b.Id == brokerageId).FirstOrDefaultAsync();
            }
        }
    }
}
