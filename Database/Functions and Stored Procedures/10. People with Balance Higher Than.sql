CREATE PROC usp_GetHoldersWithBalanceHigherThan (@input DECIMAL(18,4))
AS
	SELECT
		ah.[FirstName],
		ah.[LastName]
	FROM [AccountHolders] AS ah
	JOIN(
		SELECT
			[AccountHolderId],
			SUM([Balance]) AS [TotalMoney]
		FROM [Accounts]
		GROUP BY [AccountHolderId]
	) AS acc
		ON ah.[Id] = acc.[AccountHolderId]
	WHERE [TotalMoney] > @input
	ORDER BY [FirstName], [LastName]
	