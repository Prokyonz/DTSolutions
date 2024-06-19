CREATE TABLE [dbo].[SPNumberProcessReceive] (
    [Id]              NVARCHAR (MAX)  NULL,
    [NumberNo]        INT             NOT NULL,
    [KapanId]         NVARCHAR (MAX)  NULL,
    [Kapan]           NVARCHAR (MAX)  NULL,
    [SlipNo]          NVARCHAR (MAX)  NULL,
    [ShapeId]         NVARCHAR (MAX)  NULL,
    [Shape]           NVARCHAR (MAX)  NULL,
    [SizeId]          NVARCHAR (MAX)  NULL,
    [Size]            NVARCHAR (MAX)  NULL,
    [PurityId]        NVARCHAR (MAX)  NULL,
    [Purity]          NVARCHAR (MAX)  NULL,
    [CharniSizeId]    NVARCHAR (MAX)  NULL,
    [CharniSize]      NVARCHAR (MAX)  NULL,
    [GalaNumberId]    NVARCHAR (MAX)  NULL,
    [GalaNumber]      NVARCHAR (MAX)  NULL,
    [FinancialYearId] NVARCHAR (MAX)  NULL,
    [Weight]          DECIMAL (18, 2) NOT NULL,
    [AvailableWeight] DECIMAL (18, 2) NOT NULL
);

