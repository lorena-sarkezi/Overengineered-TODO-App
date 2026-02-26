CREATE TABLE [dbo].[TodoItems]
(
    [Id] INT NOT NULL IDENTITY(1,1),
    [TodoCollectionId] INT NOT NULL,
    [UserId] INT NOT NULL,
    [Text] NVARCHAR(MAX) NOT NULL,
    [CreatedOn] DATETIME NOT NULL DEFAULT GETUTCDATE(),
    [IsCompleted] BIT NOT NULL DEFAULT 0,
    [IsDeleted] BIT NOT NULL DEFAULT 0,
    
    CONSTRAINT PK_TodoEntry PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_TodoItems_TodoCollections FOREIGN KEY (TodoCollectionId) REFERENCES dbo.TodoCollections(Id),
    CONSTRAINT FK_TodoItems_User FOREIGN KEY (UserId) REFERENCES dbo.Users(Id)
)
