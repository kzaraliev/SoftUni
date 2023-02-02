CREATE PROC usp_GetTownsStartingWith @startString VARCHAR(10)
AS
	SELECT
		[Name]
	FROM [Towns]
	WHERE SUBSTRING([Name], 1, LEN(@startString)) = @startString