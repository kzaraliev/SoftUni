INSERT INTO [Passengers] ([FullName], [Email])
SELECT
	CONCAT_WS(' ', [FirstName], [LastName]),
	CONCAT([FirstName], [LastName], '@gmail.com')
FROM [Pilots]
WHERE [Id] >= 5 AND [Id] <= 15	