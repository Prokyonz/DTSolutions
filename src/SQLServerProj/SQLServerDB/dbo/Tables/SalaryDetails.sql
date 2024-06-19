CREATE TABLE [dbo].[SalaryDetails] (
    [Id]             NVARCHAR (450)  NOT NULL,
    [Sr]             INT             IDENTITY (1, 1) NOT NULL,
    [SalaryMasterId] NVARCHAR (450)  NULL,
    [AdvanceAmount]  DECIMAL (18, 4) NOT NULL,
    [BonusAmount]    DECIMAL (18, 4) NOT NULL,
    [TotalAmount]    DECIMAL (18, 4) NOT NULL,
    [OTPlusAmount]   DECIMAL (18, 2) DEFAULT ((0.0)) NOT NULL,
    [OTPlusRate]     DECIMAL (18, 2) DEFAULT ((0.0)) NOT NULL,
    [RoundOfAmount]  DECIMAL (18, 2) DEFAULT ((0.0)) NOT NULL,
    [SalaryAmount]   DECIMAL (18, 4) DEFAULT ((0.0)) NOT NULL,
    [ToPartyId]      NVARCHAR (MAX)  NULL,
    [WorkedDays]     DECIMAL (18, 2) DEFAULT ((0.0)) NOT NULL,
    [WorkingDays]    DECIMAL (18, 2) DEFAULT ((0.0)) NOT NULL,
    [OTMinusAmount]  DECIMAL (18, 2) DEFAULT ((0.0)) NOT NULL,
    [OTMinusHrs]     DECIMAL (18, 2) DEFAULT ((0.0)) NOT NULL,
    [OTMinusRate]    DECIMAL (18, 2) DEFAULT ((0.0)) NOT NULL,
    [OTPlusHrs]      DECIMAL (18, 2) DEFAULT ((0.0)) NOT NULL,
    CONSTRAINT [PK_SalaryDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SalaryDetails_SalaryMaster_SalaryMasterId] FOREIGN KEY ([SalaryMasterId]) REFERENCES [dbo].[SalaryMaster] ([Id])
);

