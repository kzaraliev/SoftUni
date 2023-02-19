CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(50))
AS
	BEGIN
		SELECT
			[Id],
			[Name],
			CONCAT([Size], 'KB') AS [Size]
		FROM [Files]
		WHERE SUBSTRING([Name], LEN([Name]) - LEN(@fileExtension) + 1, LEN([Name])) = @fileExtension
		ORDER BY [Id] ASC,
				 [Name] ASC,
				 [Size] DESC
	END


EXEC usp_SearchForFiles 'txt'