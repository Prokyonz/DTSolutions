CREATE TABLE [dbo].[SPRejectionSendReceiveModel] (
    [Id]              NVARCHAR (MAX)  NULL,
    [CompanyId]       NVARCHAR (MAX)  NULL,
    [FinancialYearId] NVARCHAR (MAX)  NULL,
    [SlipNo]          NVARCHAR (MAX)  NULL,
    [KapanId]         NVARCHAR (MAX)  NULL,
    [Kapan]           NVARCHAR (MAX)  NULL,
    [ShapeId]         NVARCHAR (MAX)  NULL,
    [SizeId]          NVARCHAR (MAX)  NULL,
    [Size]            NVARCHAR (MAX)  NULL,
    [PurityId]        NVARCHAR (MAX)  NULL,
    [RejectedWeight]  DECIMAL (18, 4) NOT NULL,
    [ReturnCts]       DECIMAL (18, 4) NOT NULL,
    [Available]       DECIMAL (18, 4) NOT NULL,
    [Rate]            FLOAT (53)      NOT NULL,
    [ProcessType]     NVARCHAR (MAX)  NULL,
    [Number]          NVARCHAR (MAX)  NULL
);

