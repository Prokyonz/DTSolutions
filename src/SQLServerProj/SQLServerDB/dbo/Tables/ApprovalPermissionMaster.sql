CREATE TABLE [dbo].[ApprovalPermissionMaster] (
    [Id]          NVARCHAR (450) NOT NULL,
    [Sr]          INT            IDENTITY (1, 1) NOT NULL,
    [DisplayName] NVARCHAR (MAX) NULL,
    [KeyName]     NVARCHAR (MAX) NULL,
    [UserId]      NVARCHAR (MAX) NULL,
    [CreatedDate] DATETIME2 (7)  NOT NULL,
    [UpdatedDate] DATETIME2 (7)  NULL,
    [CreatedBy]   NVARCHAR (MAX) NULL,
    [UpdatedBy]   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ApprovalPermissionMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);

