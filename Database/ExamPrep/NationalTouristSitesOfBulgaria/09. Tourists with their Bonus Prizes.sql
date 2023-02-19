SELECT
	t.[Name],
	t.[Age],
	t.[PhoneNumber],
	t.[Nationality],
	CASE
		WHEN b.[Name] IS NULL THEN '(no bonus prize)'
		ELSE b.[Name]
	END	AS [Reward]
FROM [Tourists] AS t
LEFT JOIN [TouristsBonusPrizes] AS tb
	ON t.[Id] = tb.[TouristId]
LEFT JOIN [BonusPrizes] AS b
	ON tb.[BonusPrizeId] = b.[Id]
ORDER BY t.[Name] ASC