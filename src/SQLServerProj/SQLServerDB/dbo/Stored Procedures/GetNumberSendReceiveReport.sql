CREATE PROCEDURE [GetNumberSendReceiveReport] 
	@CompanyId as varchar(50),
	@BranchId as varchar(50),
	@FinancialYearId as varchar(50),
	@NumberProcessType int
AS
BEGIN
	IF @NumberProcessType = 1 -- Receive Number
	BEGIN

	SELECT NumberProcessType, NumberNo, CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, CONVERT(datetime,EntryDate) 'EntryDate', KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName, GalaNumberId, GalaName, NumberId, NumberName, PurityId, PurityName, TotalWeight, SUM(Weight) 'Weight', SUM(LossWeight) 'LossWeight', SUM(RejectionWeight) 'RejectionWeight',
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks	

		FROM (SELECT BPM.NumberProcessType, BPM.NumberNo, BPM.CompanyId, BPM.BranchId, BPM.FinancialYearId,  BPM.JangadNo, BPM.SlipNo, BPM.EntryDate, BPM.KapanId, KM.Name 'KapanName', BPM.ShapeId, SM.Name 'ShapeName', 
		BPM.CharniSizeId 'SizeId', SM1.Name 'SizeName', BPM.GalaNumberId, GM.Name 'GalaName', BPM.NumberId, NM.Name 'NumberName', BPM.PurityId, PM2.Name 'PurityName', BPM.Weight 'TotalWeight',
		BPM.NumberWeight 'Weight', BPM.LossWeight, BPM.RejectionWeight,
		BPM.HandOverById, PM.Name 'HandOverByName', BPM.HandOverToId, PM1.Name 'HandOverToName', BPM.Remarks 
		FROM [NumberProcessMaster] BPM
		INNER JOIN PartyMaster PM on BPM.HandOverById = PM.Id
		INNER JOIN PartyMaster PM1 on BPM.HandOverToId = PM1.Id
		INNER JOIN KapanMaster KM on BPM.KapanId = KM.Id
		INNER JOIN ShapeMaster SM on BPM.ShapeId = SM.Id
		INNER JOIN SizeMaster SM1 on BPM.CharniSizeId = SM1.Id
		INNER JOIN GalaMaster GM on BPM.GalaNumberId = GM.Id
		INNER JOIN NumberMaster NM on BPM.NumberId = NM.Id
		INNER JOIN PurityMaster PM2 ON BPM.PurityId = PM2.Id) T
	
	WHERE CompanyId=@CompanyId AND FinancialYearId = @FinancialYearId AND NumberProcessType = @NumberProcessType --AND BranchId = @BranchId
	
	Group By NumberNo, NumberProcessType, CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, EntryDate, KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName, TotalWeight, PurityId, PurityName,
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks, GalaNumberId, GalaName, NumberId, NumberName
 
	END
	ELSE
	BEGIN

	SELECT NumberProcessType, NumberNo, CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, CONVERT(datetime,EntryDate) 'EntryDate', KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName, GalaNumberId, GalaName, NumberId, NumberName, PurityId, PurityName, TotalWeight, SUM(Weight) 'Weight', SUM(LossWeight) 'LossWeight', SUM(RejectionWeight) 'RejectionWeight',
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks	

		FROM (SELECT BPM.NumberProcessType, BPM.NumberNo, BPM.CompanyId, BPM.BranchId, BPM.FinancialYearId,  BPM.JangadNo, BPM.SlipNo, BPM.EntryDate, BPM.KapanId, KM.Name 'KapanName', BPM.ShapeId, SM.Name 'ShapeName', 
		BPM.CharniSizeId 'SizeId', SM1.Name 'SizeName', '' GalaNumberId, '' GalaName, '' NumberId, '' NumberName, BPM.PurityId, PM2.Name 'PurityName', BPM.Weight 'TotalWeight',
		BPM.NumberWeight 'Weight', BPM.LossWeight, BPM.RejectionWeight,
		BPM.HandOverById, PM.Name 'HandOverByName', BPM.HandOverToId, PM1.Name 'HandOverToName', BPM.Remarks 
		FROM [NumberProcessMaster] BPM
		INNER JOIN PartyMaster PM on BPM.HandOverById = PM.Id
		INNER JOIN PartyMaster PM1 on BPM.HandOverToId = PM1.Id
		INNER JOIN KapanMaster KM on BPM.KapanId = KM.Id
		INNER JOIN ShapeMaster SM on BPM.ShapeId = SM.Id
		INNER JOIN SizeMaster SM1 on BPM.CharniSizeId = SM1.Id
		INNER JOIN PurityMaster PM2 ON BPM.PurityId = PM2.Id) T
	
	WHERE CompanyId=@CompanyId AND FinancialYearId = @FinancialYearId AND NumberProcessType = @NumberProcessType --AND BranchId = @BranchId
	
	Group By NumberNo, NumberProcessType, CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, EntryDate, KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName, TotalWeight, PurityId, PurityName,
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks, GalaNumberId, GalaName, NumberId, NumberName

	END

	
END