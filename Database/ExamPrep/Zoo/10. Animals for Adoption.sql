SELECT
	[Name],
	FORMAT([BirthDate], 'yyyy') AS [BirthYear],
	at.[AnimalType]
FROM [Animals] AS a
JOIN [AnimalTypes] AS at
	ON a.[AnimalTypeId] = at.[Id]
WHERE [OwnerId] IS NULL AND DATEDIFF(YEAR, [BirthDate], '01/01/2022') < 5 AND [AnimalTypeId] != 3
ORDER BY a.[Name]