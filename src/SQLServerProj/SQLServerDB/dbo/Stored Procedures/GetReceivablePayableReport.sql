--GetReceivablePayableReport '9ce68881-bee2-44a1-8a9f-4449303accde','2ac16086-fb8c-4e2c-803b-1748dbe4fd30', 0 
CREATE proc [dbo].[GetReceivablePayableReport]              
@CompanyId as varchar(50)='',         
@FinancialYear as varchar(50) ='',        
@Type int = 0        
AS          
BEGIN        
 Declare @tempTable TABLE(    
 PartyType int,     
 Type varchar(100),    
 SubType varchar(100),     
 Id varchar(100),     
 Name varchar(100),    
 CompanyId varchar(100),     
 FinancialYearId varchar(100),     
 LedgerId varchar(100),     
 OpeningBalance decimal(18,2),     
 PurchaseAmount decimal(18,2),     
 Brokerage decimal(18,2),    
 SalesAmount decimal(18,2),    
 PaymentFrom varchar(200),     
 PaymentTo varchar(200),     
 ReceiptFrom decimal(18,2),     
 ReceiptTo decimal(18,2),     
 ClosingBalance decimal(18,2),
 Debit decimal(18,2),
 Credit decimal(18,2))        
 INSERT @tempTable EXEC [GetLedgerBalanceReport] @CompanyId, @FinancialYear        
        
 IF @Type = 0        
 BEGIN    
        
 -- Payables        
        
   --Declare @tempTable TABLE(PartyType int, Type varchar(100), SubType varchar(100), Id varchar(100), Name varchar(100),CompanyId varchar(100), FinancialYearId varchar(100), LedgerId varchar(100), OpeningBalance decimal(18,2), PurchaseAmount decimal(18,2), ReceiptFrom decimal(18,2), ReceiptTo decimal(18,2), ClosingBalance decimal(18,2))        
   --INSERT @tempTable EXEC [GetLedgerBalanceReport] @CompanyId, @FinancialYear        
        
	SELECT * FROM (      
           
		SELECT * FROM (      
      
			SELECT LOWER(NEWID()) 'Id', T.Type, T.PartyId, T.Name, (T.Total - (CASE WHEN Amount IS NULL THEN 0 ELSE Amount END)) 'Total', BrokerName, T.SlipNo, EntryDate     
			FROM (        
				 --SELECT 'Purchase' 'Type', PartyId, PM.Name, (SUM(GrossTotal) + SUM(CASE WHEN PM.CRDRType = 0 THEN LBM.Balance * -1 ELSE LBM.Balance END)) as Total, PM1.Name 'BrokerName', CAST(Date as Date) 'EntryDate', SlipNo     
				 SELECT 'Purchase' 'Type', PartyId, PM.Name, SUM(GrossTotal) as Total, PM1.Name 'BrokerName', CAST(Date as Date) 'EntryDate',SlipNo     				 
				 FROM PurchaseMaster PU        
				 INNER JOIN PartyMaster PM on PU.PartyId = PM.Id        
				 --INNER JOIN LedgerBalanceManager LBM ON LBM.LedgerId = PU.PartyId        
				 INNER JOIN PartyMaster PM1 ON PU.BrokerageId = PM1.Id        
				 WHERE PM.IsDelete = 0 AND PM1.IsDelete = 0 AND PU.isDelete = 0 AND PU.CompanyId = @CompanyId AND PU.FinancialYearId = @FinancialYear AND GrossTotal <> 0        
				 GROUP BY PartyId, PM.Name, PM1.Name, SlipNo, PU.Date

				 UNION ALL

				 SELECT 'Opening' 'Type',LBM.LedgerId, PM.Name, CASE WHEN PM.CRDRType = 0 THEN LBM.Balance * -1 ELSE LBM.Balance END AS Total, '' 'BrokerName', CAST(LBM.CreatedDate as Date) 'EntryDate',-1 'SlipNo'   
				 FROM LedgerBalanceManager LBM
				 INNER JOIN PartyMaster PM ON PM.Id = LBM.LedgerId
				 WHERE PM.IsDelete = 0 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYear AND LBM.Balance <> 0

			) T                  
			LEFT JOIN        
			(    
				SELECT GPM.CompanyId, GPM.FinancialYearId, PY.FromPartyId 'PartyId', SUM(PY.Amount) 'Amount', PD.SlipNo     
				FROM GroupPaymentMaster GPM        
				INNER JOIN PaymentMaster PY ON GPM.Id = PY.GroupId 
				INNER JOIN PaymentDetails PD ON PD.PaymentId = PY.Id       
				WHERE GPM.CrDrType=0  AND GPM.IsDelete=0 AND GPM.CompanyId = @CompanyId AND GPM.FinancialYearId = @FinancialYear
				Group By PY.FromPartyId,GPM.CompanyId, GPM.FinancialYearId, PD.SlipNo
			) M 
			ON T.PartyId = M.PartyId AND T.SlipNo = M.SlipNo

		) tempTable WHERE temptable.Total > 0      
        
		UNION 
           
		SELECT Id, Type, LedgerId 'PartyId', Name, ClosingBalance 'Total', '' 'BrokerName', '' SlipNo, CAST(CURRENT_TIMESTAMP as Date) 'EntryDate' from @tempTable         
		WHERE PartyType = 10 AND ClosingBalance > 0 AND ClosingBalance <> 0        
        
	)T        
        
	Order By SlipNo ASC        
