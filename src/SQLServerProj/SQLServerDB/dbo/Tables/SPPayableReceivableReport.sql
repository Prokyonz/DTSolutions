CREATE TABLE [dbo].[SPPayableReceivableReport] (
    [Type]       NVARCHAR (MAX) NULL,
    [PartyId]    NVARCHAR (MAX) NULL,
    [Name]       NVARCHAR (MAX) NULL,
    [Total]      FLOAT (53)     NOT NULL,
    [BrokerName] NVARCHAR (MAX) NULL,
    [EntryDate]  DATETIME2 (7)  NULL,
    [Id]         NVARCHAR (MAX) NULL,
    [SlipNo]     BIGINT         DEFAULT (CONVERT([bigint],(0))) NOT NULL
);

