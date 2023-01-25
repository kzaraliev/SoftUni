SELECT TOP 50
	e.[EmployeeID],
	CONCAT(e.[FirstName], ' ', e.[LastName]) AS [EmployeeName],
	CONCAT(em.[FirstName], ' ', em.[LastName]) AS [ManagerName],
	d.[Name] AS [DepartmentName]
FROM [Employees] AS e
JOIN [Employees] AS em
	ON e.[ManagerID] = em.[EmployeeID]
JOIN [Departments] AS d
	ON e.[DepartmentID] = d.[DepartmentID]
ORDER BY e.[EmployeeID]