END        
ELSE        
BEGIN        
        
 --Receivables        
        
  --Declare @tempTable TABLE(PartyType int, Type varchar(100), SubType varchar(100), Id varchar(100), Name varchar(100),CompanyId varchar(100), FinancialYearId varchar(100), LedgerId varchar(100), OpeningBalance decimal(18,2), PurchaseAmount decimal(18,2)
  
    
--, ReceiptFrom decimal(18,2), ReceiptTo decimal(18,2), ClosingBalance decimal(18,2))        
  --INSERT @tempTable EXEC [GetLedgerBalanceReport] 'ff8d3c9b-957b-46d1-b661-560ae4a2433e', '146c24c5-6663-4f3d-bdfd-80469275c898'        
        
	SELECT * FROM (       
      
		SELECT * FROM (      
         
			SELECT LOWER(NEWID()) 'Id', T.Type, T.PartyId, T.Name, (Total - (CASE WHEN Amount IS NULL THEN 0 ELSE Amount END)) 'Total', EntryDate, T.SlipNo, BrokerName 
			FROM (      
				--SELECT 'Sales' 'Type', PartyId, PM.Name, SUM(GrossTotal) + SUM(CASE WHEN PM.CRDRType = 1 THEN LBM.Balance * -1 ELSE LBM.Balance END) as Total, SlipNo, CAST(Date as Date) 'EntryDate', PM1.Name 'BrokerName' from SalesMaster SA        
				SELECT 'Sales' 'Type', PartyId, PM.Name, SUM(GrossTotal) 'Total', SlipNo, CAST(Date as Date) 'EntryDate', PM1.Name 'BrokerName' from SalesMaster SA        
				INNER JOIN PartyMaster PM on SA.PartyId = PM.Id        
				--INNER JOIN LedgerBalanceManager LBM ON LBM.LedgerId = SA.PartyId        
				INNER JOIN PartyMaster PM1 ON SA.BrokerageId = PM1.Id        
				WHERE PM.IsDelete = 0 AND PM1.IsDelete = 0 AND SA.IsDelete = 0 AND SA.CompanyId = @CompanyId AND SA.FinancialYearId = @FinancialYear AND GrossTotal <> 0        
				GROUP BY PartyId, PM.Name, SlipNo, Date, PM1.Name

				UNION ALL

				SELECT 'Opening' 'Type',LBM.LedgerId, PM.Name, CASE WHEN PM.CRDRType = 0 THEN LBM.Balance ELSE LBM.Balance * -1 END AS 'Total', -1 'SlipNo', CAST(LBM.CreatedDate as Date) 'EntryDate', '' 'BrokerName'
				FROM LedgerBalanceManager LBM
				INNER JOIN PartyMaster PM ON PM.Id = LBM.LedgerId
				WHERE PM.IsDelete = 0 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYear AND LBM.Balance <> 0

			) T                
			LEFT JOIN                
			(
				SELECT GPM.CompanyId, GPM.FinancialYearId, PY.FromPartyId 'PartyId', SUM(PY.Amount) 'Amount', PD.SlipNo
				FROM GroupPaymentMaster GPM        
				INNER JOIN PaymentMaster PY ON GPM.Id = PY.GroupId  
				INNER JOIN PaymentDetails PD ON PD.PaymentId = PY.Id      
				WHERE GPM.CrDrType=1 AND GPM.IsDelete=0 AND GPM.CompanyId = @CompanyId AND GPM.FinancialYearId = @FinancialYear
				Group By GPM.CompanyId, GPM.FinancialYearId, PY.FromPartyId, PD.SlipNo 

			) M           
			ON T.PartyId = M.PartyId AND T.SlipNo = M.SlipNo
      
		) tempTable WHERE Total <> 0
        
		UNION ALL        
              
		SELECT Id, Type, LedgerId 'PartyId', Name, ClosingBalance 'Total', CAST(CURRENT_TIMESTAMP as Date) 'EntryDate', '' SlipNo, '' 'BrokerName' from @tempTable         
		WHERE PartyType = 10 AND ClosingBalance < 0 AND ClosingBalance <> 0

		--UNION --LOAN GIVEN should be listed in Recevables		

	)T Order By SlipNo ASC        

 END           
END

--select * from loanMaster where companyId='a7265ea2-8fbf-4fb0-bd7e-ed8d09cccdd1' and LoanType=2