SELECT
	b.[Id],
	b.[Name],
	b.[YearPublished],
	c.[Name] AS [CategoryName]
FROM [Boardgames] AS b
JOIN [Categories] AS c
	ON b.[CategoryId] = c.[Id]
WHERE c.[Name] = 'Strategy Games' OR c.[Name] = 'Wargames'
ORDER BY b.[YearPublished] DESC