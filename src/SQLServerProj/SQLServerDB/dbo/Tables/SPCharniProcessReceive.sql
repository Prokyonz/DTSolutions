CREATE TABLE [dbo].[SPCharniProcessReceive] (
    [Id]              NVARCHAR (MAX)  NULL,
    [CharniNo]        INT             NOT NULL,
    [BoilJangadNo]    INT             NOT NULL,
    [EntryDate]       NVARCHAR (MAX)  NULL,
    [KapanId]         NVARCHAR (MAX)  NULL,
    [Kapan]           NVARCHAR (MAX)  NULL,
    [SlipNo]          NVARCHAR (MAX)  NULL,
    [ShapeId]         NVARCHAR (MAX)  NULL,
    [Shape]           NVARCHAR (MAX)  NULL,
    [SizeId]          NVARCHAR (MAX)  NULL,
    [Size]            NVARCHAR (MAX)  NULL,
    [PurityId]        NVARCHAR (MAX)  NULL,
    [Purity]          NVARCHAR (MAX)  NULL,
    [FinancialYearId] NVARCHAR (MAX)  NULL,
    [Weight]          DECIMAL (18, 2) NOT NULL,
    [AvailableWeight] DECIMAL (18, 2) NOT NULL
);

