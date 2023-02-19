DELETE [CreatorsBoardgames] 
FROM [CreatorsBoardgames] AS cb
JOIN [Boardgames] AS b
	ON cb.[BoardgameId] = b.[Id]
JOIN [Publishers] AS p
	ON b.[PublisherId] = p.[Id]
JOIN [Addresses] AS a
	ON p.[AddressId] = a.[Id]
WHERE SUBSTRING(a.[Town], 1, 1) = 'L'

DELETE [Boardgames]
FROM [Boardgames] AS b
JOIN [Publishers] AS p
	ON b.[PublisherId] = p.[Id]
JOIN [Addresses] AS a
	ON p.[AddressId] = a.[Id]
WHERE SUBSTRING(a.[Town], 1, 1) = 'L'

DELETE [Publishers]
FROM [Publishers] AS p
JOIN [Addresses] AS a
	ON p.[AddressId] = a.[Id]
WHERE SUBSTRING(a.[Town], 1, 1) = 'L'

DELETE FROM [Addresses]
WHERE SUBSTRING([Town], 1, 1) = 'L'