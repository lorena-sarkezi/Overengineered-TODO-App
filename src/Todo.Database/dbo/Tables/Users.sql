CREATE TABLE [dbo].[Users]
(
    [Id] INT NOT NULL IDENTITY(1,1),
    [DisplayName] NVARCHAR(128),
    [Email] NVARCHAR(128),
    [PasswordHash] NVARCHAR(512),
    
    CONSTRAINT PK_Users PRIMARY KEY CLUSTERED (Id)
)