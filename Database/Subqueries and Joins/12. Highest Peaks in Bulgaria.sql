SELECT
	c.[CountryCode],
	m.[MountainRange],
	p.[PeakName],
	p.[Elevation]
FROM [Countries] AS c
JOIN [CountriesRivers] AS cr
	ON c.[CountryCode] = cr.[CountryCode]
JOIN [Rivers] AS r
	ON cr.[RiverId] = r.[Id]
JOIN [MountainsCountries] AS mc
	ON c.[CountryCode] = mc.[CountryCode]
JOIN [Mountains] AS m
	ON m.[Id] = mc.[MountainId]
JOIN [Peaks] AS p
	ON mc.[MountainId] = p.[MountainId]
WHERE c.[CountryCode] = 'BG'
AND p.[Elevation] > 2835
ORDER BY p.[Elevation] DESC
