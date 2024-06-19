CREATE TABLE [dbo].[JangadSPReceiveModel] (
    [Id]              NVARCHAR (MAX)  NULL,
    [SrNo]            INT             NOT NULL,
    [SizeId]          NVARCHAR (MAX)  NULL,
    [Size]            NVARCHAR (MAX)  NULL,
    [PartyId]         NVARCHAR (MAX)  NULL,
    [PartyName]       NVARCHAR (MAX)  NULL,
    [BrokerId]        NVARCHAR (MAX)  NULL,
    [BrokerName]      NVARCHAR (MAX)  NULL,
    [Rate]            DECIMAL (18, 4) NOT NULL,
    [Amount]          FLOAT (53)      NOT NULL,
    [TotalWeight]     DECIMAL (18, 4) NOT NULL,
    [AvailableWeight] DECIMAL (18, 4) NOT NULL
);

