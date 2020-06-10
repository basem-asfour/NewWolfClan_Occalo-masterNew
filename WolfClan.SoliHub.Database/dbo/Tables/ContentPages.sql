CREATE TABLE [dbo].[ContentPages] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [TitleEN]     NVARCHAR (100) NOT NULL,
    [TitleAR]     NVARCHAR (100) NOT NULL,
    [HasLink]     BIT            NOT NULL,
    [Link]        NVARCHAR (500) NULL,
    [ContentEN]   NVARCHAR (MAX) NULL,
    [ContentAR]   NVARCHAR (MAX) NULL,
    [Ordering]    INT            NOT NULL,
    [IsActive]    BIT            NOT NULL,
    [AddedOn]     DATETIME       NOT NULL,
    [ModifiedOn]  DATETIME       NULL,
    [AdminUserId] INT            NULL,
    CONSTRAINT [PK_ContentPages] PRIMARY KEY CLUSTERED ([Id] ASC)
);

