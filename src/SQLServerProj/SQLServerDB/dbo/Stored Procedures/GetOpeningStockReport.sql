
CREATE proc [dbo].[GetOpeningStockReport]

@CompanyId as varchar(50),                  
@FinancialYear as varchar(50)            
          
AS         
BEGIN
SELECT OSM.Id, OSM.FinancialYearId, OSM.CompanyId, OSM.BranchId, BM.Name 'BranchName', SrNo, KapanId, KM.Name KapanName, SizeId, SM.Name SizeName, NumberId, NM.Name NumberName, TotalCts, Rate, Amount, Remarks, OSM.UpdatedDate from OpeningStockMaster OSM
LEFT JOIN KapanMaster KM ON KM.Id = OSM.KapanId
LEFT JOIN SizeMaster SM ON SM.Id = OSM.SizeId
LEFT JOIN NumberMaster NM ON NM.Id = OSM.NumberId
LEFT JOIN BranchMaster BM ON BM.Id = OSM.BranchId
WHERE OSM.CompanyId = @CompanyId and OSM.FinancialYearId = @FinancialYear AND OSM.TransferType is NULL

END