SELECT
	s.[Name] AS [Site],
	l.[Name] AS [Location],
	l.[Municipality],
	l.[Province],
	s.[Establishment]
FROM [Sites] AS s
JOIN [Locations] AS l
	ON s.[LocationId] = l.[Id]
WHERE SUBSTRING(s.[Name], 1, 1) NOT IN ('B', 'M', 'D') AND SUBSTRING(s.[Establishment], LEN(s.[Establishment]) - 1, 2) = 'BC'
ORDER BY s.[Name] ASC