SELECT
	u.[UserName],
	AVG(f.[Size]) AS [Size]
FROM [Files] AS f
JOIN [Commits] AS c
	ON f.[CommitId] = c.[Id]
JOIN [Users] AS u
	ON c.[ContributorId] = u.[Id] 
GROUP BY c.[ContributorId], u.[Username]
ORDER BY AVG(f.[Size]) DESC,
		 u.[Username] ASC