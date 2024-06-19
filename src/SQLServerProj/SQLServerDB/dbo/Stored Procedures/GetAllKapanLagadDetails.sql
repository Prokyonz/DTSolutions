CREATE   PROC [dbo].[GetAllKapanLagadDetails]
    @CompanyId AS VARCHAR(50),
    @FinancialYearId AS VARCHAR(50)      
AS          

-- Drop table #tempKapanDetails          

DECLARE @KapanId AS VARCHAR(MAX)

SELECT @KapanId = STUFF(                  
    (
        SELECT ',' + CONVERT(NVARCHAR(MAX), k.Id)          
        FROM KapanMaster k    
        WHERE k.CompanyId = @CompanyId  
        ORDER BY Sr DESC          
        FOR XML PATH(''), TYPE
    ).value('.', 'VARCHAR(MAX)'), 1, 1, '')

SELECT
    ROW_NUMBER() OVER(PARTITION BY k2.Name ORDER BY k2.Name, x.Date, x.Id ASC) AS RowNo,
    k2.Name,
    x.Id,
    x.Date,
    x.Party,
    CONVERT(DECIMAL(18, 2), x.InwardNetWeight) AS 'InwardNetWeight',
    CONVERT(DECIMAL(18, 2), x.InwardRate) AS 'InwardRate',
    CONVERT(DECIMAL(18, 2), x.InwardAmount) AS 'InwardAmount',
    CONVERT(DECIMAL(18, 2), x.OutwardNetWeight) AS 'OutwardNetWeight',
    CONVERT(DECIMAL(18, 2), x.OutwardRate) AS 'OutwardRate',
    CONVERT(DECIMAL(18, 2), x.OutwardAmount) AS 'OutwardAmount',
    x.Category,
    x.CategoryId,
    x.Records,
    x.KapanId,
    x.BranchId
INTO #tempKapanDetails
FROM (
    SELECT
        Id,
        Date,
        Party,
        NetWeight AS InwardNetWeight,
        Rate AS InwardRate,
        Amount AS InwardAmount,
        0 AS OutwardNetWeight,
        0 AS OutwardRate,
        0 AS OutwardAmount,
        Category,
        CategoryId,
        Records,
        KapanId,
        BranchId
    FROM GetKapanOpeningBalance(@KapanId, @CompanyId, @FinancialYearId)

    UNION ALL

    SELECT
        Id,
        Date,
        Party,
        NetWeight AS InwardNetWeight,
        Rate AS InwardRate,
        Amount AS InwardAmount,
        0 AS OutwardNetWeight,
        0 AS OutwardRate,
        0 AS OutwardAmount,
        Category,
        CategoryId,
        Records,
        KapanId,
        BranchId
    FROM GetKapanPurchaseDetails(@KapanId, @CompanyId, @FinancialYearId)

    UNION ALL

    SELECT
        Id,
        Date,
        Kapan + ISNULL(Size, '') AS Party,
        Weight AS InwardNetWeight,
        Rate AS InwardRate,
        Amount AS InwardAmount,
        0 AS OutwardNetWeight,
        0 AS OutwardRate,
        0 AS OutwardAmount,
        Category,
        CategoryId,
        Records,
        KapanId,
        BranchId
    FROM GetTransferToDetails(@KapanId, @CompanyId, @FinancialYearId)

	--Rejection receive
	UNION ALL

    SELECT
        Id,
        Date,
        Party,
        NetWeight AS InwardNetWeight,
        Rate AS InwardRate,
        Amount AS InwardAmount,
        0 AS OutwardNetWeight,
        0 AS OutwardRate,
        0 AS OutwardAmount,
        Category,
        CategoryId,
        Records,
        KapanId,
        BranchId
    FROM GetSaleRejectionReceiveDetails(@KapanId, @CompanyId, @FinancialYearId)

    UNION ALL

    SELECT
        Id,
        Date,
        Party,
        NetWeight AS InwardNetWeight,
        Rate AS InwardRate,
        Amount AS InwardAmount,
        0 AS OutwardNetWeight,
        0 AS OutwardRate,
        0 AS OutwardAmount,
        Category,
        CategoryId,
        Records,
        KapanId,
        BranchId
    FROM GetKapanPurchaseExpenseDetail(@KapanId, @CompanyId, @FinancialYearId)

    UNION ALL

    SELECT
        Id,
        Date,
        Party,
        0 AS InwardNetWeight,
        0 AS InwardRate,
        0 AS InwardAmount,
        NetWeight AS OutwardNetWeight,
        Rate AS OutwardRate,
        Amount AS OutwardAmount,
        Category,
        CategoryId,
        Records,
        KapanId,
        BranchId
    FROM GetKapanSaleDetail(@KapanId, @CompanyId, @FinancialYearId)

    UNION ALL

    SELECT
        Id,
        Date,
        Party,
        0 AS InwardNetWeight,
        0 AS InwardRate,
        0 AS InwardAmount,
        NetWeight AS OutwardNetWeight,
        Rate AS OutwardRate,
        Amount AS OutwardAmount,
        Category,
        CategoryId,
        Records,
        KapanId,
        BranchId
    FROM GetAssortmentReceiveDetails(@KapanId, @CompanyId, @FinancialYearId)

    UNION ALL

    SELECT
        Id,
        Date,
        Party,
        0 AS InwardNetWeight,
        0 AS InwardRate,
        0 AS InwardAmount,
        NetWeight AS OutwardNetWeight,
        Rate AS OutwardRate,
        Amount AS OutwardAmount,
        Category,
        CategoryId,
        Records,
        KapanId,
        BranchId
    FROM GetTransferFromDetails(@KapanId, @CompanyId, @FinancialYearId)

    UNION ALL

    SELECT
        Id,
        Date,
        Party,
        0 AS InwardNetWeight,
        0 AS InwardRate,
        0 AS InwardAmount,
        NetWeight AS OutwardNetWeight,
        Rate AS OutwardRate,
        Amount AS OutwardAmount,
        Category,
        CategoryId,
        Records,
        KapanId,
        BranchId
    FROM GetRejectionOutDetail(@KapanId, @CompanyId, @FinancialYearId)

	--Rejection Out
	UNION ALL

    SELECT
        Id,
        Date,
        Party,
        0 AS InwardNetWeight,
        0 AS InwardRate,
        0 AS InwardAmount,
        NetWeight AS OutwardNetWeight,
        Rate AS OutwardRate,
        Amount AS OutwardAmount,
        Category,
        CategoryId,
        Records,
        KapanId,
        BranchId
    FROM GetPurchaseRejectionReturnDetails(@KapanId, @CompanyId, @FinancialYearId)

) x
LEFT JOIN KapanMaster k2 ON k2.Id = x.KapanId

