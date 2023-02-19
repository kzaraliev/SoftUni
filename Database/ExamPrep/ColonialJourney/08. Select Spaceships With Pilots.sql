SELECT
	s.[Name],
	s.[Manufacturer]
FROM [Spaceships] AS s
JOIN [Journeys] AS j
	ON s.[Id] = j.[SpaceshipId]
JOIN [TravelCards] AS t
	ON j.[Id] = t.[JourneyId]
JOIN [Colonists] AS c
	ON t.[ColonistId] = c.[Id]
WHERE DATEDIFF(YEAR, c.[BirthDate], '2019-01-01') < 30 AND t.[JobDuringJourney] = 'Pilot'
GROUP BY t.[JourneyId], s.[Name], s.[Manufacturer]
ORDER BY s.[Name] ASC