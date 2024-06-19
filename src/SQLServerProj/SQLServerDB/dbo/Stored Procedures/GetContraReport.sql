CREATE PROCEDURE [GetContraReport] 
	@CompanyId as varchar(50),        
	@FinancialYearId as varchar(50),
	@FromDate as date = '',
	@ToDate as date = ''   
AS
BEGIN
	SELECT M.*, PM1.Name as ToPartyName FROM (
	
	SELECT CEM.Sr,CEM.SrNo, CAST(CEM.EntryDate as date) 'EntryDate', CEM.Id AS ContraId, CEM.CompanyId, CEM.FinancialYearId, CED.Id, CED.FromParty AS FromPartyId, 
	CEM.ToPartyId, PM.Name AS FromPartyName, CED.Amount, CEM.Remarks, CEM.UpdatedDate, CEM.UpdatedBy 
	from [ContraEntryDetails] AS CED
	left JOIN [ContraEntryMaster] AS CEM ON CEM.Id = CED.ContraEntryMasterId
	left JOIN [PartyMaster] AS PM ON PM.Id = CEM.ToPartyId) as M
	
	left JOIN [PartyMaster] as PM1 ON PM1.Id = M.FromPartyId

	WHERE 
	--(CAST(EntryDate as Date) >= @FromDate AND CAST(EntryDate as Date) <= @ToDate) AND
	M.CompanyId = @CompanyId and M.FinancialYearId = @FinancialYearId

	Order by M.SrNo Desc
END