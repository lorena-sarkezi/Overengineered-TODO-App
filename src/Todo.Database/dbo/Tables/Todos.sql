CREATE TABLE [dbo].[Todos]
(
    [Id] INT IDENTITY(1,1),
    [UserId] INT NOT NULL,
    [Name] NVARCHAR(512),
    [CreatedOn] DATETIME,
    [IsCompleted] BIT NOT NULL DEFAULT 0,
    [IsDeleted] BIT NOT NULL DEFAULT 0,
    
    CONSTRAINT PK_Todos PRIMARY KEY CLUSTERED (Id),
    CONSTRAINT FK_Todos_Users FOREIGN KEY (UserId) REFERENCES [dbo].[Users](Id)
)