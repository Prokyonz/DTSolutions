CREATE TABLE [dbo].[PermissionMaster] (
    [Id]          NVARCHAR (450) NOT NULL,
    [Sr]          INT            IDENTITY (1, 1) NOT NULL,
    [DisplayName] NVARCHAR (MAX) NULL,
    [Category]    INT            NOT NULL,
    [KeyName]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_PermissionMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);

