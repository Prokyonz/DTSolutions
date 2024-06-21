CREATE proc [dbo].[GetLedgerBalanceReport] --'00000000-0000-0000-0000-000000000000', '2ac16086-fb8c-4e2c-803b-1748dbe4fd30'  
     
@CompanyId as varchar(50),  
@FinancialYearId as varchar(50)  
  
AS    
BEGIN  
  SELECT PM.Type 'PartyType',  
   CASE    
    WHEN type = 1 THEN 'Sundry Creditors'--'Party-Buy'  
    WHEN type = 14 THEN 'Sundry Debtors'--'Party-Sale'  
    WHEN type=2 THEN 'Employee'  
    WHEN type=3 THEN 'Expense'  
    WHEN type=4 THEN 'Bank'  
    WHEN type=5 THEN 'Cash'  
    WHEN type=6 THEN 'DirectIncome'  
    WHEN type=7 THEN 'InDirectIncome'  
    WHEN type=8 THEN 'Asset'  
    WHEN type=9 THEN 'Deposit'  
    WHEN type=10 THEN 'Loan and Advance'  
    WHEN type=11 THEN 'CapitalAccount'  
    WHEN type=12 THEN 'Investment'  
    WHEN type=13 THEN 'Loan'    
   END AS Type,  
   CASE  
    WHEN SubType=6 THEN 'Buyer'  
    WHEN SubType=7 THEN 'Seller'  
    WHEN SubType=8 THEN 'Broker'  
    WHEN SubType=9 THEN 'Other'
	WHEN SubType=15 THEN 'Process'
	WHEN SubType=16 THEN 'Salaried'
   END AS SubType,   
  
   LBM.Id, PM.Name, LBM.CompanyId, LBM.FinancialYearId, LBM.LedgerId, (CASE WHEN PM.CRDRType = 0 THEN LBM.Balance * -1 ELSE LBM.Balance END) 'OpeningBalance', 
   ISNULL(Purchase.Amount,0) 'PurchaseAmount', ISNULL(Brokerage.Amount, 0) 'Brokerage',  
   ISNULL(Sales.Amount,0) 'SalesAmount', ISNULL(PaymentFrom.Amount,0) 'PaymentFrom', ISNULL(PaymentTo.Amount,0) 'PaymentTo', ISNULL(ReceiptFrom.Amount, 0) 'ReceiptFrom', 
   ISNULL(ReceivedTo.Amount, 0) 'ReceiptTo',      
    
	--SUM of Debit - SUM of Credit
   ((ISNULL(LoansGiven.Amount, 0) + ISNULL(Sales.Amount,0) + ISNULL(PaymentTo.Amount,0) + ISNULL(PaymentFrom.Amount,0) + (CASE WHEN PM.CRDRType = 0 THEN LBM.Balance ELSE 0 END))  
   - ((CASE WHEN PM.CRDRType = 0 THEN 0 ELSE LBM.Balance END) + ISNULL(LoansReceive.Amount, 0) + ISNULL(Purchase.Amount,0) + ISNULL(ReceiptFrom.Amount, 0) + ISNULL(ReceivedTo.Amount, 0) +   
   ISNULL(Salary.Amount, 0) + ISNULL(Brokerage.Amount, 0) + ISNULL(BrokerageSales.Amount, 0) + ISNULL(Buyer.Amount,0) + ISNULL(Saler.Amount, 0))) 'ClosingBalance',

   -- Setup Debit and Credit Columns based on ClosingBalance, ClosingBalance > 0 'Credit' else 'Debit' without minus sign
   (CASE WHEN 

   ((ISNULL(LoansGiven.Amount, 0) + ISNULL(Sales.Amount,0) + ISNULL(PaymentTo.Amount,0) + ISNULL(PaymentFrom.Amount,0) + (CASE WHEN PM.CRDRType = 0 THEN LBM.Balance ELSE 0 END))  
   - ((CASE WHEN PM.CRDRType = 0 THEN 0 ELSE LBM.Balance END) + ISNULL(LoansReceive.Amount, 0) + ISNULL(Purchase.Amount,0) + ISNULL(ReceiptFrom.Amount, 0) + ISNULL(ReceivedTo.Amount, 0) +   
   ISNULL(Salary.Amount, 0) + ISNULL(Brokerage.Amount, 0) + ISNULL(BrokerageSales.Amount, 0) + ISNULL(Buyer.Amount,0) + ISNULL(Saler.Amount, 0))) >= 0

   THEN

   ISNULL(((ISNULL(LoansGiven.Amount, 0) + ISNULL(Sales.Amount,0) + ISNULL(PaymentTo.Amount,0) + ISNULL(PaymentFrom.Amount,0) + (CASE WHEN PM.CRDRType = 0 THEN LBM.Balance ELSE 0 END))  
   - ((CASE WHEN PM.CRDRType = 0 THEN 0 ELSE LBM.Balance END) + ISNULL(LoansReceive.Amount, 0) + ISNULL(Purchase.Amount,0) + ISNULL(ReceiptFrom.Amount, 0) + ISNULL(ReceivedTo.Amount, 0) +   
   ISNULL(Salary.Amount, 0) + ISNULL(Brokerage.Amount, 0) + ISNULL(BrokerageSales.Amount, 0) + ISNULL(Buyer.Amount,0) + ISNULL(Saler.Amount, 0))),0)

   ELSE 

   0.00

   END) 'Credit',

   (CASE WHEN 

   ((ISNULL(LoansGiven.Amount, 0) + ISNULL(Sales.Amount,0) + ISNULL(PaymentTo.Amount,0) + ISNULL(PaymentFrom.Amount,0) + (CASE WHEN PM.CRDRType = 0 THEN LBM.Balance ELSE 0 END))  
   - ((CASE WHEN PM.CRDRType = 0 THEN 0 ELSE LBM.Balance END) + ISNULL(LoansReceive.Amount, 0) + ISNULL(Purchase.Amount,0) + ISNULL(ReceiptFrom.Amount, 0) + ISNULL(ReceivedTo.Amount, 0) +   
   ISNULL(Salary.Amount, 0) + ISNULL(Brokerage.Amount, 0) + ISNULL(BrokerageSales.Amount, 0) + ISNULL(Buyer.Amount,0) + ISNULL(Saler.Amount, 0))) <= 0

   THEN

   ISNULL(((ISNULL(LoansGiven.Amount, 0) + ISNULL(Sales.Amount,0) + ISNULL(PaymentTo.Amount,0) + ISNULL(PaymentFrom.Amount,0) + (CASE WHEN PM.CRDRType = 0 THEN LBM.Balance ELSE 0 END))  
   - ((CASE WHEN PM.CRDRType = 0 THEN 0 ELSE LBM.Balance END) + ISNULL(LoansReceive.Amount, 0) + ISNULL(Purchase.Amount,0) + ISNULL(ReceiptFrom.Amount, 0) + ISNULL(ReceivedTo.Amount, 0) +   
   ISNULL(Salary.Amount, 0) + ISNULL(Brokerage.Amount, 0) + ISNULL(BrokerageSales.Amount, 0) + ISNULL(Buyer.Amount,0) + ISNULL(Saler.Amount, 0))) * -1,0)   

   ELSE 

   0.00

   END) 'Debit'


     
   FROM LedgerBalanceManager LBM --Inner Join PartyMaster PMs ON LBM.LedgerId = PMs.Id  


    LEFT JOIN   
    (  
	 SELECT K.RecType, K.FromPartyId, K.Name, SUM(Amount) 'Amount' FROM (
     SELECT 'Purchase' RecType, PartyId 'FromPartyId', PM.Name, CAST(ISNULL(GrossTotal,0) AS DECIMAL(18,2)) 'Amount' From PurchaseMaster P  
     INNER JOIN PartyMaster PM ON PM.Id = P.PartyId  
     WHERE P.IsDelete=0 AND P.FinancialYearId = @FinancialYearId AND p.CompanyId = @CompanyId  
     --Group by PartyId, PM.Name  

	 UNION ALL

	 SELECT 'Purchase' 'RecType', PM1.Id 'FromPartyId', PM1.Name 'Name', CAST(ISNULL(RJ.Amount,0) AS DECIMAL(18,2)) * -1 'Amount' 
	 FROM RejectionInOutMaster RJ
	 INNER JOIN PurchaseDetails PD ON RJ.PurchaseSaleDetailsId = PD.Id
	 LEFT JOIN PurchaseMaster PM ON PD.PurchaseId = PM.Id
	 INNER JOIN PartyMaster PM1 ON PM1.Id = PM.PartyId
	 WHERE PM1.Type=1 AND RJ.TransType=2 AND RJ.Amount > 0 AND PM1.IsDelete = 0 AND RJ.FinancialYearId = @FinancialYearId AND RJ.CompanyId = @CompanyId		 
	 --GROUP BY PM1.ID, PM1.Name
	 ) K
	 GROUP BY K.Name, K.RecType, K.FromPartyId

    )Purchase ON LBM.LedgerId = Purchase.FromPartyId  
  
    LEFT JOIN  
    (  
     SELECT 'Brokerage' RecType, P.BrokerageId 'FromPartyId', PM.Name, CAST(ISNULL(SUM(BrokerAmount),0) AS DECIMAL(18,2)) 'Amount' FROM PurchaseMaster P  
     INNER JOIN PartyMaster PM ON PM.Id = P.BrokerageId  
     WHERE P.IsDelete=0 AND P.FinancialYearId = @FinancialYearId AND p.CompanyId = @CompanyId  
     GROUP BY P.BrokerageId, PM.Name  
    ) Brokerage ON LBM.LedgerId = Brokerage.FromPartyId 
	
	LEFT JOIN  
    (  
     SELECT 'Brokerage' RecType, S.BrokerageId 'FromPartyId', PM.Name, CAST(ISNULL(SUM(BrokerAmount),0) AS DECIMAL(18,2)) 'Amount' FROM SalesMaster S  
     INNER JOIN PartyMaster PM ON PM.Id = S.BrokerageId  
     WHERE S.IsDelete=0 AND S.FinancialYearId = @FinancialYearId AND S.CompanyId = @CompanyId  
     GROUP BY S.BrokerageId, PM.Name  
    ) BrokerageSales ON LBM.LedgerId = BrokerageSales.FromPartyId 

	LEFT JOIN
	(
		SELECT 'CommissionBuyer' RecType, P.ByuerId 'FromPartyId', PM.Name, CAST(ISNULL(SUM(CommissionAmount),0) AS DECIMAL(18,2)) 'Amount' FROM PurchaseMaster P
		INNER JOIN PartyMaster PM ON PM.Id = P.ByuerId
		WHERE P.IsDelete=0 AND P.FinancialYearId = @FinancialYearId AND p.CompanyId = @CompanyId
		GROUP BY P.ByuerId, PM.Name
	) Buyer ON LBM.LedgerId = Buyer.FromPartyId

	LEFT JOIN
	(
		SELECT 'CommissionSeller' RecType, S.SalerId 'FromPartyId', PM.Name, CAST(ISNULL(SUM(CommissionAmount),0) AS DECIMAL(18,2)) 'Amount' FROM SalesMaster S
		INNER JOIN PartyMaster PM ON PM.Id = S.SalerId
		WHERE S.IsDelete=0 AND S.FinancialYearId = @FinancialYearId AND S.CompanyId = @CompanyId
		GROUP BY S.SalerId, PM.Name
	) Saler ON LBM.LedgerId = Saler.FromPartyId
  
    LEFT JOIN   
    (  
     --Received From  
     SELECT FromPartyId, Name, SUM(Amount) 'Amount' FROM (  
      select MainTable.FromPartyId, Name, amount 'Amount' from (  
       select g.id, g.companyid, g.financialyearid, p.FromPartyId, p.amount from grouppaymentmaster g  
       inner join paymentmaster p on g.id = p.groupid   
       where g.crdrtype=1 AND g.IsDelete=0 AND g.FinancialYearId = @FinancialYearId AND g.CompanyId = @CompanyId  
      )MainTable  
      inner join PartyMaster pm on pm.Id = MainTable.FromPartyId  

	  UNION ALL

		SELECT PartyId 'FromPartyId', Name, CAST(Amount as Decimal(18,2)) 'Amount' FROM ExpenseDetails ED
			INNER JOIN PartyMaster PM ON ED.PartyId = PM.Id
			WHERE ED.IsDelete=0 AND ED.CRDRTYPE=1 AND ED.FinancialYearId = @FinancialYearId AND ED.CompanyId = @CompanyId
       
        )T         
  
     GRoup by  FromPartyId, name  
  
    )ReceiptFrom ON LBM.LedgerId = ReceiptFrom.FromPartyId  
  
    LEFT JOIN  
    (  
     SELECT ToPartyId, Name, SUM(Amount) 'Amount' FROM (  
      select MainTable.ToPartyId, Name, amount from (  
       select g.id, g.companyid, g.financialyearid, g.ToPartyId, p.amount from grouppaymentmaster g  
       inner join paymentmaster p on g.id = p.groupid   
       where g.crdrtype=1 AND g.IsDelete = 0 AND g.FinancialYearId = @FinancialYearId AND g.CompanyId = @CompanyId  
      ) MainTable  
      inner join PartyMaster pm on pm.Id = MainTable.ToPartyId  
  
      UNION ALL  

  	  SELECT FromPartyId 'ToPartyId', Name, CAST(Amount as Decimal(18,2)) 'Amount' FROM ExpenseDetails ED
		INNER JOIN PartyMaster PM ON ED.fromPartyId = PM.Id 
		WHERE ED.IsDelete=0 AND ED.CRDRTYPE=1 AND ED.FinancialYearId = @FinancialYearId AND ED.CompanyId = @CompanyId

		UNION ALL
  
      SELECT CED.FromParty 'ToPartyId', PM.Name, CED.Amount From ContraEntryMaster CEM   
       Inner JOIN ContraEntryDetails CED ON CEM.Id = CED.ContraEntryMasterId  
       INNER JOIN PartyMaster PM ON CED.FromParty = PM.Id  
       WHERE CEM.IsDelete = 0 AND CEM.FinancialYearId = @FinancialYearId AND CEM.CompanyId = @CompanyId  

     )T  
  
     GRoup by  topartyid, name  
    )ReceivedTo ON LBM.LedgerId = ReceivedTo.ToPartyId  
  
    LEFT JOIN   
    (  
     SELECT ToPartyId, Name, SUM(Amount) 'Amount' FROM (  
  
      select MainTable.ToPartyId, name, Amount from (  
       select g.id, g.companyid, g.financialyearid, g.ToPartyId, p.amount from grouppaymentmaster g  
       inner join paymentmaster p on g.id = p.groupid   
       where g.crdrtype=0 AND g.IsDelete=0 AND g.FinancialYearId = @FinancialYearId AND g.CompanyId = @CompanyId  
      ) MainTable  
      inner join PartyMaster pm on pm.Id = MainTable.ToPartyId   
  
      UNION ALL  
  
      SELECT FromPartyId 'ToPartyId', Name, CAST(Amount as Decimal(18,2)) 'Amount' FROM ExpenseDetails ED  
       INNER JOIN PartyMaster PM ON ED.fromPartyId = PM.Id   
       WHERE ED.IsDelete= 0 AND ED.CRDRTYPE=0 AND ED.FinancialYearId = @FinancialYearId AND ED.CompanyId = @CompanyId  
  
      UNION ALL  
  
      SELECT CEM.ToPartyId 'FromPartyId', PM.Name, CED.Amount From ContraEntryMaster CEM   
        Inner JOIN ContraEntryDetails CED ON CEM.Id = CED.ContraEntryMasterId  
        INNER JOIN PartyMaster PM ON CEM.ToPartyId = PM.Id  
        WHERE CEM.IsDelete = 0 AND CEM.FinancialYearId = @FinancialYearId AND CEM.CompanyId = @CompanyId 
	
	UNION ALL

	   SELECT  CashBankPartyId 'FromPartyId', PM.Name,  CAST(Amount as DECIMAL(18,2)) 'Amount' FROM LoanMaster LM  
		 INNER JOIN PartyMaster PM ON PM.Id = LM.CashBankPartyId  
		 WHERE LM.IsDelete = 0 AND LM.LoanType=2 AND LM.CompanyId = @CompanyId
  
     ) T  
     GRoup by  topartyid, name  
  
    )PaymentFrom ON LBM.LedgerId = PaymentFrom.ToPartyId  
  
    LEFT JOIN  
    (  
     SELECT FromPartyId, Name, SUM(Amount) 'Amount' FROM (  
      select MainTable.FromPartyId, Name, amount from (  
       select g.id, g.companyid, g.financialyearid, p.FromPartyId, p.amount from grouppaymentmaster g  
       inner join paymentmaster p on g.id = p.groupid   
       where g.crdrtype=0 AND g.IsDelete = 0 AND g.FinancialYearId = @FinancialYearId AND g.CompanyId = @CompanyId  
      ) MainTable  
      inner join PartyMaster pm on pm.Id = MainTable.FromPartyId  
  
      UNION ALL  
  
      SELECT PartyId 'FromPartyId', Name, CAST(Amount as Decimal(18,2)) 'Amount' FROM ExpenseDetails ED  
       INNER JOIN PartyMaster PM ON ED.PartyId = PM.Id  
       WHERE ED.IsDelete = 0 AND ED.CRDRTYPE=0 AND ED.FinancialYearId = @FinancialYearId AND ED.CompanyId = @CompanyId 
	   
     )T      
        
     GRoup by  FromPartyId, name  
  
    )PaymentTo ON LBM.LedgerId = PaymentTo.FromPartyId  
  
    LEFT JOIN  
    ( 
	 SELECT K.PartyId, K.Name, SUM(Amount) 'Amount' FROM (
		 SELECT PartyId, PM.Name, CAST(ISNULL(GrossTotal,0) AS DECIMAL(18,2)) 'Amount' From SalesMaster S  
		 INNER JOIN PartyMaster PM ON PM.Id = S.PartyId  
		 WHERE S.IsDelete=0 AND S.CompanyId=@CompanyId AND S.FinancialYearId = @FinancialYearId  
		 
		 UNION ALL

		 SELECT PM1.Id 'PartyId', PM1.Name 'Name', CAST(ISNULL(RJ.Amount,0) AS DECIMAL(18,2)) * -1 'Amount'	  
		 FROM RejectionInOutMaster RJ
		 INNER JOIN SalesDetails SD ON RJ.PurchaseSaleDetailsId = SD.Id
		 LEFT JOIN SalesMaster SM ON SD.SalesId = SM.Id
		 INNER JOIN PartyMaster PM1 ON PM1.Id = SM.PartyId
		 WHERE PM1.Type=14 AND RJ.TransType=1 AND RJ.Amount > 0 AND PM1.IsDelete = 0 AND RJ.FinancialYearId = @FinancialYearId AND RJ.CompanyId = @CompanyId		 
	 ) K
	 Group by K.PartyId, K.Name  

    )Sales ON LBM.LedgerId = Sales.PartyId  
  
    LEFT JOIN  
    (  
     SELECT CashBankPartyId 'PartyId', PM.Name,  CAST(ISNULL(SUM(Amount),0) AS DECIMAL(18,2)) 'Amount' FROM LoanMaster LM  
     INNER JOIN PartyMaster PM ON PM.Id = LM.CashBankPartyId  
     WHERE LM.LoanType=1 AND LM.CompanyId = @CompanyId  
     GROUP BY CashBankPartyId, PM.Name  
    ) LoansReceive ON LBM.LedgerId = LoansReceive.PartyId  
  
    LEFT JOIN  
    (  
     SELECT  PartyId, PM.Name,  CAST(ISNULL(SUM(Amount),0) AS DECIMAL(18,2)) 'Amount' FROM LoanMaster LM  
     INNER JOIN PartyMaster PM ON PM.Id = LM.PartyId  
     WHERE LM.LoanType=2 AND LM.CompanyId = @CompanyId  
     GROUP BY PartyId, PM.Name  
    ) LoansGiven ON LBM.LedgerId = LoansGiven.PartyId

    LEFT JOIN   
    (  
     SELECT ToPartyId 'PartyId', PM.Name, CAST(ISNULL(SUM(TotalAmount),0) AS Decimal(18,2)) 'Amount' FROM SalaryDetails SD  
      INNER JOIN PartyMaster PM ON SD.ToPartyId = PM.Id  
      INNER JOIN SalaryMaster SM ON SM.Id = SD.SalaryMasterId  
      WHERE SM.CompanyId=@CompanyId AND SM.FinancialYearId = @FinancialYearId  
      GROUP BY ToPartyId, PM.Name  
    ) Salary ON LBM.LedgerId = Salary.PartyId  
  
   INNER JOIN PartyMaster PM ON PM.Id = LBM.LedgerId  
  
  WHERE PM.IsDelete= 0 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId  
  --AND LBM.Ledgerid='ade77c7e-d340-4312-8080-19ad17ebbcb1'  

  UNION ALL

  SELECT 0 'PartyType', 'Direct Expense' 'Type' , '' 'SubType', CONVERT(VARCHAR(50), NEWID()) 'Id', 'DIRECT EXPENSE' 'Name',  
  @CompanyId 'CompanyName', @FinancialYearId 'FinancialYearId', CONVERT(VARCHAR(50), NEWID()) 'LedgerId', '0' 'OpeningBalance', 
  0 'PurchaseAmount', 125000.00 'Brokerage', 0 'SaleswAmount', 0 'PaymentFrom', 0 'PaymentTo', 0 'ReceiptFrom', 0 'ReceiptTo', 
  CAST(ISNULL(SUM(Amount),0) AS Decimal(18,2)) 'ClosingBalance',
  CASE WHEN CAST(ISNULL(SUM(Amount),0) AS Decimal(18,2)) >= 0 THEN CAST(ISNULL(SUM(Amount),0) AS Decimal(18,2)) ELSE 0.00 END 'Credit',
  CASE WHEN CAST(ISNULL(SUM(Amount),0) AS Decimal(18,2)) < 0 THEN CAST(ISNULL(SUM(Amount),0) AS Decimal(18,2)) ELSE 0.00 END 'Debit'

  FROM (

	SELECT SUM(BrokerAmount) 'Brokerage', SUM(CommissionAmount) 'Commission', SUM(BrokerAmount) + SUM(CommissionAmount) 'Amount', 'Purchase Broker and Commission' 'Type' from PurchaseMaster 
	WHERE IsDelete = 0 AND CompanyId=@CompanyId AND FinancialYearId = @FinancialYearId

	UNION ALL

	SELECT SUM(BrokerAmount) 'Brokerage', SUM(CommissionAmount) 'Commission', SUM(BrokerAmount) + SUM(CommissionAmount) 'Amount', 'Sales Broker and Commission' 'Type' FROM SalesMaster 
	WHERE IsDelete = 0 AND CompanyId=@CompanyId AND FinancialYearId = @FinancialYearId

  )T

  Order By PM.Name ASC 
  
END