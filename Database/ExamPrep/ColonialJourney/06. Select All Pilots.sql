SELECT
	c.[Id],
	CONCAT_WS(' ', c.[FirstName], c.[LastName]) AS [full_name]
FROM [Colonists] AS c
JOIN [TravelCards] AS t
	ON c.[Id] = t.[ColonistId]
WHERE t.[JobDuringJourney] = 'Pilot'
ORDER BY c.[Id]