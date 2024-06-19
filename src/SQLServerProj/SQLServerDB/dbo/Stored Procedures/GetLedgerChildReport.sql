--Exec GetLedgerChildReport 'c444ca9f-03ec-493f-9447-4e1bf15eefbf','8e34d261-0a6b-44ac-9f86-89d5fdd5ef56','02d1865c-0415-491b-95e3-fce214b5c5fa'              
CREATE proc [dbo].[GetLedgerChildReport]                       
@CompanyId as varchar(50),              
@FinancialYearId as varchar(50),              
@LedgerId as varchar(50),
@PartyType as INT = 1                            
AS                
BEGIN              
	IF @PartyType > 0
	BEGIN              
		SELECT 'OpeningBalance' 'EntryType', '' 'FromPartyId', '' 'FromPartyName', '' 'ToPartyId', '' 'ToPartyName', '' 'SlipNo',   
		(CASE WHEN PM.CRDRType = 0 THEN Balance ELSE 0 END) 'Debit',   
		(CASE WHEN PM.CRDRType = 1 THEN Balance ELSE 0 END) 'Credit', CAST(LBM.CreatedDate as Date) 'Date', '' Remarks From LedgerBalanceManager LBM INNER JOIN PartyMaster PM  
		ON LBM.LedgerId = PM.Id  
		WHERE LedgerId = @LedgerId              
              
		UNION  ALL            
              
		SELECT * FROM (              
              
		 SELECT 'Contra' 'EntryType', CEM.ToPartyId 'FromPartyId', PM.Name 'FromPartyName', CED.FromParty 'ToPartyId', PM1.Name 'ToPartyName','' 'SlipNo', CED.Amount 'Debit', 0 'Credit', CAST(CEM.Entrydate as Date) 'Date', Remarks 
		 From ContraEntryMaster CEM      
         
		 Inner JOIN ContraEntryDetails CED ON CEM.Id = CED.ContraEntryMasterId              
		 INNER JOIN PartyMaster PM ON CEM.ToPartyId = PM.Id              
		 INNER JOIN PartyMaster PM1 ON CED.FromParty = PM1.Id              
              
		 WHERE CEM.IsDelete = 0 AND CEM.ToPartyId = @LedgerId AND CEM.FinancialYearId = @FinancialYearId AND CEM.CompanyId = @CompanyId              
              
		 UNION ALL              
              
		 SELECT 'Contra' 'EntryType',  CEM.ToPartyId 'FromPartyId', PM1.Name 'FromPartyName', CED.FromParty 'ToPartyId', PM.Name 'ToPartyName','' 'SlipNo', 0 'Debit', CED.Amount 'Credit', CAST(CEM.EntryDate as Date) 'Date', Remarks 
		 From ContraEntryMaster CEM     
          
		 Inner JOIN ContraEntryDetails CED ON CEM.Id = CED.ContraEntryMasterId              
		 INNER JOIN PartyMaster PM ON CED.FromParty = PM.Id              
		 INNER JOIN PartyMaster PM1 ON CEM.ToPartyId = PM1.Id              
              
		 WHERE CEM.IsDelete = 0 AND CED.FromParty = @LedgerId AND CEM.FinancialYearId = @FinancialYearId AND CEM.CompanyId = @CompanyId              
              
		 UNION ALL              
               
		 SELECT 'Receipt' 'EntryType', MainTable.FromPartyId, pm.Name 'FromPartyName', MainTable.ToPartyId, PM1.Name 'ToPartyName', ISNULL(SlipNo, '') 'SlipNo', 0 'Debit', Amount 'Credit',  MainTable.Date, Remarks              
		 FROM (              
		  SELECT (case when pd.SlipNo=-2 then convert(varchar,pd.SlipNo)+'-'+convert(varchar,g.BillNo) else pd.SlipNo end) 'SlipNo',       
		  g.id, g.companyid, g.financialyearid, p.FromPartyId, g.ToPartyId, CASE WHEN ISNULL(pd.amount,0) = 0 THEN p.Amount ELSE pd.Amount END as 'amount', CAST(g.EntryDate as Date) 'Date', g.Remarks FROM grouppaymentmaster g              
		   INNER JOIN paymentmaster p on g.id = p.groupid               
		   left join paymentdetails pd on pd.groupid = g.id and pd.PaymentId=p.Id          
		   WHERE g.crdrtype=1 AND g.IsDelete=0 AND g.FinancialYearId = @FinancialYearId AND g.CompanyId = @CompanyId              
		  ) MainTable              
              
		 INNER JOIN PartyMaster pm on pm.Id = MainTable.FromPartyId              
		 INNER JOIN PartyMaster PM1 ON PM1.Id = MainTable.ToPartyId              
              
		 WHERE FromPartyId = @LedgerId               
              
		 UNION ALL            
              
		 SELECT 'Receipt' 'EntryType', MainTable.FromPartyId, PM1.Name 'FromPartyName', MainTable.ToPartyId, pm.Name 'ToPartyName',ISNULL(SlipNo, '') 'SlipNo', 0 'Debit', Amount 'Credit', MainTable.Date, Remarks               
		 FROM (              
		   SELECT (case when pd.SlipNo=-2 then convert(varchar,pd.SlipNo)+'-'+convert(varchar,g.BillNo) else pd.SlipNo end) 'SlipNo',      
			g.id, g.companyid, g.financialyearid, p.FromPartyId, g.ToPartyId, CASE WHEN ISNULL(pd.amount,0) = 0 THEN p.Amount ELSE pd.Amount END as 'amount', CAST(g.EntryDate as Date) 'Date', g.Remarks from grouppaymentmaster g              
		   INNER JOIN paymentmaster p on g.id = p.groupid               
		   left join paymentdetails pd on pd.groupid = g.id and pd.PaymentId=p.Id                  
		   WHERE g.crdrtype=1 AND g.IsDelete = 0 AND g.FinancialYearId = @FinancialYearId AND g.CompanyId = @CompanyId              
		  ) MainTable              
              
		 INNER JOIN PartyMaster pm on pm.Id = MainTable.ToPartyId              
		 INNER JOIN PartyMaster PM1 ON PM1.Id = MainTable.FromPartyId              
              
		 WHERE ToPartyId = @LedgerId              
              
		 UNION ALL              
              
		 SELECT 'Payment' 'EntryType', MainTable.FromPartyId 'ToPartyId', pm.Name 'ToPartyName', MainTable.ToPartyId 'FromPartyId', PM1.Name 'FromPartyName',ISNULL(SlipNo, '') 'SlipNo', amount 'Debit', 0 'Credit', MainTable.Date, Remarks               
		 FROM (              
		   SELECT (case when pd.SlipNo=-2 then convert(varchar,pd.SlipNo)+'-'+convert(varchar,g.BillNo) else pd.SlipNo end) 'SlipNo',      
		   pd.Sr, g.id, g.companyid, g.financialyearid, p.FromPartyId, g.ToPartyId, CASE WHEN ISNULL(pd.amount,0) = 0 THEN p.Amount ELSE pd.Amount END as 'amount', CAST(g.EntryDate as Date) 'Date', g.Remarks from grouppaymentmaster g              
		   INNER join paymentmaster p on g.id = p.groupid               
		   LEFT join paymentdetails pd on pd.groupid = g.id and pd.PaymentId=p.Id         
		   WHERE g.crdrtype=0 AND g.IsDelete = 0 AND g.FinancialYearId = @FinancialYearId AND g.CompanyId = @CompanyId              
		   --order by g.EntryDate,pd.Sr        
		  ) MainTable              
		 INNER JOIN PartyMaster pm on pm.Id = MainTable.FromPartyId              
		 INNER JOIN PartyMaster PM1 ON PM1.Id = MainTable.ToPartyId              
		 WHERE FromPartyId = @LedgerId              
              
		 UNION ALL              
              
		 SELECT 'Payment' 'EntryType', MainTable.FromPartyId, pm.Name 'FromPartyName', MainTable.ToPartyId, PM1.Name 'ToPartyName', ISNULL(SlipNo, '') 'SlipNo', amount 'Debit', 0 'Credit', MainTable.Date, Remarks                
		 FROM (              
		   SELECT (case when pd.SlipNo=-2 then convert(varchar,pd.SlipNo)+'-'+convert(varchar,g.BillNo) else pd.SlipNo end) 'SlipNo',      
		   g.id, g.companyid, g.financialyearid, p.FromPartyId, g.ToPartyId, CASE WHEN ISNULL(pd.amount,0) = 0 THEN p.Amount ELSE pd.Amount END as 'amount', CAST(g.EntryDate as Date) 'Date', g.Remarks from grouppaymentmaster g              
		   INNER JOIN paymentmaster p on g.id = p.groupid               
		   LEFT JOIN paymentdetails pd on pd.groupid = g.id and pd.PaymentId=p.Id                   
		   WHERE g.crdrtype=0 AND g.IsDelete = 0 AND g.FinancialYearId = @FinancialYearId AND g.CompanyId = @CompanyId              
		  ) MainTable              
              
		 INNER JOIN PartyMaster pm on pm.Id = MainTable.ToPartyId              
		 INNER JOIN PartyMaster PM1 ON PM1.Id = MainTable.FromPartyId              
              
		 WHERE ToPartyId = @LedgerId              
              
		 UNION ALL              
              
		 SELECT 'Expense' 'EntryTpe',FromPartyId, PM.Name 'FromPartyName', PartyId 'ToPartyId', PM1.Name 'ToPartyName','' 'SlipNo',  CAST(Amount as Decimal(18,2)) 'Debit', 0 'Credit', CAST(ED.EntryDate as date) 'Date', Remarks FROM ExpenseDetails ED              
		 INNER JOIN PartyMaster PM ON ED.fromPartyId = PM.Id              
		 INNER JOIN PartyMaster PM1 ON ED.PartyId = PM1.Id              
              
		 WHERE ED.IsDelete = 0 AND PM.IsDelete=0 AND PM1.IsDelete=0 AND ED.CRDRTYPE=0 AND FromPartyId = @LedgerId AND ED.FinancialYearId = @FinancialYearId AND ED.CompanyId = @CompanyId              

		 UNION ALL

		 SELECT 'Expense' 'EntryTpe',FromPartyId, PM.Name 'FromPartyName', PartyId 'ToPartyId', PM1.Name 'ToPartyName','' 'SlipNo',  0 'Debit', CAST(Amount as Decimal(18,2)) 'Credit', CAST(ED.EntryDate as date) 'Date', Remarks FROM ExpenseDetails ED              
		 INNER JOIN PartyMaster PM ON ED.fromPartyId = PM.Id              
		 INNER JOIN PartyMaster PM1 ON ED.PartyId = PM1.Id              
              
		 WHERE ED.IsDelete = 0 AND PM.IsDelete=0 AND PM1.IsDelete=0 AND ED.CRDRTYPE=1 AND FromPartyId = @LedgerId AND ED.FinancialYearId = @FinancialYearId AND ED.CompanyId = @CompanyId              
              
		 UNION ALL              
              
		 SELECT 'Expense' 'EntryTpe',FromPartyId, PM.Name 'FromPartyName', PartyId 'ToPartyId', PM1.Name 'ToPartyName','' 'SlipNo',  CAST(Amount as Decimal(18,2)) 'Debit', 0 'Credit', CAST(ED.EntryDate as date) 'Date', Remarks FROM ExpenseDetails ED              
		 INNER JOIN PartyMaster PM ON ED.fromPartyId = PM.Id              
		 INNER JOIN PartyMaster PM1 ON ED.PartyId = PM1.Id              
              
		 WHERE ED.IsDelete = 0 AND PM.IsDelete=0 AND PM1.IsDelete=0 AND ED.CRDRTYPE=0 AND PartyId = @LedgerId AND ED.FinancialYearId = @FinancialYearId AND ED.CompanyId = @CompanyId              
              
		 UNION ALL

		 SELECT 'Expense' 'EntryTpe',FromPartyId, PM.Name 'FromPartyName', PartyId 'ToPartyId', PM1.Name 'ToPartyName','' 'SlipNo', 0 'Debit', CAST(Amount as Decimal(18,2)) 'Credit', CAST(ED.EntryDate as date) 'Date', Remarks FROM ExpenseDetails ED              
		 INNER JOIN PartyMaster PM ON ED.fromPartyId = PM.Id              
		 INNER JOIN PartyMaster PM1 ON ED.PartyId = PM1.Id              
              
		 WHERE ED.IsDelete = 0 AND PM.IsDelete=0 AND PM1.IsDelete=0 AND ED.CRDRTYPE=1 AND PartyId = @LedgerId AND ED.FinancialYearId = @FinancialYearId AND ED.CompanyId = @CompanyId              
              
		 UNION ALL              
              
		 SELECT 'Purchase' 'EntryType', PartyId 'FromPartyId', PM1.Name 'FromPartyName', '' 'ToPartyId', '' 'ToPartyName',CAST(SlipNo as nvarchar(100)) 'SlipNo',  0 'Debit', CAST(GrossTotal as Decimal(18,2)) 'Credit', CAST([Date] as Date) 'Date', Remarks 
		 FROM PurchaseMaster PM              
		 INNER JOIN PartyMaster PM1 ON PM.PartyId = PM1.Id              
              
		 WHERE PM.IsDelete = 0 AND PM1.IsDelete=0 AND PartyId = @LedgerId AND PM.FinancialYearId = @FinancialYearId AND PM.CompanyId = @CompanyId              
         
		 UNION ALL

		 -- Rejection Out from Purchase
		 SELECT 'Rejection Out/Send' 'EntryType', PM1.Id 'FromPartyId', PM1.Name 'Name', '' 'ToPartyId', '' 'ToPartyName', 
		 CAST(RJ.SlipNo as nvarchar(100)) 'SlipNo', RJ.Amount 'Debit', 0 'Credit', CAST([EntryDate] as Date) 'Date', RJ.Remarks 'Remarks' 
		 FROM RejectionInOutMaster RJ
		 INNER JOIN PurchaseDetails PD ON RJ.PurchaseSaleDetailsId = PD.Id
		 LEFT JOIN PurchaseMaster PM ON PD.PurchaseId = PM.Id
		 INNER JOIN PartyMaster PM1 ON PM1.Id = PM.PartyId
		 WHERE PM1.Type=1 AND RJ.TransType=2 AND RJ.Amount > 0 AND PM1.Id = @LedgerId AND PM1.IsDelete = 0 AND RJ.FinancialYearId = @FinancialYearId AND RJ.CompanyId = @CompanyId		 

		 UNION ALL

		 -- Rejection In from Sales
		 SELECT 'Rejection In/Receive' 'EntryType', PM1.Id 'FromPartyId', PM1.Name 'Name', '' 'ToPartyId', '' 'ToPartyName', 
		 CAST(RJ.SlipNo as nvarchar(100)) 'SlipNo', 0 'Debit', RJ.Amount 'Credit', CAST([EntryDate] as Date) 'Date', RJ.Remarks 'Remarks' 
		 FROM RejectionInOutMaster RJ
		 INNER JOIN SalesDetails SD ON RJ.PurchaseSaleDetailsId = SD.Id
		 LEFT JOIN SalesMaster SM ON SD.SalesId = SM.Id
		 INNER JOIN PartyMaster PM1 ON PM1.Id = SM.PartyId
		 WHERE PM1.Type=14 AND RJ.TransType=1 AND RJ.Amount > 0 AND PM1.Id = @LedgerId AND PM1.IsDelete = 0 AND RJ.FinancialYearId = @FinancialYearId AND RJ.CompanyId = @CompanyId		 

		 UNION ALL              
		 -- Get Brokerage of Purcahse             
		 SELECT 'Brokerage' 'EntryType', PartyId 'FromPartyId', PM1.Name 'FromPartyName', PM.BrokerageId 'ToPartyId', PM2.Name 'ToPartyName',CAST(SlipNo as nvarchar(max)) 'SlipNo',  0 'Debit', CAST(BrokerAmount as Decimal(18,2)) 'Credit', CAST([Date] as Date) 'Date', Remarks FROM PurchaseMaster PM              
		 INNER JOIN PartyMaster PM1 ON PM.PartyId = PM1.Id              
		 INNER JOIN PartyMaster PM2 ON PM.BrokerageId = PM2.Id              
              
		 WHERE BrokerAmount > 0 AND PM.IsDelete = 0 AND PM1.IsDelete=0 AND PM2.IsDelete=0 AND PM.BrokerageId = @LedgerId AND PM.FinancialYearId = @FinancialYearId AND PM.CompanyId = @CompanyId              
  
		 UNION ALL  
		 -- Get Brokerage of Sales  
		 SELECT 'Brokerage' 'EntryType', PartyId 'FromPartyId', PM1.Name 'FromPartyName', SM.BrokerageId 'ToPartyId', PM2.Name 'ToPartyName',CAST(SlipNo as nvarchar(max)) 'SlipNo',  0 'Debit', CAST(BrokerAmount as Decimal(18,2)) 'Credit', CAST([Date] as Date) 'Date', Remarks   
		 FROM SalesMaster SM              
		 INNER JOIN PartyMaster PM1 ON SM.PartyId = PM1.Id              
		 INNER JOIN PartyMaster PM2 ON SM.BrokerageId = PM2.Id              
              
		 WHERE BrokerAmount > 0 AND SM.IsDelete = 0 AND PM1.IsDelete=0 AND PM2.IsDelete=0 AND SM.BrokerageId = @LedgerId AND SM.FinancialYearId = @FinancialYearId AND SM.CompanyId = @CompanyId  
  
		 UNION ALL          
  
		 SELECT 'CommissionBuyer' 'EntryType', PartyId 'FromPartyId', PM1.Name 'FromPartyName', PM.ByuerId 'ToPartyId', PM2.Name 'ToPartyName',CAST(SlipNo as nvarchar(max)) 'SlipNo',  0 'Debit', CAST(CommissionAmount as Decimal(18,2)) 'Credit', CAST([Date] as Date) 'Date', Remarks 
		 FROM PurchaseMaster PM          
		 INNER JOIN PartyMaster PM1 ON PM.PartyId = PM1.Id          
		 INNER JOIN PartyMaster PM2 ON PM.ByuerId = PM2.Id          
          
		 WHERE PM.IsDelete = 0 AND PM1.IsDelete=0 AND PM2.IsDelete=0 AND PM.ByuerId = @LedgerId AND PM.FinancialYearId = @FinancialYearId AND PM.CompanyId = @CompanyId  
  
		 UNION ALL  
  
		 SELECT 'CommissionSaler' 'EntryType', PartyId 'FromPartyId', PM1.Name 'FromPartyName', SM.SalerId 'ToPartyId', PM2.Name 'ToPartyName',CAST(SlipNo as nvarchar(max)) 'SlipNo',  0 'Debit', CAST(CommissionAmount as Decimal(18,2)) 'Credit', CAST([Date] as Date) 'Date', Remarks 
		 FROM SalesMaster SM          
		 INNER JOIN PartyMaster PM1 ON SM.PartyId = PM1.Id          
		 INNER JOIN PartyMaster PM2 ON SM.SalerId = PM2.Id          
          
		 WHERE SM.IsDelete = 0 AND PM1.IsDelete=0 AND PM2.IsDelete=0 AND SM.SalerId = @LedgerId AND SM.FinancialYearId = @FinancialYearId AND SM.CompanyId = @CompanyId  
              
		 UNION ALL              
              
		 SELECT 'Sales' 'EntryType', PartyId 'FromPartyId', PM.Name 'FromPartyName', '' 'ToPartyId', '' 'ToPartyName', CAST(SlipNo as nvarchar(max)) 'SlipNo', CAST(GrossTotal as Decimal(18,2)) 'Debit', 0 'Credit', CAST([Date] as Date) 'Date', Remarks 
		 FROM SalesMaster SM              
		 INNER JOIN PartyMaster PM ON SM.PartyId = PM.Id              
              
		 WHERE SM.IsDelete = 0 AND PM.IsDelete=0 AND PartyId = @LedgerId AND SM.FinancialYearId = @FinancialYearId AND SM.CompanyId = @CompanyId              
              
		 UNION ALL              
              
		 SELECT 'Salary' 'EntryType', '' 'FromPartyId', '' 'FromPartyName', ToPartyId, PM.Name 'ToPartyName', '0' 'SlipNo', 0 'Debit', CAST(TotalAmount as Decimal(18,2)) 'Credit', CAST(SalaryMonthDateTime as Date) 'Date', Remarks FROM SalaryDetails SD            
  
		 INNER JOIN SalaryMaster SM ON SM.Id = SD.SalaryMasterId              
		 INNER JOIN PartyMaster PM ON SD.ToPartyId = PM.Id              
		 Where ToPartyId = @LedgerId AND SM.FinancialYearId = @FinancialYearId AND SM.CompanyId = @CompanyId              
              
		 UNION ALL              
              
		 SELECT 'Loan - Received' 'EntryType', PartyId 'FromPartyId', PM.Name 'FromPartyName', LM.CashBankPartyId 'ToPartyId', PM1.Name 'ToPartyName', '0' 'SlipNo', 0 'Debit', CAST(Amount as Decimal(18,2)) 'Credit', CAST(LM.EntryDate as Date) 'Date', Remarks FROM
		 LoanMaster LM              
		 INNER JOIN PartyMaster PM1 ON PM1.Id = LM.CashBankPartyId              
		 INNER JOIN PartyMaster PM ON LM.PartyId = PM.Id              
		 Where LM.IsDelete = 0 AND PM.IsDelete = 0 AND PM1.IsDelete = 0 AND LM.PartyId = @LedgerId AND LM.LoanType = 1 AND LM.CompanyId = @CompanyId                
		 UNION ALL              
              
		 SELECT 'Loan - Given' 'EntryType', LM.PartyId 'FromPartyId', PM1.Name 'FromPartyName', LM.CashBankPartyId 'ToPartyId', PM.Name 'ToPartyName', '0' 'SlipNo', 0  'Debit', CAST(Amount as Decimal(18,2)) 'Credit', CAST(LM.EntryDate as Date) 'Date', Remarks 
		 FROM LoanMaster LM              
		 INNER JOIN PartyMaster PM1 ON PM1.Id = LM.PartyId              
		 INNER JOIN PartyMaster PM ON LM.CashBankPartyId = PM.Id              
		 Where LM.IsDelete = 0 AND PM.IsDelete = 0 AND PM1.IsDelete = 0 AND LM.PartyId = @LedgerId AND  LM.LoanType = 2 AND LM.CompanyId = @CompanyId              
              
		 UNION ALL              
              
		 SELECT 'Loan - Received' 'EntryType', PartyId 'FromPartyId', PM.Name 'FromPartyName', LM.CashBankPartyId 'ToPartyId', PM1.Name 'ToPartyName', '0' 'SlipNo', 0 'Debit', CAST(Amount as Decimal(18,2)) 'Credit', CAST(LM.EntryDate as Date) 'Date', Remarks FROM
		 LoanMaster LM              
		 INNER JOIN PartyMaster PM1 ON PM1.Id = LM.CashBankPartyId              
		 INNER JOIN PartyMaster PM ON LM.PartyId = PM.Id              
		 Where LM.IsDelete = 0 AND PM.IsDelete = 0 AND PM1.IsDelete = 0 AND LM.CashBankPartyId = @LedgerId AND LM.LoanType = 1 AND LM.CompanyId = @CompanyId              
              
		 UNION ALL              
              
		 SELECT 'Loan - Given' 'EntryType', LM.CashBankPartyId 'FromPartyId', PM.Name 'FromPartyName', LM.PartyId 'ToPartyId', PM1.Name 'ToPartyName', '0' 'SlipNo', CAST(Amount as Decimal(18,2))  'Debit', 0 'Credit', CAST(LM.EntryDate as Date) 'Date', Remarks   
		FROM LoanMaster LM              
		 INNER JOIN PartyMaster PM1 ON PM1.Id = LM.PartyId              
		 INNER JOIN PartyMaster PM ON LM.CashBankPartyId = PM.Id              
		 Where LM.IsDelete = 0 AND PM.IsDelete = 0 AND PM1.IsDelete = 0 AND LM.CashBankPartyId = @LedgerId AND  LM.LoanType = 2 AND LM.CompanyId = @CompanyId              
              
		)T order by date asc              
	END
	ELSE
	BEGIN
		-- Only for Direct Expense.
		SELECT 'Purchase Brokerage' 'EntryType', PartyId 'FromPartyId', PM1.Name 'FromPartyName', @LedgerId 'ToPartyId', 'Direct Expense' 'ToPartyName',CAST(PM.SlipNo as varchar(10)) 'SlipNo', 0.00 'Debit', CAST(ISNULL(PM.BrokerAmount, 0) as Decimal(18,2)) 'Credit', CAST(Date as Date) 'Date', Remarks 
		FROM PurchaseMaster PM
		INNER JOIN PartyMaster PM1 ON PM1.Id = PM.PartyId
		WHERE PM.CompanyId = @CompanyId AND PM.FinancialYearId = @FinancialYearId AND PM.IsDelete = 0 AND PM.BrokerAmount > 0
		
		UNION ALL

		SELECT 'Purchase Buyer' 'EntryType', PartyId 'FromPartyId', PM1.Name 'FromPartyName', @LedgerId 'ToPartyId', 'Direct Expense' 'ToPartyName',CAST(PM.SlipNo as varchar(10)) 'SlipNo', 0.00 'Debit', CAST(ISNULL(PM.CommissionAmount, 0) as Decimal(18,2)) 'Credit', CAST(Date as Date) 'Date', Remarks 
		FROM PurchaseMaster PM
		INNER JOIN PartyMaster PM1 ON PM1.Id = PM.PartyId
		WHERE PM.CompanyId = @CompanyId AND PM.FinancialYearId = @FinancialYearId AND PM.IsDelete = 0 AND PM.CommissionAmount > 0
		
		UNION ALL

		SELECT 'Sales Brokerage' 'EntryType', PartyId 'FromPartyId', PM1.Name 'FromPartyName', @LedgerId 'ToPartyId', 'Direct Expense' 'ToPartyName',CAST(SM.SlipNo as varchar(10)) 'SlipNo', 0.00 'Debit', CAST(ISNULL(SM.BrokerAmount, 0) as Decimal(18,2)) 'Credit', CAST(Date as Date) 'Date', Remarks 
		FROM SalesMaster SM
		INNER JOIN PartyMaster PM1 ON PM1.Id = SM.PartyId
		WHERE SM.CompanyId = @CompanyId AND SM.FinancialYearId = @FinancialYearId AND SM.IsDelete = 0 AND SM.BrokerAmount > 0
		
		UNION ALL

		SELECT 'Sales Buyer' 'EntryType', PartyId 'FromPartyId', PM1.Name 'FromPartyName', @LedgerId 'ToPartyId', 'Direct Expense' 'ToPartyName',CAST(SM.SlipNo as varchar(10)) 'SlipNo', 0.00 'Debit', CAST(ISNULL(SM.CommissionAmount, 0) as Decimal(18,2)) 'Credit', CAST(Date as Date) 'Date', Remarks 
		FROM SalesMaster SM
		INNER JOIN PartyMaster PM1 ON PM1.Id = SM.PartyId
		WHERE SM.CompanyId = @CompanyId AND SM.FinancialYearId = @FinancialYearId AND SM.IsDelete = 0 AND SM.CommissionAmount > 0

	END
END