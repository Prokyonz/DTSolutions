CREATE PROCEDURE [dbo].[GetBalanceSheet] 
	@CompanyId as varchar(50),
	@FinancialYearId as varchar(50),
	@BalanceSheetType as int = 2
AS
BEGIN

IF @BalanceSheetType = 2
BEGIN
	Declare @tempTable TABLE(PartyType int, Type varchar(100), SubType varchar(100), Id varchar(100), Name varchar(100),CompanyId varchar(100), FinancialYearId varchar(100), LedgerId varchar(100), OpeningBalance decimal(18,2), PurchaseAmount decimal(18,2), Brokerage decimal(18,2), SalesAmount decimal(18,2), PaymentFrom decimal(18,2), PaymentTo decimal(18,2), ReceiptFrom decimal(18,2), ReceiptTo decimal(18,2), ClosingBalance decimal(18,2))
	INSERT @tempTable EXEC [GetLedgerBalanceReport] @CompanyId, @FinancialYearId

	--FIRST SECTION
	select 'Debit' 'ColType', 'Capital Account' 'Type',  CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'Amount' from PartyMaster PM
		Inner join LedgerBalanceManager LBM ON PM.Id = LBM.LedgerId
		where PM.type=11 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL
 	
	-- INCLUDE THE OPENING BALANCE WITH LOAN ENTRY
		--SELECT 'Debit' 'ColType', 'Loan' 'Type',  CAST(ISNULL(
				--(select ISNULL(sum(amount),0) Amont from loanmaster where loantype=1 AND CompanyId = @CompanyId) - 
				--(select ISNULL(sum(amount),0) Amont from loanmaster where loantype=2 AND CompanyId = @CompanyId),0) as decimal(18,4)) Amount 
	
	SELECT T.ColType, T.Type, ISNULL(SUM(T.Amount),0) 'Amount' FROM (
			select 'Debit' 'ColType', 'Loan' 'Type', LBM.Balance 'Amount' from LedgerBalanceManager LBM INNER JOIN PartyMaster PM ON PM.Id = LBM.LedgerId
			where PM.Type = 13 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

			UNION ALL

			SELECT 'Debit' 'ColType', 'Loan' 'Type',  CAST(ISNULL(
				(select ISNULL(sum(amount),0) Amont from loanmaster where loantype=1 AND CompanyId = @CompanyId) - 
				(select ISNULL(sum(amount),0) Amont from loanmaster where loantype=2 AND CompanyId = @CompanyId),0) as decimal(18,4)) Amount 
				)T

			Group by T.ColType, T.Type
	UNION ALL

	SELECT 'Debit' 'ColType', 'Purchase' 'Type',SUM(Amount) 'Amount' FROM
	(
		select CAST(ISNULL(SUM(GrossTotal),0) as decimal(18,4)) 'Amount' from PurchaseMaster PM
		WHERE  IsDelete = 0 AND PM.CompanyId = @CompanyId AND PM.FinancialYearId = @FinancialYearId
	
		UNION ALL

		select ISNULL(SUM(Balance),0) 'Amount' from PartyMaster PM
		INNER JOIN LedgerBalanceManager LBM ON PM.Id = LBM.LedgerId 
		where PM.Type=1 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId
	)Temp

	UNION ALL

	--SECOND SECTION

	select 'Credit' 'ColType', 'Investment' 'Type', CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'Amount' from PartyMaster PM
	INNER JOIN LedgerBalanceManager LBM ON PM.id=LBM.LedgerId
	WHERE Type=12 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL

	select 'Credit' 'ColType', 'Deposit' 'Type', CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'Amount' from PartyMaster PM
	INNER JOIN LedgerBalanceManager LBM ON PM.id=LBM.LedgerId
	WHERE Type=9 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL

	SELECT 'Credit' 'ColType', 'Uchina + Employee' 'Type', SUM(T.UchinaAmount) - SUM(T.EmpAmount) 'Amount'  from (
	select  0 'EmpAmount', CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'UchinaAmount' from PartyMaster PM
		INNER JOIN LedgerBalanceManager LBM ON PM.id=LBM.LedgerId
		WHERE Type=10  AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL

	select CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'EmpAmount', 0 'UchinaAmount' from PartyMaster PM
		INNER JOIN LedgerBalanceManager LBM ON PM.id=LBM.LedgerId
		WHERE  Type=2 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId
	)T

	UNION ALL

	select  'Credit' 'ColType', 'Cash In Hand' 'Type', SUM(ClosingBalance) from @tempTable WHere PartyType=4 OR PartyType=5

	UNION ALL

	select 'Credit' 'ColType', 'Asset' 'Type', CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'Amount' from PartyMaster PM
	INNER JOIN LedgerBalanceManager LBM ON PM.id=LBM.LedgerId
	WHERE Type=8 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL
	
	SELECT 'Credit' 'ColType', 'Sales' 'Type', SUM(Amount) 'Amount' FROM
	(
		select CAST(ISNULL(SUM(GrossTotal),0) as decimal(18,4)) 'Amount' from SalesMaster SM
		WHERE SM.CompanyId = @CompanyId AND SM.FinancialYearId = @FinancialYearId
	
		UNION

		SELECT SUM(Balance) 'Amount' from PartyMaster PM
		INNER JOIN LedgerBalanceManager LBM ON PM.Id = LBM.LedgerId 
		where PM.Type=14 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	)Temp

	UNION ALL
	
	SELECT 'Credit' 'ColType', 'Opening Stock' 'Type', CAST(ISNULL(SUM(Amount),0) as decimal(18,4)) 'Amount' FROM OpeningStockMaster OSM
		WHERE OSM.CompanyId = @CompanyId AND OSM.FinancialYearId = @FinancialYearId AND OSM.TransferType is NULL
