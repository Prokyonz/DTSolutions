CREATE TABLE [dbo].[JangadPrintDetailModel] (
    [SNo]         BIGINT          NOT NULL,
    [SrNo]        INT             NOT NULL,
    [Date]        NVARCHAR (MAX)  NULL,
    [CompanyName] NVARCHAR (MAX)  NULL,
    [Address]     NVARCHAR (MAX)  NULL,
    [GSTNo]       NVARCHAR (MAX)  NULL,
    [PartyName]   NVARCHAR (MAX)  NULL,
    [BrokerName]  NVARCHAR (MAX)  NULL,
    [Size]        NVARCHAR (MAX)  NULL,
    [Remarks]     NVARCHAR (MAX)  NULL,
    [Rate]        DECIMAL (18, 4) NOT NULL,
    [Amount]      FLOAT (53)      NOT NULL,
    [TotalCts]    DECIMAL (18, 4) NOT NULL
);

