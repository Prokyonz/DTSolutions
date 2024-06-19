CREATE PROCEDURE [GetGalaSendReceiveReport] 
	@CompanyId as varchar(50),
	@BranchId as varchar(50),
	@FinancialYearId as varchar(50),
	@GalaProcessType int
AS
BEGIN
	IF @GalaProcessType = 1 --Gala Receive Query Report
	BEGIN

	SELECT GalaProcessType, GalaNo, CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, CONVERT(datetime,EntryDate) 'EntryDate', KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName,GalaNumberId, GalaName, PurityId, PurityName, TotalWeight, SUM(Weight) 'Weight', SUM(LossWeight) 'LossWeight', SUM(RejectionWeight) 'RejectionWeight',
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks	
		FROM (		
		SELECT BPM.GalaNo, BPM.GalaProcessType, BPM.CompanyId, BPM.BranchId, BPM.FinancialYearId,  BPM.JangadNo,
		BPM.SlipNo, BPM.EntryDate, BPM.KapanId, KM.Name 'KapanName', BPM.ShapeId, SM.Name 'ShapeName',
		BPM.CharniSizeId 'SizeId', SM1.Name 'SizeName', BPM.GalaNumberId, GM2.Name 'GalaName', BPM.PurityId, PM2.Name 'PurityName', BPM.Weight 'TotalWeight',
		BPM.GalaWeight 'Weight', LossWeight, RejectionWeight,BPM.HandOverById, PM.Name 'HandOverByName', BPM.HandOverToId, PM1.Name 'HandOverToName', BPM.Remarks

		FROM [GalaProcessMaster] BPM
		INNER JOIN PartyMaster PM on BPM.HandOverById = PM.Id
		INNER JOIN PartyMaster PM1 on BPM.HandOverToId = PM1.Id
		INNER JOIN KapanMaster KM on BPM.KapanId = KM.Id
		INNER JOIN ShapeMaster SM on BPM.ShapeId = SM.Id
		INNER JOIN SizeMaster SM1 on BPM.CharniSizeId = SM1.Id
		INNER JOIN GalaMaster GM2 on BPM.GalaNumberId = GM2.Id
		INNER JOIN PurityMaster PM2 ON BPM.PurityId = PM2.Id) T

	WHERE CompanyId=@CompanyId AND FinancialYearId = @FinancialYearId AND GalaProcessType = @GalaProcessType -- AND BranchId = @BranchId

	Group By GalaNo, GalaProcessType, CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, EntryDate, KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName, TotalWeight, PurityId, PurityName,
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks, GalaNumberId, GalaName

	END
	ELSE 
	BEGIN

	SELECT GalaProcessType, GalaNo, CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, CONVERT(datetime,EntryDate) 'EntryDate', KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName,GalaNumberId, GalaName, PurityId, PurityName, TotalWeight, SUM(Weight) 'Weight', SUM(LossWeight) 'LossWeight', SUM(RejectionWeight) 'RejectionWeight',
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks	
		FROM (		
		SELECT BPM.GalaNo, BPM.GalaProcessType, BPM.CompanyId, BPM.BranchId, BPM.FinancialYearId,  BPM.JangadNo,
		BPM.SlipNo, BPM.EntryDate, BPM.KapanId, KM.Name 'KapanName', BPM.ShapeId, SM.Name 'ShapeName',
		BPM.CharniSizeId 'SizeId', SM1.Name 'SizeName', '' GalaNumberId, '' GalaName, BPM.PurityId, PM2.Name 'PurityName', BPM.Weight 'TotalWeight',
		BPM.GalaWeight 'Weight', LossWeight, RejectionWeight,BPM.HandOverById, PM.Name 'HandOverByName', BPM.HandOverToId, PM1.Name 'HandOverToName', BPM.Remarks

		FROM [GalaProcessMaster] BPM
		INNER JOIN PartyMaster PM on BPM.HandOverById = PM.Id
		INNER JOIN PartyMaster PM1 on BPM.HandOverToId = PM1.Id
		INNER JOIN KapanMaster KM on BPM.KapanId = KM.Id
		INNER JOIN ShapeMaster SM on BPM.ShapeId = SM.Id
		INNER JOIN SizeMaster SM1 on BPM.CharniSizeId = SM1.Id
		INNER JOIN PurityMaster PM2 ON BPM.PurityId = PM2.Id) T

	WHERE CompanyId=@CompanyId AND FinancialYearId = @FinancialYearId AND GalaProcessType = @GalaProcessType --AND BranchId = @BranchId

	Group By GalaNo, GalaProcessType, CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, EntryDate, KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName, TotalWeight, PurityId, PurityName,
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks, GalaNumberId, GalaName

	END


	
	
	
END