SELECT
    ROW_NUMBER() OVER(PARTITION BY k.Name ORDER BY k.Name, x.Date, x.Id ASC) AS RowNo,
    k.Name,
    x.*,
    b.Name AS BranchName
INTO #tempKapanDetails1
FROM (
    SELECT
        Id,
        Date,
        Party,
        InwardNetWeight,
        InwardRate,
        InwardAmount,
        OutwardNetWeight,
        OutwardRate,
        OutwardAmount,
        Category,
        CategoryId,
        Records,
        KapanId,
        BranchId
    FROM #tempKapanDetails

    UNION ALL

    SELECT
        4 AS Id,
        GETDATE() AS Date,
        'Tip Weight' AS Party,
        SUM(y.TIPWeight) + SUM(y.LessWeight) AS 'InwardNetWeight',
        (SELECT SUM(InwardAmount) / SUM(InwardNetWeight) FROM #tempKapanDetails WHERE CategoryId = 1) AS 'InwardRate',
        (SUM(y.TIPWeight) + SUM(y.LessWeight)) * (SELECT SUM(InwardAmount) / SUM(InwardNetWeight) FROM #tempKapanDetails WHERE CategoryId = 1) AS 'InwardAmount',
        0 AS OutwardNetWeight,
        0 AS OutwardRate,
        0 AS OutwardAmount,
        'Inward' AS Category,
        1 AS CategoryId,
        1 AS Records,
        y.KapanId,
        y.BranchId
    FROM (
        SELECT DISTINCT
            pd.id,
            pd.TIPWeight,
            pd.LessWeight,
            km.KapanId,
            km.BranchId
        FROM [PurchaseDetails] AS PD
        LEFT JOIN [PurchaseMaster] AS PM ON PM.Id = PD.PurchaseId
        LEFT JOIN KapanMappingMaster KM ON PD.Id = KM.PurchaseDetailsId
        WHERE KM.KapanId IN (SELECT id FROM CSVToTable(@kapanId))
    ) y
    GROUP BY y.KapanId, y.BranchId
) x
LEFT JOIN KapanMaster k ON k.Id = x.KapanId
LEFT JOIN BranchMaster b ON b.Id = x.BranchId;

WITH KapanDetailsCTE AS (  
    SELECT  
        RowNo,  
        Name,  
        Id,  
        Date,  
        Party,  
        InwardNetWeight,  
        InwardRate,  
        InwardAmount,  
        OutwardNetWeight,  
        OutwardRate,  
        OutwardAmount,  
        Category,  
        CategoryId,  
        Records,  
        KapanId,  
        BranchId,  
        BranchName,  
        SUM(InwardNetWeight) OVER (PARTITION BY Name ORDER BY RowNo) AS RunningInwardNetWeight,  
        SUM(OutwardNetWeight) OVER (PARTITION BY Name ORDER BY RowNo) AS RunningOutwardNetWeight,  
        SUM(InwardRate) OVER (PARTITION BY Name ORDER BY RowNo) AS RunningInwardRate,  
        SUM(OutwardRate) OVER (PARTITION BY Name ORDER BY RowNo) AS RunningOutwardRate,  
        SUM(InwardAmount) OVER (PARTITION BY Name ORDER BY RowNo) AS RunningInwardAmount,  
        SUM(OutwardAmount) OVER (PARTITION BY Name ORDER BY RowNo) AS RunningOutwardAmount  
    FROM  
        #tempKapanDetails1  
)  
SELECT  
    RowNo,  
    Name,  
    Id,  
    Date,  
    Party,  
    InwardNetWeight,  
    InwardRate,  
    InwardAmount,  
    OutwardNetWeight,  
    OutwardRate,  
    OutwardAmount,  
    Category,  
    CategoryId,  
    Records,  
    KapanId,  
    BranchId,  
    BranchName,  
    RunningInwardNetWeight - RunningOutwardNetWeight AS ClosingNetWeight,  
    (RunningInwardRate / RowNo) - (RunningOutwardRate / RowNo) AS ClosingRate,  
    RunningInwardAmount - RunningOutwardAmount AS ClosingAmount  
FROM  
    KapanDetailsCTE  
ORDER BY  
    Name;