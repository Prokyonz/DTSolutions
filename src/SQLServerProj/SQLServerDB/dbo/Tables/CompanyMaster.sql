CREATE TABLE [dbo].[CompanyMaster] (
    [Id]             NVARCHAR (450) NOT NULL,
    [Sr]             INT            IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (MAX) NULL,
    [Address]        NVARCHAR (MAX) NULL,
    [Address2]       NVARCHAR (MAX) NULL,
    [MobileNo]       NVARCHAR (MAX) NULL,
    [OfficeNo]       NVARCHAR (MAX) NULL,
    [Details]        NVARCHAR (MAX) NULL,
    [TermsCondition] NVARCHAR (MAX) NULL,
    [GSTNo]          NVARCHAR (MAX) NULL,
    [PanCardNo]      NVARCHAR (MAX) NULL,
    [RegistrationNo] NVARCHAR (MAX) NULL,
    [Type]           NVARCHAR (MAX) NULL,
    [IsDelete]       BIT            NOT NULL,
    [CreatedDate]    DATETIME2 (7)  NOT NULL,
    [UpdatedDate]    DATETIME2 (7)  NULL,
    [CreatedBy]      NVARCHAR (MAX) NULL,
    [UpdatedBy]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_CompanyMaster] PRIMARY KEY CLUSTERED ([Id] ASC)
);

