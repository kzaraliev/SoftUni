SELECT
	[m].[MountainRange],[p].[PeakName], [p].[Elevation]
FROM [Mountains] AS [m]
LEFT JOIN [Peaks] AS [p]
	ON [p].[MountainId] = [m].[Id]
	WHERE [MountainRange] = 'Rila'
	ORDER BY [p].[Elevation] DESC
