SELECT
	CONCAT_WS(' ', c.[FirstName], c.[LastName]) AS [FullName],
	c.[Email],
	MAX(b.[Rating]) AS [Rating]
FROM [Creators] AS c
JOIN [CreatorsBoardgames] AS cb
	ON c.[Id] = cb.[CreatorId]
JOIN [Boardgames] AS b
	ON cb.[BoardgameId] = b.[Id]
WHERE SUBSTRING(c.[Email], LEN(c.[Email]) - 3, 4) = '.com'
GROUP BY c.[FirstName], c.[LastName], c.[Email]