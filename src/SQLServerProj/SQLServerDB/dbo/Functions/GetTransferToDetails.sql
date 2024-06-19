CREATE FUNCTION [dbo].[GetTransferToDetails]
(
    @kapanId VARCHAR(MAX),
    @CompanyId VARCHAR(50),
    @FinancialYearId VARCHAR(50)
)          
RETURNS TABLE          
AS          
RETURN          
(
    SELECT 
        2 AS Id,
        Date,
        '' AS SlipNo,
        'TF' AS OperationType,
        Size,
        Kapan AS Kapan,
        Weight,
        Rate,
        Weight * Rate AS Amount,
        'Inward' AS Category,
        1 AS CategoryId,
        1 AS Records,
        KapanId,
        BranchId 
    FROM 
    (                      
        SELECT 
            t.Date,
            k.Weight AS Weight,
            s.Name AS Size,                      
            CASE 
                WHEN n.TransferId <> '' THEN '(' + s.Name + ') ' + nm.Name 
                ELSE (
                    SELECT TOP 1 km1.Name 
                    FROM KapanMappingMaster k1 
                    LEFT JOIN KapanMaster km1 ON km1.Id = k1.KapanId 
                    WHERE k1.TransferId = k.TransferId 
                        AND k1.TransferEntryId = k.TransferEntryId 
                        AND TransferType = 'TransferedFrom'
                ) 
            END AS Kapan,                      
            (
                SELECT TOP 1 k1.TransferCaratRate 
                FROM KapanMappingMaster k1 
                WHERE k1.TransferId = k.TransferId 
                    AND k1.TransferEntryId = k.TransferEntryId 
                    AND TransferType = 'TransferedTo'
            ) AS Rate,      
            k.KapanId, 
            k.BranchId      
        FROM TransferMaster t                      
        INNER JOIN KapanMappingMaster k ON k.TransferId = t.Id                   
        LEFT JOIN NumberProcessMaster n ON n.TransferId = t.Id AND n.TransferEntryId = k.TransferEntryId                     
        LEFT JOIN SizeMaster s ON s.Id = n.CharniSizeId                
        LEFT JOIN NumberMaster nm ON nm.Id = n.NumberId                
        INNER JOIN KapanMaster km ON km.Id = k.KapanId                   
        WHERE 
            t.CompanyId = @CompanyId 
            AND t.FinancialYearId = @FinancialYearId
            AND k.TransferType = 'TransferedTo' 
            AND k.KapanId IN (SELECT id FROM CSVToTable(@kapanId))                     
    ) x                 
                 
    UNION                      

    SELECT 
        2 AS Id,
        Date,
        '' AS SlipNo,
        'TF' AS OperationType,
        Size,
        Kapan AS Kapan,
        Weight,
        Rate,
        Weight * Rate AS Amount,
        'Inward' AS Category,
        1 AS CategoryId,
        1 AS Records,
        KapanId,
        BranchId 
    FROM 
    (                      
        SELECT 
            t.Date,
            o.TotalCts AS Weight,
            s.Name AS Size,                      
            CASE 
                WHEN n.TransferId <> '' THEN '(' + s.Name + ') ' + nm.Name 
                ELSE (
                    SELECT TOP 1 km1.Name 
                    FROM OpeningStockMaster o1 
                    LEFT JOIN KapanMaster km1 ON km1.Id = o1.KapanId 
                    WHERE o1.TransferId = o.TransferId 
                        AND o1.TransferEntryId = o.TransferEntryId 
                        AND TransferType = 'TransferedFrom'
                ) 
            END AS Kapan,                      
            (
                SELECT TOP 1 o1.TransferCaratRate 
                FROM OpeningStockMaster o1 
                WHERE o1.TransferId = o.TransferId 
                    AND o1.TransferEntryId = o.TransferEntryId 
                    AND TransferType = 'TransferedTo'
            ) AS Rate,      
            o.KapanId,
            o.BranchId      
        FROM TransferMaster t                      
        INNER JOIN OpeningStockMaster o ON o.TransferId = t.Id                    
        LEFT JOIN NumberProcessMaster n ON n.TransferId = t.Id AND n.TransferEntryId = o.TransferEntryId                     
        LEFT JOIN SizeMaster s ON s.Id = n.CharniSizeId                
        LEFT JOIN NumberMaster nm ON nm.Id = n.NumberId                
        INNER JOIN KapanMaster km ON km.Id = o.KapanId                    
        WHERE 
            t.CompanyId = @CompanyId 
            AND t.FinancialYearId = @FinancialYearId
            AND o.TransferType = 'TransferedTo' 
            AND o.KapanId IN (SELECT id FROM CSVToTable(@kapanId))                     
    ) x
)