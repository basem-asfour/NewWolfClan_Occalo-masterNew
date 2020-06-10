CREATE TABLE [dbo].[Users]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(550) NOT NULL, 
    [LastName] NVARCHAR(550) NOT NULL, 
    [Email] NVARCHAR(550) NOT NULL, 
    [Password] VARBINARY(550) NOT NULL, 
    [Address] NVARCHAR(4000) NOT NULL, 
    [Birthday] DATETIME NOT NULL DEFAULT getdate(), 
    [Gender] INT NOT NULL DEFAULT 0, 
    [Language] INT NOT NULL DEFAULT 0, 
    [Phone] NCHAR(11) NOT NULL, 
    [ProfilePic] VARBINARY(MAX) NULL, 
    [RegDate] DATETIME NOT NULL DEFAULT getdate(), 
    [Share_Code] NCHAR(50) NOT NULL 
)
