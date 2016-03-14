CREATE TABLE [dbo].[ArticleLike]
(
	[LikeId] INT IDENTITY (1, 1) NOT NULL,
	[ArticleId] INT NOT NULL,
	[LikedById] INT NOT NULL,
	[LikeDate] DATETIME NOT NULL,
	CONSTRAINT [PK_ArticleLike] PRIMARY KEY NONCLUSTERED ([LikeId] ASC),
	CONSTRAINT [FK_Article_Liked] FOREIGN KEY (ArticleId) REFERENCES [Article] ([ArticleId]),
	CONSTRAINT [FK_Liked_By] FOREIGN KEY (LikedById) REFERENCES [AppUser] ([UserId])
)
