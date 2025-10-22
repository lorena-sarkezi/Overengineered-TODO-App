CREATE TABLE [dbo].[TodoEntry]
(
    [Id] INT NOT NULL IDENTITY(1,1),
    [TodoId] INT NOT NULL,
    [UserId] INT NOT NULL,
    [Text] NVARCHAR(MAX),
    [CreatedOn] DATETIME,
    [IsCompleted] BIT NOT NULL DEFAULT 0,
    [IsDeleted] BIT NOT NULL DEFAULT 0,
    
    CONSTRAINT PK_TodoEntry PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_TodoEntry_Todo FOREIGN KEY (TodoId) REFERENCES dbo.TodoEntry(Id),
    CONSTRAINT FK_TodoEntry_User FOREIGN KEY (UserId) REFERENCES dbo.Users(Id)
)
