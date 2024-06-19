CREATE PROCEDURE [dbo].[GetBoilSendReceiveReport] 
	@CompanyId as varchar(50),
	@BranchId as varchar(50),
	@FinancialYearId as varchar(50),
	@BoilType int
AS
BEGIN
	Select Id 'BoilSendId', BoilType, BoilNo, CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, CONVERT(datetime,EntryDate) 'EntryDate', KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName, PurityId, PurityName, SUM(Weight) 'Weight', SUM(LossWeight) 'LossWeight', SUM(RejectionWeight) 'RejectionWeight', SUM(Weight) + SUM(LossWeight) + SUM(RejectionWeight) as TotalWeight,
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks
	
		FROM (SELECT BPM.BoilType, BPM.BoilNo, BPM.Id, BPM.Sr,  BPM.CompanyId, BPM.BranchId, BPM.FinancialYearId,  BPM.JangadNo, BPM.SlipNo, BPM.EntryDate, BPM.KapanId, KM.Name 'KapanName', BPM.ShapeId, SM.Name 'ShapeName', 
		BPM.SizeId, SM1.Name 'SizeName', BPM.PurityId, PM2.Name 'PurityName', BPM.Weight, BPM.LossWeight, BPM.RejectionWeight, BPM.HandOverById, PM.Name 'HandOverByName', BPM.HandOverToId, PM1.Name 'HandOverToName', BPM.Remarks, BPM.CreatedBy, BPM.CreatedDate, BPM.UpdatedBy, BPM.UpdatedDate 
		FROM [BoilProcessMaster] BPM
		INNER JOIN PartyMaster PM on BPM.HandOverById = PM.Id
		INNER JOIN PartyMaster PM1 on BPM.HandOverToId = PM1.Id
		INNER JOIN KapanMaster KM on BPM.KapanId = KM.Id
		LEFT JOIN ShapeMaster SM on BPM.ShapeId = SM.Id
		LEFT JOIN SizeMaster SM1 on BPM.SizeId = SM1.Id
		LEFT JOIN PurityMaster PM2 ON BPM.PurityId = PM2.Id) T

	WHERE CompanyId=@CompanyId AND FinancialYearId = @FinancialYearId AND BoilType = @BoilType --AND BranchId = @BranchId
	
	Group By BoilNo, BoilType, CompanyId, BranchId, FinancialYearId, JangadNo, SlipNo, EntryDate, KapanId,KapanName,
	ShapeId, ShapeName, SizeId, SizeName, PurityId, PurityName,
	HandOverById, HandOverByName, HandOverToId, HandOverToName, Remarks, Id
	
END