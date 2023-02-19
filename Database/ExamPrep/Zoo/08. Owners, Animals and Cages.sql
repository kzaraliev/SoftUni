SELECT
	CONCAT_WS('-', own.[Name], a.[Name]),
	own.[PhoneNumber],
	ac.[CageId]
FROM [Owners] AS own
JOIN [Animals] AS a
	ON own.[Id] = a.[OwnerId]
JOIN [AnimalsCages] AS ac
	ON a.[Id] = ac.[AnimalId]
WHERE a.[AnimalTypeId] = 1
ORDER BY own.[Name] ASC,
		 a.[Name] DESC