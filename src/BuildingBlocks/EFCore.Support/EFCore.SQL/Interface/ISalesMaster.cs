﻿using EFCore.SQL.DBContext;
using Repository.Entities;
using Repository.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.SQL.Interface
{
    public interface ISalesMaster
    {
        Task<List<SalesMaster>> GetAllSalesAsync(string companyId, string financialYearId);
        Task<List<SalesMaster>> GetAllSalesAsync(string companyId, DateTime startDate, DateTime endDate);
        Task<List<SalesMaster>> GetAllSalesAsync(string companyId, string branchId, string financialYearId);
        Task<List<SalesMaster>> GetAllSalesAsync(string companyId, string branchId, DateTime startDate, DateTime endDate);
        Task<SalesMaster> GetSalesAsync(string salesId);
        Task<List<SalesSPModel>> GetSalesReport(string companyId, string financialYearId, string fromDate, string toDate);
        Task<SalesMaster> AddSalesAsync(SalesMaster salesMaster);
        Task<SalesMaster> UpdateSalesAsync(SalesMaster salesMaster, DatabaseContext databaseContext);
        Task<bool> DeleteSalesDetailRangeAsync(List<SalesDetails> salesDetails, DatabaseContext databaseContext);
        Task<bool> DeleteSalesDetailSummaryRangeAsync(List<SalesDetailsSummary> salesDetailsSummary);
        Task<bool> AddSalesDetailRangeAsync(List<SalesDetails> salesDetails, DatabaseContext databaseContext);
        Task<bool> AddSalesDetailSummaryRangeAsync(List<SalesDetailsSummary> salesDetailsSummary);
        Task<long> GetMaxSlipNo(string companyId, string financialYearId);
        Task<long> GetMaxSrNo(string branchId, string financialYearId);
        Task<bool> DeleteSalesAsync(string salesId, bool isPermanantDetele = false);

        Task<List<SalesItemDetails>> GetSalesItemDetails(int ActionType, string companyId, string branchId, string financialYearId, DatabaseContext databaseContext=null);
        List<SalesItemDetails> GetSalesItemDetails1(int ActionType, string companyId, string branchId, string financialYearId);
        Task<List<CaratCategoryType>> GetCaratCategoryDetails();

        Task<bool> UpdateApprovalStatus(string salesId, string message, int status);
        List<SalesChildSPModel> GetSalesChild(string salesId);
        Task<List<SalesChildSPModel>> GetSalesChildAsync(string salesId);
        Task<DashboardSPModel> GetSalesTotal(string companyId, string financialYearId, string fromDate, string toDate);
        Task<bool> UpdateSlipPrintStatusAsync(string SalesId, bool SlipPrintStatus);
    }
}
