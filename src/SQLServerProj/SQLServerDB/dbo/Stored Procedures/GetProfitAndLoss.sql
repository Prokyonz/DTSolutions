CREATE PROCEDURE [dbo].[GetProfitAndLoss] 
	@CompanyId as varchar(50),
	@FinancialYearId as varchar(50),
	@ProfitLossType as int = 2
AS
BEGIN

IF @ProfitLossType = 2
BEGIN
	SELECT 'Debit' 'ColType', 'Purchase' 'Type', ISNULL(SUM(LBM.Balance),0) 'OpeningBalance', CAST(ISNULL(SUM(GrossTotal),0) as decimal(18,4)) 'Amount', (ISNULL(SUM(LBM.Balance),0) + CAST(ISNULL(SUM(GrossTotal),0) as decimal(18,4))) 'TotalPurchase' 
	from PurchaseMaster PM
	INNER JOIN LedgerBalanceManager LBM ON LBM.LedgerId = PM.PartyId
	WHERE PM.IsDelete=0 AND LBM.FinancialYearId = @FinancialYearId AND LBM.CompanyId = @CompanyId

	UNION

	SELECT 'Debit' 'ColType', 'Expense' 'Type', ISNULL(SUM(LBM.Balance), 0) 'OpeningBalance', CAST(ISNULL(SUM(Amount),0) as decimal(18,4)) 'Amount', (ISNULL(SUM(LBM.Balance), 0) + CAST(ISNULL(SUM(Amount),0) as decimal(18,4))) 'TotalExpense' FROM ExpenseDetails ED
	INNER JOIN LedgerBalanceManager LBM ON LBM.LedgerId = ED.PartyId
	WHERE ED.FinancialYearId = @FinancialYearId AND ED.CompanyId = @CompanyId

	UNION

	SELECT 'Credit' 'ColType', 'Sales' 'Type', ISNULL(SUM(LBM.Balance),0) 'OpeningBalance', CAST(ISNULL(SUM(GrossTotal),0) as decimal(18,4)) 'Amount', (ISNULL(SUM(LBM.Balance),0) + CAST(ISNULL(SUM(GrossTotal),0) as decimal(18,4))) 'TotalSales' from SalesMaster SM
	INNER JOIN LedgerBalanceManager LBM ON LBM.LedgerId = SM.PartyId
	WHERE SM.FinancialYearId = @FinancialYearId AND SM.CompanyId = @CompanyId
END
ELSE
BEGIN
	SELECT 'Debit' 'ColType', 'Purchase' 'Type', ISNULL(SUM(LBM.Balance),0) 'OpeningBalance', 0.0 'TotalPurchase', (ISNULL(SUM(LBM.Balance),0)) 'Amount' 
	FROM PartyMaster PM 
	INNER JOIN LedgerBalanceManager LBM ON PM.Id = LBM.LedgerId 
	WHERE PM.Type=1 AND LBM.FinancialYearId = @FinancialYearId AND LBM.CompanyId = @CompanyId


	UNION

	SELECT 'Debit' 'ColType', 'Expense' 'Type', ISNULL(SUM(LBM.Balance), 0) 'OpeningBalance', 0.0 'TotalExpense', (ISNULL(SUM(LBM.Balance), 0)) 'Amount' 
	FROM PartyMaster PM
	INNER JOIN LedgerBalanceManager LBM ON LBM.LedgerId = PM.Id 
	Where PM.Type=3 AND LBM.FinancialYearId = @FinancialYearId AND LBM.CompanyId = @CompanyId

	UNION

	SELECT 'Credit' 'ColType', 'Sales' 'Type', ISNULL(SUM(LBM.Balance),0) 'OpeningBalance', 0.0 'TotalSales', (ISNULL(SUM(LBM.Balance),0)) 'Amount' 
	FROM PartyMaster PM
	INNER JOIN LedgerBalanceManager LBM ON LBM.LedgerId = PM.Id 
	WHERE PM.Type=14 AND LBM.FinancialYearId = @FinancialYearId AND LBM.CompanyId = @CompanyId
END
	
END