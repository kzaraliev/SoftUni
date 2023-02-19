SELECT
	COUNT(*) AS [count]
FROM [Colonists] AS c
JOIN [TravelCards] AS t
	ON c.[Id] = t.[ColonistId]
WHERE t.[JobDuringJourney] = 'Engineer'