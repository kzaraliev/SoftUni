SELECT
	e.[EmployeeID],
	e.[FirstName],
	e.[ManagerID],
	em.[FirstName] AS [ManagerName]
FROM [Employees] AS e
JOIN [Employees] AS em
	ON em.[EmployeeID] = e.[ManagerID]
WHERE e.[ManagerID] = 3 OR e.[ManagerID] = 7
ORDER BY e.[EmployeeID] ASC