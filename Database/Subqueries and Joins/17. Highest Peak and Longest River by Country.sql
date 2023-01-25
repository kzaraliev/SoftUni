SELECT TOP 5
	c.[CountryName],
	MAX(p.[Elevation]) AS [HighestPeakElevation],
	MAX(r.[Length]) AS [LongestRiverLength]
FROM [Countries] AS c
JOIN [MountainsCountries] AS mc
	ON c.[CountryCode] = mc.[CountryCode]
JOIN [Peaks] AS p
	ON mc.[MountainId] = p.[MountainId]
JOIN [CountriesRivers] AS cr
	ON c.[CountryCode] = cr.[CountryCode]
JOIN [Rivers] AS r
	ON cr.[RiverId] = r.[Id]
GROUP BY [CountryName]
ORDER BY [HighestPeakElevation] DESC,
		 [LongestRiverLength] DESC,
		 c.[CountryName] ASC
