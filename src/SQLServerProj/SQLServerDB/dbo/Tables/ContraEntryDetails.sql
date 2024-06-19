CREATE TABLE [dbo].[ContraEntryDetails] (
    [Id]                  NVARCHAR (450)  NOT NULL,
    [Sr]                  INT             IDENTITY (1, 1) NOT NULL,
    [ContraEntryMasterId] NVARCHAR (450)  NULL,
    [FromParty]           NVARCHAR (MAX)  NULL,
    [Amount]              DECIMAL (18, 2) NOT NULL,
    [CreatedDate]         DATETIME2 (7)   NOT NULL,
    [UpdatedDate]         DATETIME2 (7)   NULL,
    [CreatedBy]           NVARCHAR (MAX)  NULL,
    [UpdatedBy]           NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_ContraEntryDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ContraEntryDetails_ContraEntryMaster_ContraEntryMasterId] FOREIGN KEY ([ContraEntryMasterId]) REFERENCES [dbo].[ContraEntryMaster] ([Id])
);

