CREATE PROCEDURE [GetAssortReceiveReport] 
	@CompanyId as varchar(50),
	@BranchId as varchar(50),
	@FinancialYearId as varchar(50)
AS
BEGIN

	SELECT * FROM (
		SELECT 'Boil' 'Dept', BPM.CompanyId, BPM.BranchId, BPM.FinancialYearId,  BPM.Id, BPM.Sr, BPM.JangadNo, BPM.SlipNo, BPM.EntryDate, BPM.KapanId, KM.Name 'KapanName', BPM.ShapeId, SM.Name 'ShapeName', 
		BPM.SizeId, SM1.Name 'SizeName', '' NumberId, '' NumberName, BPM.PurityId, PM2.Name 'PurityName', BPM.Weight, BPM.HandOverById, PM.Name 'HandOverByName', BPM.HandOverToId, PM1.Name 'HandOverToName', BPM.Remarks, BPM.CreatedBy, BPM.CreatedDate, BPM.UpdatedBy, BPM.UpdatedDate 
		FROM [BoilProcessMaster] BPM
		INNER JOIN PartyMaster PM on BPM.HandOverById = PM.Id
		INNER JOIN PartyMaster PM1 on BPM.HandOverToId = PM1.Id
		INNER JOIN KapanMaster KM on BPM.KapanId = KM.Id
		INNER JOIN ShapeMaster SM on BPM.ShapeId = SM.Id
		INNER JOIN SizeMaster SM1 on BPM.SizeId = SM1.Id
		INNER JOIN PurityMaster PM2 ON BPM.PurityId = PM2.Id
		
		Where BoilType=2
	UNION
		SELECT 'Charni' 'Dept', CPM.CompanyId, CPM.BranchId, CPM.FinancialYearId, CPM.Id, CPM.Sr, CPM.JangadNo, CPM.SlipNo, CPM.EntryDate, CPM.KapanId, KM.Name 'KapanName',  CPM.ShapeId, SM.Name 'ShapeName', 
		CPM.CharniSizeId 'SizeId', SM1.Name 'SizeName', '' NumberId, '' NumberName, CPM.PurityId, PM2.Name 'PurityName', CPM.CharniWeight 'Weight', CPM.HandOverById, PM.Name 'HandOverByName',  CPM.HandOverToId, PM1.Name 'HandOverToName',  CPM.Remarks, CPM.CreatedBy, CPM.CreatedDate, CPM.UpdatedBy, CPM.UpdatedDate 
		FROM [CharniProcessMaster] CPM
		INNER JOIN PartyMaster PM on CPM.HandOverById = PM.Id
		INNER JOIN PartyMaster PM1 on CPM.HandOverToId = PM1.Id
		INNER JOIN KapanMaster KM on CPM.KapanId = KM.Id
		INNER JOIN ShapeMaster SM on CPM.ShapeId = SM.Id
		INNER JOIN SizeMaster SM1 on CPM.SizeId = SM1.Id
		INNER JOIN PurityMaster PM2 ON CPM.PurityId = PM2.Id

		Where charniType =2
	UNION
		SELECT 'Gala' 'Dept', GPM.CompanyId, GPM.BranchId, GPM.FinancialYearId, GPM.Id, GPM.Sr, GPM.JangadNo, GPM.SlipNo, CONVERT(datetime,GPM.EntryDate), GPM.KapanId, KM.Name 'KapanName', GPM.ShapeId, SM.Name 'ShapeName', 
		GPM.CharniSizeId 'SizeId', SM1.Name 'SizeName', '' NumberId, '' NumberName, GPM.PurityId, PM2.Name 'PurityName', GPM.GalaWeight 'Weight', GPM.HandOverById, PM.Name 'HandOverByName', GPM.HandOverToId, PM1.Name 'HandOverToName', GPM.Remarks, GPM.CreatedBy, GPM.CreatedDate, GPM.UpdatedBy, GPM.UpdatedDate 
		FROM [GalaProcessMaster] GPM
		INNER JOIN PartyMaster PM on GPM.HandOverById = PM.Id
		INNER JOIN PartyMaster PM1 on GPM.HandOverToId = PM1.Id
		INNER JOIN KapanMaster KM on GPM.KapanId = KM.Id
		INNER JOIN ShapeMaster SM on GPM.ShapeId = SM.Id
		INNER JOIN SizeMaster SM1 on GPM.CharniSizeId = SM1.Id
		INNER JOIN PurityMaster PM2 ON GPM.PurityId = PM2.Id
		
		Where GalaProcessType=2
	UNION
		SELECT 'Number' 'Dept', NPM.CompanyId, NPM.BranchId, NPM.FinancialYearId, NPM.Id, NPM.Sr, NPM.JangadNo, NPM.SlipNo, CONVERT(datetime,NPM.EntryDate), NPM.KapanId, KM.Name 'KapanName', NPM.ShapeId, SM.Name 'ShapeName', 
		NPM.CharniSizeId 'SizeId', SM1.Name 'SizeName', NPM.NumberId, NM.Name 'NumberName',  NPM.PurityId, PM2.Name 'PurityName', NPM.NumberWeight 'Weight', NPM.HandOverById, PM.Name 'HandOverByName', NPM.HandOverToId, PM1.Name 'HandOverToName', NPM.Remarks, NPM.CreatedBy, NPM.CreatedDate, NPM.UpdatedBy, NPM.UpdatedDate 
		FROM NumberProcessMaster NPM
		INNER JOIN PartyMaster PM on NPM.HandOverById = PM.Id
		INNER JOIN PartyMaster PM1 on NPM.HandOverToId = PM1.Id
		INNER JOIN KapanMaster KM on NPM.KapanId = KM.Id
		INNER JOIN ShapeMaster SM on NPM.ShapeId = SM.Id
		INNER JOIN SizeMaster SM1 on NPM.CharniSizeId = SM1.Id
		INNER JOIN NumberMaster NM ON NPM.NumberId = NM.Id
		INNER JOIN PurityMaster PM2 ON NPM.PurityId = PM2.Id
		
		Where NumberProcessType=2) as MainTable
	
	WHERE MainTable.CompanyId=@CompanyId AND MainTable.FinancialYearId = @FinancialYearId -- AND MainTable.BranchId = @BranchId

END