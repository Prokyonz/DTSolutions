-- [dbo].[GetSalesReport] '00000000-0000-0000-0000-000000000000','2ac16086-fb8c-4e2c-803b-1748dbe4fd30','2021-05-01','2024-05-31', 0                   
CREATE PROCEDURE [dbo].[GetSalesReport]  
	@CompanyId as varchar(50),                      
	@FinancialYearId as varchar(50),            
	@FromDate as date = '',             
	@ToDate as date = '' ,        
	@ActionType INT = 0        
AS              
BEGIN              
IF @ActionType = 0             
            
	SELECT 
		SM.Id,
		BM.Name 'BranchName', 
		SM.CompanyId, 
		SM.FinancialYearId,           
		(case when SD.Category=1 then ISNULL(KM.Name,'') else ISNULL(N.Name,'') end) 'KapanName', 
		SM.SaleBillNo,           
		SM.SlipNo, 
		CAST(SM.Date as date) Date, 
		SM.Time, 
		SM.PartyId, 
		PAM.Name AS PartyName, 
		PAM.MobileNo,           
		SM.SalerId as SalerId, 
		PAM1.Name AS SalerName, 
		PAM1.MobileNo AS SalerMobileNo,             
		SM.BrokerageId, 
		PAM2.Name AS BrokerName, 
		PAM2.MobileNo AS BrokerMobileNo,             
		SM.GrossTotal 'Total', 
		SD.Amount 'GrossTotal', 
		SM.DueDays,SM.DueDate,
		SM.PaymentDays, 
		SM.PaymentDueDate, 
		SM.IsPF, 
		SM.IsSlip,             
		SM.UpdatedDate,
		SM.UpdatedBy, '' 'KapanId', 
		SD.Weight Weight,
		SD.SaleRate SaleRate, 
		ISNULL(SM1.Name, SM2.Name) 'SizeName',
		SM.Remarks, 
		SM.Message,             
		SUM(ROUND(SD.CVDAmount,0)) 'CVDAmount', 
		SUM(SD.LessDiscountPercentage) 'LessWeight', 
		SD.NetWeight NetWeight, 
		SM.RoundUpAmount,            
		CONVERT(varchar, SM.ApprovalType)'ApprovalType'                
	FROM [SalesMaster] AS SM               
	INNER JOIN [SalesDetails] AS SD ON SM.Id = SD.SalesId              
	INNER JOIN [PartyMaster] AS PAM ON PAM.Id = SM.PartyId              
	INNER JOIN [PartyMaster] AS PAM1 ON PAM1.Id = SM.SalerId              
	INNER JOIN [PartyMaster] AS PAM2 ON PAM2.Id = SM.BrokerageId     
	LEFT JOIN [SizeMaster] AS SM1 ON SM1.Id = SD.SizeId
	LEFT JOIN [SizeMaster] AS SM2 ON SM2.Id = SD.CharniSizeId
	LEFT JOIN BranchMaster AS BM ON SM.BranchId = BM.Id            
	LEFT JOIN [KapanMaster] AS KM ON KM.Id = SD.KapanId           
	LEFT JOIN [NumberMaster] AS N ON N.Id=SD.NumberSizeId             
	 WHERE SM.IsDelete = 0             
	AND (CAST(SM.Date as Date) >= @FromDate 
	AND CAST(SM.Date as Date) <= @ToDate)             
	AND SM.CompanyId = @CompanyId 
	AND SM.FinancialYearId = @FinancialYearId    	
            
 GROUP BY            
	SM.Id, SM.CompanyId, SM.FinancialYearId, SM.SaleBillNo, SM.SlipNo, SM.Date, SM.Time, SM.PartyId, 
	PAM.Name, PAM.MobileNo, SM.SalerId, PAM1.Name, PAM1.MobileNo,             
	SM.BrokerageId, PAM2.Name, PAM2.MobileNo,SD.SaleRate,SD.NetWeight,            
	SM.Total,SD.Amount, SM.DueDays,SM.DueDate, SM.PaymentDays, SM.PaymentDueDate, SM.IsPF, SM.IsSlip,             
	SM.UpdatedDate, SM.UpdatedBy, SM.Remarks, SM.Message,            
	SM.RoundUpAmount, SM.ApprovalType, BM.Name, KM.Name, N.Name, SD.Category, SD.Weight, SM.GrossTotal, SD.Id, SM1.Name, SM2.Name   
 ORDER BY 
	SM.Date,
	SM.Time,
	SM.SlipNo DESC         
        
ELSE        
        
             
 SELECT       
 ISNULL(ROUND(SUM(SD.Amount),2), 0) TotalAmount      
 FROM [SalesMaster] AS SM               
 INNER JOIN [SalesDetails] AS SD ON SM.Id = SD.SalesId                      
 WHERE   
 SM.IsDelete = 0             
 and (CAST(SM.Date as Date) >= @FromDate AND CAST(SM.Date as Date) <= @ToDate)             
 and SM.CompanyId=@CompanyId AND SM.FinancialYearId=@FinancialYearId           
END