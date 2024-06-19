CREATE PROCEDURE [GetKapanReport]     
 @CompanyId as varchar(50),    
 @BranchId as varchar(50),    
 @FinancialYearId as varchar(50)       
AS    
BEGIN    
 --SELECT T.*, T.KapanMapingWeight  'Weight' FROM (    
 -- SELECT LOWER(ISNULL(KMM.Id, NEWID())) 'Id', ISNULL(KMM.Sr,0) 'Sr', ISNULL(KMM.CompanyId,'') 'CompanyId', ISNULL(KMM.FinancialYearId,'') 'FinancialYearId', ISNULL(KMM.BranchId,'') 'BranchId', ISNULL(KMM.SlipNo,0) 'SlipNo',     
 -- KM.Id 'KapanId', KM.Name, ISNULL(KMM.Weight,0) KapanMapingWeight,     
 -- KM.CreatedBy, KM.CreatedDate, KM.UpdatedBy, KM.UpdatedDate FROM KapanMaster KM    
 -- LEFT JOIN  KapanMappingMaster KMM ON KMM.KapanId = KM.Id     
 -- --WHERE (KMM.CompanyId = @CompanyId OR KMM.CompanyId IS NULL) AND (KMM.FinancialYearId = @FinancialYearId OR KMM.FinancialYearId IS NULL)    
 --)T LEFT JOIN OpeningStockMaster OSM ON OSM.KapanId = T.KapanId    
 ----Where Name = 'JB'    
 --ORDER BY T.Sr DESC    
    
 SELECT * FROM     
 (    
  SELECT LOWER(ISNULL(KMM.Id, NEWID())) 'Id', ISNULL(KMM.Sr,0) 'Sr', ISNULL(KMM.CompanyId,'') 'CompanyId', ISNULL(KMM.FinancialYearId,'') 'FinancialYearId', ISNULL(KMM.BranchId,'') 'BranchId', ISNULL(KMM.SlipNo,0) 'SlipNo',     
   KM.Id 'KapanId', KM.Name, ISNULL(KMM.Weight,0) Weight,     
   KMM.CreatedBy, KMM.CreatedDate, KMM.UpdatedBy, KMM.UpdatedDate, kMM.PurchaseDetailsId  
   FROM KapanMaster KM    
   INNER JOIN  KapanMappingMaster KMM ON KMM.KapanId = KM.Id     
  WHERE (KMM.CompanyId = @CompanyId OR KMM.CompanyId IS NULL) AND (KMM.FinancialYearId = @FinancialYearId OR KMM.FinancialYearId IS NULL) and ISNULL(KMM.TransferId,'0') = '0' --AND KMM.Weight <> 0    
    
  UNION    
    
  SELECT LOWER(ISNULL(KM.Id, NEWID())) 'Id',0 'Sr',ISNULL(OSM.CompanyId,'') 'CompanyId',ISNULL(OSM.FinancialYearId,'') 'FinancialYearId',ISNULL(OSM.BranchId,'') 'BranchId', '0' 'SlipNo',     
  KM.Id 'KapanId', KM.Name, ISNULL(OSM.TotalCts,0) 'Weight', OSM.CreatedBy, OSM.CreatedDate, OSM.UpdatedBy, OSM.UpdatedDate, '' as PurchaseDetailsId   
  From OpeningStockMaster OSM     
  INNER JOIN KapanMaster KM ON KM.Id = OSM.KapanId     
  WHERE (OSM.CompanyId = @CompanyId OR OSM.CompanyId IS NULL) AND (OSM.FinancialYearId = @FinancialYearId OR OSM.FinancialYearId IS NULL)    
  AND OSM.TotalCts <> 0    
 )T Order by Sr Desc    
    
END