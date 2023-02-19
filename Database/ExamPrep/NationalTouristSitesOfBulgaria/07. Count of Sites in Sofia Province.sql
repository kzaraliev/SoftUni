SELECT
	l.[Province],
	l.[Municipality],
	l.[Name] AS [Location],
	COUNT(s.[LocationId]) AS [CountOfSites]
FROM [Locations] AS l
JOIN [Sites] AS s
	ON l.[Id] = s.[LocationId]
WHERE l.[Province] = 'Sofia'
GROUP BY l.[Province], l.[Municipality], l.[Name]
ORDER BY COUNT(s.[LocationId]) DESC,
		 l.[Name] ASC