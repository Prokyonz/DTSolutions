CREATE TABLE [dbo].[tblJangadPrint] (
    [SNo]         BIGINT          NULL,
    [SrNo]        INT             NOT NULL,
    [Date]        VARCHAR (30)    NULL,
    [CompanyName] NVARCHAR (MAX)  NULL,
    [Address]     NVARCHAR (MAX)  NULL,
    [GSTNo]       NVARCHAR (MAX)  NULL,
    [PartyName]   NVARCHAR (MAX)  NULL,
    [BrokerName]  NVARCHAR (MAX)  NULL,
    [Size]        NVARCHAR (MAX)  NULL,
    [Totalcts]    DECIMAL (18, 4) NOT NULL,
    [Rate]        DECIMAL (18, 4) NOT NULL,
    [Amount]      FLOAT (53)      NOT NULL,
    [Remarks]     NVARCHAR (MAX)  NULL
);

