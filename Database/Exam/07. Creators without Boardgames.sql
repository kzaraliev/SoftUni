SELECT
	c.[Id],
	CONCAT_WS(' ', c.[FirstName], c.[LastName]) AS [CreatorName],
	c.[Email]
FROM [Creators] AS c
LEFT JOIN [CreatorsBoardgames] AS cb
	ON c.[Id] = cb.[CreatorId]
LEFT JOIN [Boardgames] AS b
	ON cb.[BoardgameId] = b.[Id]
WHERE cb.[CreatorId] IS NULL