END
ELSE
BEGIN
	select 'Debit' 'ColType', 'Capital Account' 'Type',  CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'Amount' from PartyMaster PM
		Inner join LedgerBalanceManager LBM ON PM.Id = LBM.LedgerId
		where PM.type=11 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL

		select 'Debit' 'ColType', 'Loan' 'Type', ISNULL(SUM(LBM.Balance),0) 'Amount' from LedgerBalanceManager LBM INNER JOIN PartyMaster PM ON PM.Id = LBM.LedgerId
		where LBM.Balance > 0 AND PM.Type = 13 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId
		--GROUP BY 'ColType', 'Type'

	UNION ALL

	SELECT 'Debit' 'ColType', 'Purchase' 'Type',SUM(Balance) 'Amount' from PartyMaster PM
		INNER JOIN LedgerBalanceManager LBM ON PM.Id = LBM.LedgerId 
		where PM.Type=1 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL

	--SECOND SECTION

	select 'Credit' 'ColType', 'Investment' 'Type', CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'Amount' from PartyMaster PM
	INNER JOIN LedgerBalanceManager LBM ON PM.id=LBM.LedgerId
	WHERE Type=12 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL

	select 'Credit' 'ColType', 'Deposit' 'Type', CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'Amount' from PartyMaster PM
	INNER JOIN LedgerBalanceManager LBM ON PM.id=LBM.LedgerId
	WHERE Type=9 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL

	
	SELECT 'Credit' 'ColType', 'Uchina + Employee' 'Type', SUM(T.UchinaAmount) - SUM(T.EmpAmount) 'Amount'  from (
	select  0 'EmpAmount', CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'UchinaAmount' from PartyMaster PM
		INNER JOIN LedgerBalanceManager LBM ON PM.id=LBM.LedgerId
		WHERE Type=10  AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL

	select CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'EmpAmount', 0 'UchinaAmount' from PartyMaster PM
		INNER JOIN LedgerBalanceManager LBM ON PM.id=LBM.LedgerId
		WHERE  Type=2 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId
	)T

	UNION ALL

	select 'Credit' 'ColType', 'Cash In Hand' 'Type', CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'Amount' from PartyMaster PM
	INNER JOIN LedgerBalanceManager LBM ON PM.id=LBM.LedgerId
	WHERE Type = 5 OR Type = 4 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL

	select 'Credit' 'ColType', 'Asset' 'Type', CAST(ISNULL(SUM(LBM.Balance),0) as decimal(18,4)) 'Amount' from PartyMaster PM
	INNER JOIN LedgerBalanceManager LBM ON PM.id=LBM.LedgerId
	WHERE Type=8 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL
	
	SELECT 'Credit' 'ColType', 'Sales' 'Type', CAST(ISNULL(SUM(Balance),0) as decimal(18,4)) 'Amount' from PartyMaster PM
		INNER JOIN LedgerBalanceManager LBM ON PM.Id = LBM.LedgerId 
		where PM.Type=14 AND LBM.CompanyId = @CompanyId AND LBM.FinancialYearId = @FinancialYearId

	UNION ALL
	
	SELECT 'Credit' 'ColType', 'Opening Stock' 'Type', CAST(ISNULL(SUM(Amount),0) as decimal(18,4)) 'Amount' FROM OpeningStockMaster OSM
		WHERE OSM.CompanyId = @CompanyId AND OSM.FinancialYearId = @FinancialYearId AND OSM.TransferType is NULL

END
END