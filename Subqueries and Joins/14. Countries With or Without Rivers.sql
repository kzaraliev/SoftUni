SELECT TOP 5
	c.[CountryName],
	r.[RiverName]
FROM [Continents] AS cn
JOIN [Countries] AS c
	ON cn.[ContinentCode] = c.[ContinentCode]
LEFT JOIN [CountriesRivers] AS cr
	ON cr.[CountryCode] = c.[CountryCode]
LEFT JOIN [Rivers] AS r
	ON r.[Id] = cr.[RiverId]
WHERE cn.[ContinentCode] = 'AF'
ORDER BY c.[CountryName] ASC