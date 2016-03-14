CREATE TABLE [dbo].[Article]
(
	[ArticleId] INT IDENTITY (1, 1) NOT NULL,
	[Title] NVARCHAR(1000) NOT NULL,
	[Body] NVARCHAR(MAX) NOT NULL,
	[PublisherId] INT NOT NULL,
	[PublishDate] datetime NOT NULL,
	[IsDeleted] BIT NOT NULL DEFAULT (0),
    CONSTRAINT [PK_Article] PRIMARY KEY NONCLUSTERED ([ArticleId] ASC),
    CONSTRAINT [FK_Article_Publisher] FOREIGN KEY (PublisherId) REFERENCES [AppUser] ([UserId])
)
