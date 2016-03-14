CREATE TABLE [dbo].[Comment]
(
	[CommentId] INT IDENTITY (1, 1) NOT NULL,
	[CommentText] NVARCHAR(1000) NOT NULL,
	[ArticleId] INT NOT NULL,
	[CommentedById] INT NOT NULL,
	[CommentDate] DATETIME NOT NULL,
	CONSTRAINT [PK_Comment] PRIMARY KEY NONCLUSTERED ([CommentId] ASC),
	CONSTRAINT [FK_Article_Commented] FOREIGN KEY (ArticleId) REFERENCES [Article] ([ArticleId]),
	CONSTRAINT [FK_Commented_By] FOREIGN KEY (CommentedById) REFERENCES [AppUser] ([UserId])
)
