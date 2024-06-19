
CREATE proc [GetCashBankReport]

@CompanyId as varchar(50),        
@FinancialYearId as varchar(50),
@FromDate as date = '',
@ToDate as date = ''   

as
begin

	select CAST(GPM.EntryDate as Date) 'EntryDate', PAM.Id + GPM.Id AS Id,
		CASE  
			WHEN GPM.CrDrType = 0 THEN 'Payment'
			WHEN GPM.CrDrType = 1 THEN 'Receipt'
		END AS Type,
	PAM1.Name 'ToParty', PAM.Name 'FromParty', 		
	CASE 
		WHEN GPM.CrDrType = 0 THEN Amount
		WHEN GPM.CrDrType = 1 THEN 0
	END AS 'Debit', 
	CASE 
		WHEN GPM.CrDrType = 0 THEN 0
		WHEN GPM.CrDrType = 1 THEN Amount
	END AS 'Credit', 	
	GPM.CrDrType, GPM.Remarks from GroupPaymentMaster GPM
	INNER JOIN PaymentMaster PM ON PM.GroupId = GPM.Id
	INNER JOIN PartyMaster PAM ON GPM.ToPartyId = PAM.Id
	INNER JOIN PartyMaster PAM1 ON PM.FromPartyId = PAM1.Id 
	
	Where GPM.IsDelete= 0 AND (PAM.Type = 4 OR PAM.Type = 5) 
	AND (CAST(GPM.EntryDate as Date) >= @FromDate AND CAST(GPM.EntryDate as Date) <= @ToDate) 
	AND GPM.CompanyId = @CompanyId AND GPM.FinancialYearId = @FinancialYearId

	UNION

	select CAST(CEM.EntryDate as Date) 'EntryDate', CEM.Id + CED.Id as Id, 'Contra' as Type, PM.Name 'ToParty', PM1.Name 'FromParty', Amount 'Debit', Amount 'Credit',0 'CrDrType', CEM.Remarks  from ContraEntryMaster CEM
	INNER JOIN contraentrydetails CED ON CEM.Id = CED.ContraEntryMasterId
	INNER JOIN [PartyMaster] AS PM ON PM.Id = CEM.ToPartyId
	
	INNER JOIN [PartyMaster] as PM1 ON PM1.Id = CED.FromParty
	WHERE CEM.IsDelete= 0
	AND (CAST(CEM.EntryDate as Date) >= @FromDate AND CAST(CEM.EntryDate as Date) <= @ToDate) AND
	CEM.CompanyId = @CompanyId AND CEM.FinancialYearId = @FinancialYearId

	UNION

	SELECT CAST(ED.EntryDate as Date) 'EntryDate', ED.Id, 'Expense' as Type, PM.Name 'ToParty', PM1.Name 'FromParty', 
    CAST(ED.Amount as DECIMAL(18,2)) 'Debit', 0 'Credit', 0 'CrDrType', ED.Remarks  from ExpenseDetails ED 
	
	INNER JOIN PartyMaster PM on ED.PartyId = PM.Id
	INNER JOIN PartyMaster PM1 on ED.fromPartyId = PM1.Id 
	WHERE ED.IsDelete=0
	AND (CAST(ED.EntryDate as Date) >= @FromDate AND CAST(ED.EntryDate as Date) <= @ToDate) AND
	ED.CompanyId = @CompanyId AND ED.FinancialYearId = @FinancialYearId

END