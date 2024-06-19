CREATE PROCEDURE [dbo].[GetExpenseReport] 
	@CompanyId as varchar(50),
	@FinancialYearId as varchar(50),
	@FromDate as date = '',
	@ToDate as date = ''
AS
BEGIN
	SELECT Ed.CrDrType, CAST(ED.EntryDate as date) 'EntryDate', Ed.Id, Ed.Sr, SrNo, ED.CompanyId, BranchId, BM.Name as BranchName, PartyId, PM.Name as ToPartyName,  
	Amount, Remarks, PA.Name as FromPartyName, ED.UpdatedDate, ED.UpdatedBy
	FROM [ExpenseDetails] ED
	INNER JOIN PartyMaster PM ON PM.Id = ED.PartyId
	INNER JOIN PartyMaster PA ON PA.Id = ED.fromPartyId 
	INNER JOIN BranchMaster BM ON BM.Id = ED.BranchId 
	WHERE 
	(CAST(EntryDate as Date) >= @FromDate AND CAST(EntryDate as Date) <= @ToDate) AND
	ED.CompanyId = @CompanyId AND ED.FinancialYearId = @FinancialYearId
	Order By SrNo
END