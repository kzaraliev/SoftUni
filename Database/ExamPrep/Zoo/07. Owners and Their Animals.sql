SELECT TOP 5
	own.[Name] AS [Owner],
	COUNT(*) AS [CountOfAnimals]
FROM [Owners] AS own
JOIN [Animals] AS a
	ON own.[Id] = a.[OwnerId]
GROUP BY own.[Name]
ORDER BY COUNT(*) DESC,
		 own.[Name]