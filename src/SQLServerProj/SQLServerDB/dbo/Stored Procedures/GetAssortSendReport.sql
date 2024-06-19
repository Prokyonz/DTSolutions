CREATE PROCEDURE [GetAssortSendReport] 
	@CompanyId as varchar(50),
	@BranchId as varchar(50),
	@FinancialYearId as varchar(50),
	@AccountToAssortType int
AS
BEGIN
	Select 
		CASE 
			WHEN AAM.Department = 1 THEN 'Boil'
			WHEN AAM.Department = 2 THEN 'Charni'
			WHEN AAM.Department = 3 THEN 'Gala'
			WHEN AAM.Department = 4 THEN 'Number'
		END 'Department', AAM.Id, AAD.Id 'ChildId', AAM.Sr, AAM.CompanyId, AAM.BranchId, AAM.FinancialYearId, CONVERT(datetime,AAM.EntryDate) 'EntryDate', AAM.FromParyId 'FromPartyId', PM.Name 'FromPartyName', AAM.ToPartyId, PM1.Name 'ToPartyName', AAM.KapanId, KM.Name 'KapanName', AAM.AccountToAssortType, AAM.Remarks, AAM.CreatedBy, AAM.CreatedDate, AAM.UpdatedBy, AAM.UpdatedDate,
	AAD.SlipNo, AAD.SizeId, SM.Name 'SizeName', AAD.Weight, AAD.AssignWeight
	from AccountToAssortMaster AAM 
	INNER JOIN AccountToAssortDetails AAD ON AAM.Id = AAD.AccountToAssortMasterId
	INNER JOIN PartyMaster PM ON AAM.FromParyId = PM.Id
	INNER JOIN PartyMaster PM1 ON AAM.ToPartyId = PM1.Id
	INNER JOIN KapanMaster KM ON AAM.KapanId = KM.Id
	LEFT JOIN SizeMaster SM ON AAD.SizeId = SM.Id
	WHERE AAM.CompanyId = @CompanyId AND AAM.FinancialYearId = @FinancialYearId AND AAM.AccountToAssortType = @AccountToAssortType --AND AAM.BranchId = @BranchId
END