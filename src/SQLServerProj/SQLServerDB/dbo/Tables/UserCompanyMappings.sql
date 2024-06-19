CREATE TABLE [dbo].[UserCompanyMappings] (
    [Id]          NVARCHAR (450) NOT NULL,
    [Sr]          INT            IDENTITY (1, 1) NOT NULL,
    [UserId]      NVARCHAR (450) NULL,
    [CompanyId]   NVARCHAR (MAX) NULL,
    [CreatedDate] DATETIME2 (7)  NOT NULL,
    [UpdatedDate] DATETIME2 (7)  NULL,
    [CreatedBy]   NVARCHAR (MAX) NULL,
    [UpdatedBy]   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_UserCompanyMappings] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserCompanyMappings_UserMaster_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[UserMaster] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_UserCompanyMappings_UserId]
    ON [dbo].[UserCompanyMappings]([UserId] ASC);

