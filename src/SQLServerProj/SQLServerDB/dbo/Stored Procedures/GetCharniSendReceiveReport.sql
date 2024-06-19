CREATE PROCEDURE [GetCharniSendReceiveReport] 
	@CompanyId as varchar(50),
	@BranchId as varchar(50),
	@FinancialYearId as varchar(50),
	@CharniType int
AS
BEGIN
	IF @CharniType = 1 -- Charni send
	BEGIN

	SELECT CharniType, CharniNo, CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, CONVERT(datetime,EntryDate) 'EntryDate', KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName, PurityId, PurityName, SUM(Weight) 'Weight', SUM(LossWeight) 'LossWeight', SUM(RejectionWeight) 'RejectionWeight', TotalWeight,
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks

	FROM (SELECT BPM.CharniNo, BPM.CharniType, BPM.CompanyId, BPM.BranchId, BPM.FinancialYearId,  BPM.JangadNo, BPM.SlipNo, BPM.EntryDate, BPM.KapanId, KM.Name 'KapanName', BPM.ShapeId, SM.Name 'ShapeName', 
		BPM.CharniSizeId 'SizeId', SM1.Name 'SizeName', BPM.PurityId, PM2.Name 'PurityName', BPM.Weight 'TotalWeight', CharniWeight 'Weight', BPM.LossWeight,BPM.RejectionWeight, BPM.HandOverById, PM.Name 'HandOverByName', BPM.HandOverToId, PM1.Name 'HandOverToName', BPM.Remarks 
		FROM [CharniProcessMaster] BPM
		INNER JOIN PartyMaster PM on BPM.HandOverById = PM.Id
		INNER JOIN PartyMaster PM1 on BPM.HandOverToId = PM1.Id
		INNER JOIN KapanMaster KM on BPM.KapanId = KM.Id
		INNER JOIN ShapeMaster SM on BPM.ShapeId = SM.Id
		INNER JOIN SizeMaster SM1 on BPM.CharniSizeId = SM1.Id
		INNER JOIN PurityMaster PM2 ON BPM.PurityId = PM2.Id) T

	WHERE CompanyId=@CompanyId AND FinancialYearId = @FinancialYearId AND CharniType = @CharniType --AND BranchId = @BranchId
	

	GROUP BY CharniNo, CharniType,  CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, EntryDate, KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName, PurityId, PurityName, TotalWeight,
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks
	
	END
	ELSE
	BEGIN

	SELECT CharniType, CharniNo, CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, CONVERT(datetime,EntryDate) 'EntryDate', KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName, PurityId, PurityName, SUM(Weight) 'Weight', SUM(LossWeight) 'LossWeight', SUM(RejectionWeight) 'RejectionWeight', TotalWeight,
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks

	FROM (SELECT BPM.CharniNo, BPM.CharniType, BPM.CompanyId, BPM.BranchId, BPM.FinancialYearId,  BPM.JangadNo, BPM.SlipNo, BPM.EntryDate, BPM.KapanId, KM.Name 'KapanName', BPM.ShapeId, SM.Name 'ShapeName', 
		BPM.SizeId 'SizeId', SM1.Name 'SizeName', BPM.PurityId, PM2.Name 'PurityName', BPM.Weight 'TotalWeight', CharniWeight 'Weight', BPM.LossWeight,BPM.RejectionWeight, BPM.HandOverById, PM.Name 'HandOverByName', BPM.HandOverToId, PM1.Name 'HandOverToName', BPM.Remarks 
		FROM [CharniProcessMaster] BPM
		INNER JOIN PartyMaster PM on BPM.HandOverById = PM.Id
		INNER JOIN PartyMaster PM1 on BPM.HandOverToId = PM1.Id
		INNER JOIN KapanMaster KM on BPM.KapanId = KM.Id
		INNER JOIN ShapeMaster SM on BPM.ShapeId = SM.Id
		INNER JOIN SizeMaster SM1 on BPM.SizeId = SM1.Id
		INNER JOIN PurityMaster PM2 ON BPM.PurityId = PM2.Id) T

	WHERE CompanyId=@CompanyId AND FinancialYearId = @FinancialYearId AND CharniType = @CharniType -- AND BranchId = @BranchId
	

	GROUP BY CharniNo, CharniType,  CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, EntryDate, KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName, PurityId, PurityName, TotalWeight,
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks

	END
END