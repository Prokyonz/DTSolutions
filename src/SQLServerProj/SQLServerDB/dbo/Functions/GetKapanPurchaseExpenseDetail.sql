CREATE FUNCTION [dbo].[GetKapanPurchaseExpenseDetail]
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
        3 AS Id,
        GETDATE() AS Date,
        0 AS SlipNo,
        '' AS OperationType,
        '' AS Size,
        'Expense (' + CONVERT(VARCHAR, CONVERT(NUMERIC(18,2), K.CaratLimit)) + '%)' AS Party,      
        '0' AS NetWeight,
        '0' AS Rate,
        (SUM(PM.GrossTotal) / ((100 - K.CaratLimit) / 100)) - SUM(PM.GrossTotal) AS Amount,
        'Inward' AS Category,
        1 AS CategoryId,
        1 AS Records,
        KM.KapanId,
        KM.BranchId                      
    FROM 
        KapanMappingMaster KM                      
    INNER JOIN [PurchaseMaster] AS PM ON PM.Id = KM.PurchaseMasterId                      
    INNER JOIN [KapanMaster] AS K ON K.Id = KM.KapanId                      
    WHERE 
        KM.CompanyId = @CompanyId 
        AND KM.FinancialYearId = @FinancialYearId
        AND KM.KapanId IN (SELECT id FROM CSVToTable(@kapanId))                     
    GROUP BY 
        K.CaratLimit, KM.KapanId, KM.BranchId
)