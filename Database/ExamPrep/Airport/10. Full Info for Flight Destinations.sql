SELECT
	airp.[AirportName],
	fd.[Start] AS [DayTime],
	fd.[TicketPrice],
	p.[FullName],
	a.[Manufacturer],
	a.[Model]
FROM [FlightDestinations] AS fd
JOIN [Aircraft] AS a
	ON fd.[AircraftId] = a.[Id]
JOIN [Passengers] AS p
	ON fd.[PassengerId] = p.[Id]
JOIN [Airports] AS airp
	ON airp.[Id] = fd.[AirportId]
WHERE CAST(fd.[Start] AS TIME) BETWEEN '06:00' AND '20:00' AND fd.[TicketPrice] > 2500
ORDER BY a.[Model] ASC