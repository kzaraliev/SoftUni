SELECT
	c.[Id],
	CONCAT_WS(' ', c.[FirstName], c.[LastName]) AS [ClientName],
	c.[Email]
FROM [Clients] AS c
LEFT JOIN [ClientsCigars] AS cc
	ON c.[Id] = cc.[ClientId]
WHERE cc.[CigarId] IS NULL
ORDER BY [ClientName] ASC