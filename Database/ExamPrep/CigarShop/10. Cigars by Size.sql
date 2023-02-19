SELECT
	c.[LastName],
	AVG(s.[Length]) AS [CigarLength],
	CEILING(AVG(s.[RingRange])) AS [CigarRingRange]
FROM [Clients] AS c
JOIN [ClientsCigars] AS ccig
	ON c.[Id] = ccig.[ClientId]
JOIN [Cigars] AS cig
	ON cig.[Id] = ccig.[CigarId]
JOIN [Sizes] AS s
	ON cig.[SizeId] = s.[Id]
GROUP BY c.[LastName]
ORDER BY [CigarLength] DESC