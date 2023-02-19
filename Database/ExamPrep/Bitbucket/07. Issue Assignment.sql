SELECT
	i.[Id],
	CONCAT_WS(' : ', u.[Username], i.[Title]) AS [IssueAssignee]
FROM [Issues] AS i
JOIN [Users] AS u
	ON i.[AssigneeId] = u.[Id]
ORDER BY i.[Id] DESC,
		 i.[AssigneeId] ASC