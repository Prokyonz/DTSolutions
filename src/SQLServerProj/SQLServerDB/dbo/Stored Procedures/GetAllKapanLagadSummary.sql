CREATE   PROC [dbo].[GetAllKapanLagadSummary]
    @CompanyId AS VARCHAR(50),
    @FinancialYearId AS VARCHAR(50)      
AS          

DECLARE @KapanId AS VARCHAR(500)

SELECT @KapanId = STRING_AGG(CAST(k.Id AS VARCHAR(MAX)), ',') WITHIN GROUP (ORDER BY Sr DESC)
FROM KapanMaster k    
WHERE k.CompanyId = @CompanyId  

SELECT
    ISNULL(CAST(SUM(z.InwardNetWeight) - SUM(z.OutwardNetWeight) AS DECIMAL(18, 2)), 0) AS NetWeight,
    ISNULL(CAST(AVG(z.InwardRate) - AVG(z.OutwardRate) AS DECIMAL(18, 2)), 0) AS Rate,
    ISNULL(CAST(SUM(z.InwardAmount) - SUM(z.OutwardAmount) AS DECIMAL(18, 2)), 0) AS Amount
FROM (
    SELECT
        CASE WHEN Type = 'Inward' THEN NetWeight ELSE 0 END AS InwardNetWeight,
        CASE WHEN Type = 'Inward' THEN Rate ELSE 0 END AS InwardRate,
        CASE WHEN Type = 'Inward' THEN Amount ELSE 0 END AS InwardAmount,
        CASE WHEN Type = 'Outward' THEN NetWeight ELSE 0 END AS OutwardNetWeight,
        CASE WHEN Type = 'Outward' THEN Rate ELSE 0 END AS OutwardRate,
        CASE WHEN Type = 'Outward' THEN Amount ELSE 0 END AS OutwardAmount
    FROM (
        SELECT 'Inward' AS Type, NetWeight, Rate, Amount
        FROM GetKapanOpeningBalance(@KapanId, @CompanyId, @FinancialYearId)
        UNION ALL
        SELECT 'Inward', NetWeight, Rate, Amount
        FROM GetKapanPurchaseDetails(@KapanId, @CompanyId, @FinancialYearId)
        UNION ALL
        SELECT 'Inward', Weight, Rate, Amount
        FROM GetTransferToDetails(@KapanId, @CompanyId, @FinancialYearId)
        UNION ALL
        SELECT 'Inward', NetWeight, Rate, Amount
        FROM GetKapanPurchaseExpenseDetail(@KapanId, @CompanyId, @FinancialYearId)
        UNION ALL
        SELECT 'Outward', NetWeight, Rate, Amount
        FROM GetKapanSaleDetail(@KapanId, @CompanyId, @FinancialYearId)
        UNION ALL
        SELECT 'Outward', NetWeight, Rate, Amount
        FROM GetAssortmentReceiveDetails(@KapanId, @CompanyId, @FinancialYearId)
        UNION ALL
        SELECT 'Outward', NetWeight, Rate, Amount
        FROM GetTransferFromDetails(@KapanId, @CompanyId, @FinancialYearId)
        UNION ALL
        SELECT 'Outward', NetWeight, Rate, Amount
        FROM GetRejectionOutDetail(@KapanId, @CompanyId, @FinancialYearId)
    ) AS x
) AS z