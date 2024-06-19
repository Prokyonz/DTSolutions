CREATE TABLE [dbo].[AccountToAssortDetails] (
    [Id]                      NVARCHAR (450)  NOT NULL,
    [Sr]                      INT             IDENTITY (1, 1) NOT NULL,
    [AccountToAssortMasterId] NVARCHAR (450)  NULL,
    [PurchaseDetailsId]       NVARCHAR (MAX)  NULL,
    [SlipNo]                  NVARCHAR (MAX)  NULL,
    [ShapeId]                 NVARCHAR (MAX)  NULL,
    [SizeId]                  NVARCHAR (MAX)  NULL,
    [PurityId]                NVARCHAR (MAX)  NULL,
    [BoilProcessId]           NVARCHAR (MAX)  NULL,
    [CharniProcessId]         NVARCHAR (MAX)  NULL,
    [GalaProcessId]           NVARCHAR (MAX)  NULL,
    [NumberProcessId]         NVARCHAR (MAX)  NULL,
    [TotalAmount]             DECIMAL (18, 4) NOT NULL,
    [Price]                   DECIMAL (18, 4) NOT NULL,
    [Weight]                  DECIMAL (18, 4) NOT NULL,
    [AssignWeight]            DECIMAL (18, 4) NOT NULL,
    [StockId]                 NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_AccountToAssortDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AccountToAssortDetails_AccountToAssortMaster_AccountToAssortMasterId] FOREIGN KEY ([AccountToAssortMasterId]) REFERENCES [dbo].[AccountToAssortMaster] ([Id])
);

