SELECT
	p.[FirstName],
	p.[LastName],
	a.[Manufacturer],
	a.[Model],
	a.[FlightHours]
FROM [Pilots] AS p
JOIN [PilotsAircraft] AS pa
	ON p.[Id] = pa.[PilotId]
JOIN [Aircraft] AS a
	ON pa.[AircraftId] = a.[Id]
WHERE a.[FlightHours] IS NOT NULL AND a.[FlightHours] < 304
ORDER BY a.[FlightHours] DESC,	
		 p.[FirstName] ASC