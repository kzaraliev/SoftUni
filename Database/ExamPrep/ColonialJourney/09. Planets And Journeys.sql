SELECT
	p.[Name] AS [PlanetName],
	COUNT(j.[Id]) AS [JourneysCount]
FROM [Planets] AS p
JOIN [Spaceports] AS s
	ON p.[Id] = s.[PlanetId]
JOIN [Journeys] AS j
	ON s.[Id] = j.[DestinationSpaceportId]
GROUP BY p.[Name]
ORDER BY [JourneysCount] DESC,
		 [PlanetName] ASC