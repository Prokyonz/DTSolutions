CREATE FUNCTION [dbo].[GetRejectionOutDetail]  
(  
    @kapanId VARCHAR(MAX),  
    @CompanyId VARCHAR(50),  
    @FinancialYearId VARCHAR(50)  
)        
RETURNS TABLE        
AS        
RETURN        
(
    SELECT 0 AS Id,
           CAST(r.EntryDate AS DATE) AS Date,
           r.SlipNo,
           '' AS OperationType,
           '' AS Size,
           PAM.Name AS Party,
           r.TotalCarat AS NetWeight,
           r.Rate AS Rate,
           r.Amount AS Amount,
           'Outward' AS Category,
           2 AS CategoryId,
           1 AS Records,
           r.KapanId AS KapanId,
           r.BranchId      
    FROM RejectionInOutMaster r
    LEFT JOIN PurchaseMaster p ON p.SlipNo = r.SlipNo     
    LEFT JOIN PurchaseDetails pd ON pd.PurchaseId = p.Id 
    LEFT JOIN [PartyMaster] AS PAM ON PAM.Id = r.PartyId                         
    WHERE pd.RejectedWeight = 0 
      AND r.ProcessType = 'Boil'    
      AND r.KapanId IN (SELECT id FROM CSVToTable(@kapanId))
)