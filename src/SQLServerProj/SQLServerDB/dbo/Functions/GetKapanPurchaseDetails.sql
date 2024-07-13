--USE [diamondtrading]
--GO
--/****** Object:  UserDefinedFunction [dbo].[GetKapanPurchaseDetails]    Script Date: 03-05-2024 14:51:05 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--ALTER function [dbo].[GetKapanPurchaseDetails]  
--(  
--@kapanId varchar(max),  
--@CompanyId as varchar(50),  
--@FinancialYearId as varchar(50)  
--)        
--returns Table        
--as        
--return        
--(SELECT 1 as Id,CAST(PM.Date as date) Date, PM.SlipNo,'' as OperationType,'' as Size,                      
-- PAM.Name AS Party, PD.NetWeight as NetWeight,
-- (case when PD.LessWeight > 0 then PM.GrossTotal/PD.NetWeight else PD.BuyingRate end) as 'Rate', PM.GrossTotal as Amount,'Inward' as Category, 1 as CategoryId,1 as Records,      
-- KM.KapanId, km.BranchId      
-- FROM KapanMappingMaster KM                      
-- Left JOIN [PurchaseMaster] AS PM ON PM.Id=KM.PurchaseMasterId                      
-- Left JOIN [PurchaseDetails] AS PD ON PD.Id=KM.PurchaseDetailsId AND PM.Id = PD.PurchaseId                          
-- Left JOIN [PartyMaster] AS PAM ON PAM.Id = PM.PartyId                       
-- where KM.CompanyId=@CompanyId and KM.FinancialYearId=@FinancialYearId  
-- and KM.KapanId in (select id from CSVToTable(@kapanId)) and isnull(KM.TransferType,'')='')                    
-- --group by PM.Date,PM.SlipNo,PAM.Name,PM.GrossTotal,KM.KapanId,km.BranchId) 
 
-- --(SELECT 1 as Id,CAST(PM.Date as date) Date, PM.SlipNo,'' as OperationType,'' as Size,                      
-- --PAM.Name AS Party, sum(PD.NetWeight) as NetWeight,sum(PD.BuyingRate)/count(PM.SlipNo) 'Rate', PM.GrossTotal as Amount,'Inward' as Category, 1 as CategoryId,count(PM.SlipNo) as Records,      
-- --KM.KapanId, km.BranchId      
-- --FROM KapanMappingMaster KM                      
-- --Left JOIN [PurchaseMaster] AS PM ON PM.Id=KM.PurchaseMasterId                      
-- --Left JOIN [PurchaseDetails] AS PD ON PD.Id=KM.PurchaseDetailsId AND PM.Id = PD.PurchaseId                          
-- --Left JOIN [PartyMaster] AS PAM ON PAM.Id = PM.PartyId                       
-- --where KM.CompanyId=@CompanyId and KM.FinancialYearId=@FinancialYearId  
-- --and KM.KapanId in (select id from CSVToTable(@kapanId)) and isnull(KM.TransferType,'')=''                    
-- --group by PM.Date,PM.SlipNo,PAM.Name,PM.GrossTotal,KM.KapanId,km.BranchId) 

 CREATE FUNCTION [dbo].[GetKapanPurchaseDetails]  
(  
    @kapanId VARCHAR(MAX),  
    @CompanyId AS VARCHAR(50),  
    @FinancialYearId AS VARCHAR(50)  
)        
RETURNS TABLE        
AS        
RETURN        
(
    SELECT 
        1 AS Id,
        CAST(PM.Date AS DATE) AS Date,
        PM.SlipNo,
        '' AS OperationType,
        '' AS Size,
        PAM.Name AS Party,
        PD.NetWeight AS NetWeight,
        (CASE WHEN PD.LessWeight > 0 THEN PD.Amount / PD.NetWeight ELSE PD.BuyingRate END) AS Rate,
        PD.Amount AS Amount,
        'Inward' AS Category,
        1 AS CategoryId,
        1 AS Records,
        KM.KapanId,
        KM.BranchId      
    FROM 
        KapanMappingMaster KM                      
    LEFT JOIN [PurchaseMaster] AS PM ON PM.Id = KM.PurchaseMasterId                      
    LEFT JOIN [PurchaseDetails] AS PD ON PD.Id = KM.PurchaseDetailsId AND PM.Id = PD.PurchaseId                          
    LEFT JOIN [PartyMaster] AS PAM ON PAM.Id = PM.PartyId                       
    JOIN CSVToTable(@kapanId) AS K ON KM.KapanId = K.id
    WHERE 
        KM.CompanyId = @CompanyId 
        AND KM.FinancialYearId = @FinancialYearId  
        AND ISNULL(KM.TransferType, '') = ''
);