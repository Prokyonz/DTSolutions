CREATE TABLE [dbo].[CompanyOptions] (
    [Id]                  NVARCHAR (450) NOT NULL,
    [Sr]                  INT            IDENTITY (1, 1) NOT NULL,
    [CompanyMasterId]     NVARCHAR (450) NULL,
    [IsPurchase]          BIT            NOT NULL,
    [IsSales]             BIT            NOT NULL,
    [PermissionName]      NVARCHAR (MAX) NULL,
    [PermissionStatus]    BIT            NOT NULL,
    [CreatedDate]         DATETIME2 (7)  NOT NULL,
    [UpdatedDate]         DATETIME2 (7)  NULL,
    [CreatedBy]           NVARCHAR (MAX) NULL,
    [UpdatedBy]           NVARCHAR (MAX) NULL,
    [PermissionGroupName] NVARCHAR (MAX) NULL,
    [IsOther]             BIT            DEFAULT (CONVERT([bit],(0))) NOT NULL,
    CONSTRAINT [PK_CompanyOptions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CompanyOptions_CompanyMaster_CompanyMasterId] FOREIGN KEY ([CompanyMasterId]) REFERENCES [dbo].[CompanyMaster] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_CompanyOptions_CompanyMasterId]
    ON [dbo].[CompanyOptions]([CompanyMasterId] ASC);

