SELECT
	f.[Id],
	f.[Name], 
	CONCAT_WS('', f.[Size], 'KB') AS [Size]
FROM [Files] AS f
LEFT JOIN [Files] AS f2
	ON f.[Id] = f2.[ParentId]
WHERE f2.[Id] IS NULL
ORDER BY f.[Id] ASC,
		 f.[Name] ASC,
		 f.[Size] DESC