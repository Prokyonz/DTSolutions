CREATE TABLE [dbo].[SalesItemDetails] (
    [Id]              NVARCHAR (MAX)  NULL,
    [CompanyId]       NVARCHAR (MAX)  NULL,
    [FinancialYearId] NVARCHAR (MAX)  NULL,
    [KapanId]         NVARCHAR (MAX)  NULL,
    [Kapan]           NVARCHAR (MAX)  NULL,
    [ShapeId]         NVARCHAR (MAX)  NULL,
    [Shape]           NVARCHAR (MAX)  NULL,
    [SizeId]          NVARCHAR (MAX)  NULL,
    [Size]            NVARCHAR (MAX)  NULL,
    [PurityId]        NVARCHAR (MAX)  NULL,
    [Purity]          NVARCHAR (MAX)  NULL,
    [CharniSizeId]    NVARCHAR (MAX)  NULL,
    [CharniSize]      NVARCHAR (MAX)  NULL,
    [GalaNumberId]    NVARCHAR (MAX)  NULL,
    [GalaSize]        NVARCHAR (MAX)  NULL,
    [NumberSizeId]    NVARCHAR (MAX)  NULL,
    [NumberSize]      NVARCHAR (MAX)  NULL,
    [AvailableWeight] DECIMAL (18, 4) NOT NULL
);

