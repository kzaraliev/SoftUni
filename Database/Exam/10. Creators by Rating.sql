SELECT
	c.[LastName],
	CEILING(AVG(b.[Rating])) AS [AverageRating],
	p.[Name] AS [PublisherName]
FROM [Creators] AS c
JOIN [CreatorsBoardgames] AS cb
	ON c.[Id] = cb.[CreatorId]
JOIN [Boardgames] AS b
	ON b.[Id] = cb.[BoardgameId]
JOIN [Publishers] AS p
	ON p.[Id] = b.[PublisherId]
WHERE p.[Name] = 'Stonemaier Games'
GROUP BY c.[LastName], p.[Name]
ORDER BY AVG(b.[Rating]) DESC