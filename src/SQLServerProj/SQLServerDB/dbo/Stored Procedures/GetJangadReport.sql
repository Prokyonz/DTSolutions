CREATE PROCEDURE [GetJangadReport] 
	@CompanyId as varchar(50),
	@FinancialYearId as varchar(50),
	@JangadType as int
AS
BEGIN
	SELECT JM.Id, JM.FinancialYearId, JM.Sr,JM.SrNo, JM.PartyId, PM.Name 'PartyName', JM.BrokerId, PM1.Name 'BrokerName', JM.SizeId, SM.Name 'SizeName', JM.Totalcts, JM.Rate, JM.Amount, JM.Remarks, JM.UpdatedDate 
	FROM JangadMaster JM INNER JOIN PartyMaster PM ON JM.PartyId = PM.Id
	INNER JOIN PartyMaster PM1 ON JM.BrokerId = PM1.Id
	INNER JOIN SizeMaster SM ON JM.SizeId = SM.Id
	WHERE JM.FinancialYearId = @FinancialYearId AND JM.CompanyId = @CompanyId AND JM.EntryType = @JangadType  
END