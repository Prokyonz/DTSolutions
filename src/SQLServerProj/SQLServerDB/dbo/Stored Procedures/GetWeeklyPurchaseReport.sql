CREATE PROCEDURE [GetWeeklyPurchaseReport]    
    
 @ActionType as int,    
 @CompanyId as varchar(50),                
 @FinancialYearId as varchar(50)        
    
AS        
    
if(@ActionType=0)    
BEGIN    
 select convert(varchar,Week)'WeekNo', convert(varchar,Week_Start_Date,103) + ' | ' + convert(varchar,Week_End_Date,103)'Period', sum(GrossTotal)'Amount',  
 convert(varchar,Week_Start_Date,112)'Week_Start_Date',convert(varchar,Week_End_Date,112)'Week_End_Date'   
 from(    
 SELECT DATEPART(week, pm.PaymentDueDate) AS Week    
 ,DATEADD(DAY, 2 - DATEPART(WEEKDAY, pm.PaymentDueDate), CAST(pm.PaymentDueDate AS DATE)) [Week_Start_Date]    
 ,DATEADD(DAY, 8 - DATEPART(WEEKDAY, pm.PaymentDueDate), CAST(pm.PaymentDueDate AS DATE)) [Week_End_Date],PM.GrossTotal    
  FROM [PurchaseMaster] AS PM     
  WHERE PM.CompanyId=@CompanyId AND PM.FinancialYearId=@FinancialYearId  AND PM.IsDelete = 0    
  )x    
  group by Week,Week_Start_Date,Week_End_Date    
 END