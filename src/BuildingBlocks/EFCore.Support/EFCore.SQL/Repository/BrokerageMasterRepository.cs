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
        private readonly DatabaseContext _databaseContext;

        public BrokerageMasterRepository()
        {
            _databaseContext = new DatabaseContext();
        }

        public async Task<List<BrokerageMaster>> GetAllBrokerageAsync()
        {
            return await _databaseContext.BrokerageMaster.Where(b => b.IsDelete == false).ToListAsync();
        }

        public async Task<BrokerageMaster> AddBrokerageAsync(BrokerageMaster brokerageMaster)
        {
            if (brokerageMaster.Id == null)
                brokerageMaster.Id = Guid.NewGuid();
            await _databaseContext.BrokerageMaster.AddAsync(brokerageMaster);
            await _databaseContext.SaveChangesAsync();
            return brokerageMaster;
        }

        public async Task<bool> DeleteBrokerageAsync(Guid brokerageId, bool isPermanantDetele = false)
        {
            var getBrokerage = await _databaseContext.BrokerageMaster.Where(b => b.Id == brokerageId).FirstOrDefaultAsync();
            if (getBrokerage != null)
            {
                if (isPermanantDetele)
                    _databaseContext.BrokerageMaster.Remove(getBrokerage);
                else
                    getBrokerage.IsDelete = true;
                await _databaseContext.SaveChangesAsync();

                return true;
            }

            return false;
        }


        public async Task<BrokerageMaster> UpdateBrokerageAsync(BrokerageMaster brokerageMaster)
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
}
