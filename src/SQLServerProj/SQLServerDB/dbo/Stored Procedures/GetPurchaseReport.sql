--EXEC  [GetPurchaseReport]    '00000000-0000-0000-0000-000000000000','2ac16086-fb8c-4e2c-803b-1748dbe4fd30','','2021-05-01','2024-05-31', 0     
      
CREATE   PROCEDURE [dbo].[GetPurchaseReport]               
(      
@CompanyId as varchar(50),                      
@FinancialYearId as varchar(50),          
@CurrentWeek as varchar(50)='',         
@FromDate as date = '',        
@ToDate as date = '' ,       
@ActionType INT = 0      
)      
AS              
          
BEGIN                
IF @ActionType = 0       
      
IF(@CurrentWeek = '')        
BEGIN        
 SELECT LOWER(NEWID()) 'Id', M.* FROM (        
 SELECT Distinct KapanId, Name 'KapanName', T.* from (        
  select        
   ISNULL(PD.NumberId, '') 'NumberId', ISNULL(NM.Name, '') 'NumberName', CAST(PM.Date as date) Date, BM.Name 'BranchName', PM.Id 'PurId', PM.CompanyId, PM.FinancialYearId, PM.PurchaseBillNo, PM.SlipNo, PM.Time, PM.PartyId,             
   PAM.Name AS PartyName, PAM.MobileNo, PM.ByuerId as BuyerId, PAM1.Name AS BuyerName, PAM1.MobileNo AS BuyerMobileNo,             
   PM.BrokerageId, PAM2.Name AS BrokerName, PAM2.MobileNo AS BrokerMobileNo, PM.GrossTotal 'Total',PD.Amount 'GrossTotal', PM.RoundUpAmount, PM.DueDays,             
   PM.DueDate, PM.PaymentDays, PM.PaymentDueDate, PM.IsPF, PM.IsSlip,PM.UpdatedDate, PM.UpdatedBy, PD.Weight,           
   SUM(PD.NetWeight) NetWeight, SUM(PD.LessDiscountPercentage) LessWeight, SUM(ROUND(PD.CVDAmount,0)) CVDAmount,           
   PD.BuyingRate, PM.Remarks, PM.Message, convert(varchar, PM.ApprovalType)'ApprovalType',convert(decimal(18,2),0) as AdjustAmount, SM.Name 'SizeName'        
        
   from PurchaseMaster PM         
   INNER JOIN [PurchaseDetails] AS PD ON PM.Id = PD.PurchaseId  
   LEFT JOIN [NumberMaster] AS NM ON PD.NumberId = NM.Id  
   INNER JOIN [PartyMaster] AS PAM ON PAM.Id = PM.PartyId              
   INNER JOIN [PartyMaster] AS PAM1 ON PAM1.Id = PM.ByuerId              
   INNER JOIN [PartyMaster] AS PAM2 ON PAM2.Id = PM.BrokerageId          
   INNER JOIN BranchMaster BM ON PM.BranchId = BM.Id
   LEFT JOIN SizeMaster SM ON SM.Id = PD.SizeId
        
  where PM.IsDelete = 0 and PM.CompanyId=@CompanyId AND PM.FinancialYearId=@FinancialYearId         
  and (CAST(PM.Date as Date) >= @FromDate AND CAST(PM.Date as Date) <= @ToDate)         
        
  GROUP BY         
  PM.Date, PM.Id, PM.CompanyId, PM.FinancialYearId, PM.PurchaseBillNo, PM.SlipNo, PM.Time, PM.PartyId,             
  PAM.Name, PAM.MobileNo, PM.ByuerId, PAM1.Name, PAM1.MobileNo,             
  PM.BrokerageId, PAM2.Name, PAM2.MobileNo, PD.Amount, PM.RoundUpAmount, PM.DueDays,             
  PM.DueDate, PM.PaymentDays, PM.PaymentDueDate, PM.IsPF, PM.IsSlip,         
  PM.Remarks, PM.Message, PM.ApprovalType,BM.Name,PM.UpdatedDate, PM.UpdatedBy, PD.Weight, PD.BuyingRate, PM.GrossTotal, PD.NumberId, NM.Name, SM.Name        
         
 )T         
 LEFT JOIN KapanMappingMaster KMM ON KMM.PurchaseMasterId = T.PurId        
 LEFT JOIN KapanMaster KM ON KM.Id = KapanId        
 ) M        
 order by M.Date,M.Time,M.SlipNo desc        
