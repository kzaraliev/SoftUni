SELECT TOP 5
	rep.[Id],
	rep.[Name],
	COUNT(rep.[Id]) AS [Commits]
FROM [Repositories] AS rep
JOIN [Commits] AS c
	ON rep.[Id] = c.[RepositoryId]
JOIN [RepositoriesContributors] AS rc
	ON rep.[Id] = rc.[RepositoryId]
GROUP BY rep.[Id], rep.[Name]
ORDER BY [Commits] DESC,
		 rep.[Id] ASC,
		 rep.[Name] ASC
