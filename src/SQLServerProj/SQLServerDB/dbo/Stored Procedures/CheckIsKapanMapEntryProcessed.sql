create proc CheckIsKapanMapEntryProcessed

@CompanyId as varchar(50),
@FinancialYearId as varchar(50),
@PurchaseDetailsId as varchar(50),
@SlipNo as varchar(50)

as

select am.* from AccountToAssortMaster am      
left join AccountToAssortDetails ad on ad.AccountToAssortMasterId=am.Id 
where am.CompanyId=@CompanyId and am.FinancialYearId=@FinancialYearId 
and ad.PurchaseDetailsId=@PurchaseDetailsId
and ad.SlipNo=@SlipNo