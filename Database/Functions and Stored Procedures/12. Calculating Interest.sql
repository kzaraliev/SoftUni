CREATE PROC usp_CalculateFutureValueForAccount(@accId INT, @interestRate FLOAT)
AS
	SELECT
		acc.[Id] AS [Account Id],
		acch.[FirstName] AS [First Name],
		acch.[LastName] AS [Last Name],
		acc.[Balance] AS [Current Balance],
		dbo.ufn_CalculateFutureValue(acc.[Balance], @interestRate, 5)
	FROM [AccountHolders] AS acch
	JOIN [Accounts] AS acc
		ON acch.[Id] = acc.[AccountHolderId]
	WHERE acc.[Id] = @accId