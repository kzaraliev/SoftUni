SELECT TOP 5
	b.[Name],
	b.[Rating],
	c.[Name] AS [CategoryName]
FROM [Boardgames] AS b
JOIN [Categories] AS c
	ON b.[CategoryId] = c.[Id]
JOIN [PlayersRanges] AS p
	ON b.[PlayersRangeId] = p.[Id]
WHERE (b.[Rating] > 7.00 AND b.[Name] LIKE '%a%') OR (b.[Rating] > 7.50 AND (p.[PlayersMin] = 2 AND p.[PlayersMax] = 5))
ORDER BY b.[Name] ASC,
		 b.[Rating] DESC