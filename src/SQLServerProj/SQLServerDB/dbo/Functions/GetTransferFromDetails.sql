CREATE FUNCTION [dbo].[GetTransferFromDetails]
(
    @kapanId VARCHAR(MAX),
    @CompanyId VARCHAR(50),
    @FinancialYearId VARCHAR(50)
)      
RETURNS TABLE      
AS      
RETURN      
(
    WITH TransferDetails AS (
        SELECT 
            t.Date,
            k.Weight * -1 AS Weight,
            s.Name AS Size,
            CASE 
                WHEN ISNULL(n.TransferId, '') <> '' THEN '(' + s.Name + ') ' + nm.Name 
                ELSE km1.Name 
            END AS Kapan,
            k.TransferCaratRate AS Rate,
            k.KapanId,
            k.BranchId    
        FROM 
            TransferMaster t                    
            INNER JOIN KapanMappingMaster k ON k.TransferId = t.Id               
            LEFT JOIN NumberProcessMaster n ON n.TransferId = t.Id AND n.TransferEntryId = k.TransferEntryId                   
            LEFT JOIN SizeMaster s ON s.Id = n.CharniSizeId              
            LEFT JOIN NumberMaster nm ON nm.Id = n.NumberId              
            INNER JOIN KapanMaster km ON km.Id = k.KapanId              
            LEFT JOIN KapanMaster km1 ON km1.Id = k.TransferId -- Assuming km1 is a transfer source Kapan
        WHERE 
            t.CompanyId = @CompanyId 
            AND t.FinancialYearId = @FinancialYearId
            AND k.TransferType = 'TransferedFrom' 
            AND k.KapanId IN (SELECT id FROM CSVToTable(@kapanId))                          
            AND k.SlipNo <> '0'
    )

    SELECT 
        2 AS Id,
        Date,
        '' AS SlipNo,
        'TT' AS OperationType,
        Size,
        Kapan AS Party,
        SUM(Weight) AS NetWeight,
        Rate AS Rate,
        SUM(Weight) * Rate AS Amount,
        'Outward' AS Category,
        2 AS CategoryId,
        1 AS Records,
        KapanId,
        BranchId 
    FROM TransferDetails
    GROUP BY 
        Date,
        Size,
        Kapan,
        Rate,
        KapanId,
        BranchId

    UNION

    SELECT 
        2 AS Id,
        Date,
        '' AS SlipNo,
        'TT' AS OperationType,
        Size,
        Kapan AS Party,
        SUM(Weight) AS NetWeight,
        Rate AS Rate,
        SUM(Weight) * Rate AS Amount,
        'Outward' AS Category,
        2 AS CategoryId,
        1 AS Records,
        KapanId,
        BranchId 
    FROM (
        SELECT 
            t.Date,
            o.TotalCts * -1 AS Weight,
            s.Name AS Size,
            CASE 
                WHEN ISNULL(n.TransferId, '') <> '' THEN '(' + s.Name + ') ' + nm.Name 
                ELSE km1.Name 
            END AS Kapan,
            o.TransferCaratRate AS Rate,
            o.KapanId,
            o.BranchId    
        FROM 
            TransferMaster t                    
            LEFT JOIN OpeningStockMaster o ON o.TransferId = t.Id                  
            LEFT JOIN NumberProcessMaster n ON n.TransferId = t.Id AND n.TransferEntryId = o.TransferEntryId                   
            LEFT JOIN SizeMaster s ON s.Id = n.CharniSizeId              
            LEFT JOIN NumberMaster nm ON nm.Id = n.NumberId              
            INNER JOIN KapanMaster km ON km.Id = o.KapanId                
            LEFT JOIN KapanMaster km1 ON km1.Id = o.TransferId -- Assuming km1 is a transfer source Kapan
        WHERE 
            t.CompanyId = @CompanyId 
            AND t.FinancialYearId = @FinancialYearId
            AND o.TransferType = 'TransferedFrom' 
            AND o.KapanId IN (SELECT id FROM CSVToTable(@kapanId))
    ) AS x
    GROUP BY 
        Date,
        Size,
        Kapan,
        Rate,
        KapanId,
        BranchId
)