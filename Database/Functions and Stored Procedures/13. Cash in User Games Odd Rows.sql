CREATE FUNCTION ufn_CashInUsersGames (@gameName VARCHAR(50))
RETURNS TABLE
AS
RETURN SELECT
		SUM([Cash]) AS [SumCash]
	FROM
		(SELECT
			ug.[GameId],
			ug.[Cash],
			ROW_NUMBER() OVER(ORDER BY ug.[Cash] DESC) AS [RowNumber]
		FROM [UsersGames] AS ug
		JOIN [Games] AS g
			ON ug.[GameId] = g.[Id]
		WHERE g.[Name] = @gameName
		GROUP BY ug.[GameId], ug.[Cash]) AS t
	WHERE [RowNumber] % 2 = 1
	