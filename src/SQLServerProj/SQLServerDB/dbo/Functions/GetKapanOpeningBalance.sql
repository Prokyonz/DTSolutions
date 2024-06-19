--USE [diamondtrading]
--GO
--/****** Object:  UserDefinedFunction [dbo].[GetKapanOpeningBalance]    Script Date: 03-05-2024 14:49:26 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--ALTER function [dbo].[GetKapanOpeningBalance]     
--(
--@kapanId varchar(max),
--@CompanyId as varchar(50),
--@FinancialYearId as varchar(50)
--)      
--returns Table      
--as      
--return      
-- (select 0 as Id,CAST(CreatedDate as date) Date, '0' as SlipNo,'' as OperationType,'' as Size,                    
-- 'Opening Stock' AS Party, TotalCts as NetWeight,Rate, TotalCts*Rate as Amount,'Inward' as Category, 1 as CategoryId, 1 as Records,    
-- o.KapanId,o.BranchId    
-- from OpeningStockMaster o                     
-- where o.CompanyId=@CompanyId and o.FinancialYearId=@FinancialYearId
-- and Category=1 and isnull(TransferType,'')='' 
-- and o.KapanId in (select id from CSVToTable(@kapanId)))

CREATE   FUNCTION [dbo].[GetKapanOpeningBalance]     
(
    @kapanId VARCHAR(MAX),
    @CompanyId AS VARCHAR(50),
    @FinancialYearId AS VARCHAR(50)
)      
RETURNS TABLE      
AS      
RETURN      
(
    SELECT 
        0 AS Id,
        CAST(CreatedDate AS DATE) AS Date,
        '0' AS SlipNo,
        '' AS OperationType,
        '' AS Size,
        'Opening Stock' AS Party,
        TotalCts AS NetWeight,
        Rate,
        TotalCts * Rate AS Amount,
        'Inward' AS Category,
        1 AS CategoryId,
        1 AS Records,
        o.KapanId,
        o.BranchId    
    FROM 
        OpeningStockMaster o                     
    INNER JOIN 
        CSVToTable(@kapanId) AS k ON o.KapanId = k.id
    WHERE 
        o.CompanyId = @CompanyId 
        AND o.FinancialYearId = @FinancialYearId
        AND Category = 1 
        AND ISNULL(TransferType, '') = ''
);