SELECT
	[Id],
	[Message],
	[RepositoryId],
	[ContributorId]
FROM [Commits]
ORDER BY [Id] ASC,
		 [Message] ASC,
		 [RepositoryId] ASC,
		 [ContributorId] ASC