CREATE function GetKapanSaleDetail
(
@kapanId varchar(max),
@CompanyId as varchar(50),
@FinancialYearId as varchar(50)
)      
returns Table      
as      
return      
(SELECT 0 as Id,CAST(S.Date as date) Date, S.SlipNo,'' as OperationType,'' as Size,                    
 PAM.Name AS Party, SD.NetWeight as NetWeight,SD.SaleRate 'Rate', S.GrossTotal as Amount,'Outward' as Category, 2 as CategoryId, 1 as Records,    
 K.Id as KapanId, s.BranchId    
 FROM [SalesMaster] S                    
 INNER JOIN [SalesDetails] AS SD ON SD.SalesId=S.Id                    
 INNER JOIN [KapanMaster] AS K ON K.Id=SD.KapanId                    
 INNER JOIN [PartyMaster] AS PAM ON PAM.Id = S.PartyId                     
 where S.CompanyId=@CompanyId and S.FinancialYearId=@FinancialYearId
 and SD.Category=1 and K.Id in (select id from CSVToTable(@kapanId)))