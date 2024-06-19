CREATE TABLE [dbo].[SPJangadSendReceiveReportModel] (
    [Id]              NVARCHAR (MAX)  NULL,
    [Sr]              INT             NOT NULL,
    [SrNo]            INT             NOT NULL,
    [FinancialYearId] NVARCHAR (MAX)  NULL,
    [PartyId]         NVARCHAR (MAX)  NULL,
    [PartyName]       NVARCHAR (MAX)  NULL,
    [SizeId]          NVARCHAR (MAX)  NULL,
    [SizeName]        NVARCHAR (MAX)  NULL,
    [BrokerId]        NVARCHAR (MAX)  NULL,
    [BrokerName]      NVARCHAR (MAX)  NULL,
    [Totalcts]        DECIMAL (18, 4) NOT NULL,
    [Rate]            DECIMAL (18, 4) NOT NULL,
    [Amount]          FLOAT (53)      NOT NULL,
    [Remarks]         NVARCHAR (MAX)  NULL,
    [UpdatedDate]     DATETIME2 (7)   NULL
);

