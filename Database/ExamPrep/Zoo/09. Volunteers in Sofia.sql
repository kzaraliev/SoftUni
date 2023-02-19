SELECT
	[Name],
	[PhoneNumber],
	[Address] =
	CASE
		WHEN SUBSTRING([Address], 1, 5) = 'Sofia' THEN SUBSTRING([Address], 8, LEN([Address]) - 5)
		ELSE SUBSTRING([Address], 10, LEN([Address]) - 5)  
	END
FROM [Volunteers]
WHERE [DepartmentId] = 2 AND SUBSTRING([Address], 1, 5) = 'Sofia' OR  SUBSTRING([Address], 2, 5) = 'Sofia'
ORDER BY [Name] ASC