END        
ELSE         
BEGIN        
SELECT LOWER(NEWID()) 'Id', M.* FROM (        
 SELECT Distinct KapanId, Name 'KapanName', T.* from (        
  select        
   ISNULL(PD.NumberId, '') 'NumberId', ISNULL(NM.Name, '') 'NumberName', CAST(PM.Date as date) Date, BM.Name 'BranchName', PM.Id 'PurId', PM.CompanyId, PM.FinancialYearId, PM.PurchaseBillNo, PM.SlipNo, PM.Time, PM.PartyId,             
   PAM.Name AS PartyName, PAM.MobileNo, PM.ByuerId as BuyerId, PAM1.Name AS BuyerName, PAM1.MobileNo AS BuyerMobileNo,             
   PM.BrokerageId, PAM2.Name AS BrokerName, PAM2.MobileNo AS BrokerMobileNo, PM.GrossTotal 'Total',PD.Amount 'GrossTotal', PM.RoundUpAmount, PM.DueDays,             
   PM.DueDate, PM.PaymentDays, PM.PaymentDueDate, PM.IsPF, PM.IsSlip,PM.UpdatedDate, PM.UpdatedBy, PD.Weight,           
   SUM(PD.NetWeight) NetWeight, SUM(PD.LessDiscountPercentage) LessWeight, SUM(ROUND(PD.CVDAmount,0)) CVDAmount,           
   PD.BuyingRate, PM.Remarks, PM.Message, convert(varchar, PM.ApprovalType)'ApprovalType',convert(decimal(18,2),0) as AdjustAmount        
        
   from PurchaseMaster PM         
   INNER JOIN [PurchaseDetails] AS PD ON PM.Id = PD.PurchaseId  
   LEFT JOIN [NumberMaster] AS NM ON PD.NumberId = NM.Id  
   INNER JOIN [PartyMaster] AS PAM ON PAM.Id = PM.PartyId              
   INNER JOIN [PartyMaster] AS PAM1 ON PAM1.Id = PM.ByuerId              
   INNER JOIN [PartyMaster] AS PAM2 ON PAM2.Id = PM.BrokerageId          
   INNER JOIN BranchMaster BM ON PM.BranchId = BM.Id        
        
  where PM.IsDelete = 0 and PM.CompanyId=@CompanyId AND PM.FinancialYearId=@FinancialYearId         
  and (@CurrentWeek = '' or DATEPART(week, pm.PaymentDueDate)=@CurrentWeek)          
        
  GROUP BY         
  PM.Date, PM.Id, PM.CompanyId, PM.FinancialYearId, PM.PurchaseBillNo, PM.SlipNo, PM.Time, PM.PartyId,             
  PAM.Name, PAM.MobileNo, PM.ByuerId, PAM1.Name, PAM1.MobileNo,             
  PM.BrokerageId, PAM2.Name, PAM2.MobileNo, PD.Amount, PM.RoundUpAmount, PM.DueDays,             
  PM.DueDate, PM.PaymentDays, PM.PaymentDueDate, PM.IsPF, PM.IsSlip,         
  PM.Remarks, PM.Message, PM.ApprovalType,BM.Name,PM.UpdatedDate, PM.UpdatedBy, PD.Weight, PD.BuyingRate, PM.GrossTotal, PD.NumberId, NM.Name              
         
 )T         
 LEFT JOIN KapanMappingMaster KMM ON KMM.PurchaseMasterId = T.PurId        
 LEFT JOIN KapanMaster KM ON KM.Id = KapanId        
 ) M        
 order by M.Date,M.Time,M.SlipNo desc         
END        
      
ELSE      
      
IF(@CurrentWeek = '')        
BEGIN        
             
  SELECT        
		ISNULL(ROUND(SUM(PM.Total),2),0) TotalAmount 
  FROM 
	PurchaseMaster PM         
  WHERE 
  PM.IsDelete = 0 
  AND PM.CompanyId= @CompanyId 
  AND PM.FinancialYearId = @FinancialYearId         
  AND (CAST(PM.Date as Date) >= @FromDate 
  AND CAST(PM.Date as Date) <= @ToDate)         
       
END        
ELSE         
BEGIN        
SELECT ISNULL(ROUND(SUM(M.grossTotal),2),0) TotalAmount FROM   
 (        
  SELECT  T.* FROM   
  (        
   SELECT  
    PM.Total 'GrossTotal',PM.Id 'PurId'  
   FROM PurchaseMaster PM         
   --INNER JOIN [PurchaseDetails] AS PD ON PM.Id = PD.PurchaseId              
   WHERE PM.IsDelete = 0 AND PM.CompanyId= @CompanyId AND PM.FinancialYearId= @FinancialYearId         
   AND (@CurrentWeek = '' OR DATEPART(week, pm.PaymentDueDate)= @CurrentWeek)          
  
   )T         
  LEFT JOIN KapanMappingMaster KMM ON KMM.PurchaseMasterId = T.PurId        
 ) M        
      
END         
END