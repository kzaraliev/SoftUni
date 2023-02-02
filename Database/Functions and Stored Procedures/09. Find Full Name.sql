CREATE PROC usp_GetHoldersFullName
AS
	SELECT
		CONCAT_WS(' ', [FirstName], [LastName]) AS [Full Name]
	FROM [AccountHolders]