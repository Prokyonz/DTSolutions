CREATE TABLE [dbo].[SPBoilProcessReceive] (
    [Id]              NVARCHAR (MAX)  NULL,
    [BoilNo]          INT             NOT NULL,
    [KapanId]         NVARCHAR (MAX)  NULL,
    [Kapan]           NVARCHAR (MAX)  NULL,
    [SlipNo]          NVARCHAR (MAX)  NULL,
    [ShapeId]         NVARCHAR (MAX)  NULL,
    [Shape]           NVARCHAR (MAX)  NULL,
    [SizeId]          NVARCHAR (MAX)  NULL,
    [Size]            NVARCHAR (MAX)  NULL,
    [PurityId]        NVARCHAR (MAX)  NULL,
    [Purity]          NVARCHAR (MAX)  NULL,
    [TotalWeight]     DECIMAL (18, 2) NOT NULL,
    [AvailableWeight] DECIMAL (18, 2) NOT NULL
);

