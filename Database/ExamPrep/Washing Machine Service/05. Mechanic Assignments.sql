SELECT 
	CONCAT_WS(' ', m.[FirstName], m.[LastName]) AS [Mechanic],
	j.[Status],
	j.[IssueDate]
FROM [Mechanics] AS m
JOIN [Jobs] AS j
	ON m.[MechanicId] = j.[MechanicId]
ORDER BY m.[MechanicId] ASC,
		 j.[IssueDate] ASC,
		 j.[JobId] ASC