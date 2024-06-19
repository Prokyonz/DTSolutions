CREATE TABLE [dbo].[TransferDetails] (
    [Id]                    NVARCHAR (450)  NOT NULL,
    [Sr]                    INT             IDENTITY (1, 1) NOT NULL,
    [TransferMasterId]      NVARCHAR (450)  NULL,
    [FromCategory]          NVARCHAR (MAX)  NULL,
    [BranchId]              NVARCHAR (MAX)  NULL,
    [ShapeId]               NVARCHAR (MAX)  NULL,
    [Carat]                 DECIMAL (18, 2) NOT NULL,
    [Rate]                  DECIMAL (18, 4) NOT NULL,
    [Amount]                FLOAT (53)      NOT NULL,
    [ToCategory]            NVARCHAR (MAX)  NULL,
    [ToSizeId]              NVARCHAR (MAX)  NULL,
    [ToBranchId]            NVARCHAR (MAX)  NULL,
    [ToNumberIdORKapanId]   NVARCHAR (MAX)  NULL,
    [ToCarat]               DECIMAL (18, 2) NOT NULL,
    [ToRate]                DECIMAL (18, 4) NOT NULL,
    [ToAmount]              FLOAT (53)      NOT NULL,
    [Date]                  NVARCHAR (MAX)  NULL,
    [Time]                  NVARCHAR (MAX)  NULL,
    [CreatedDate]           DATETIME2 (7)   NOT NULL,
    [UpdatedDate]           DATETIME2 (7)   NULL,
    [CreatedBy]             NVARCHAR (MAX)  NULL,
    [UpdatedBy]             NVARCHAR (MAX)  NULL,
    [FromNumberIdORKapanId] NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_TransferDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TransferDetails_TransferMaster_TransferMasterId] FOREIGN KEY ([TransferMasterId]) REFERENCES [dbo].[TransferMaster] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_TransferDetails_TransferMasterId]
    ON [dbo].[TransferDetails]([TransferMasterId] ASC);

