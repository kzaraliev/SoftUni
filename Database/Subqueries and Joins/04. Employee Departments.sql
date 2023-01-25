SELECT TOP 5
	e.[EmployeeID],
	e.[FirstName],
	e.[Salary],
	d.[Name]
FROM [Employees] AS e
JOIN [Departments] AS d
ON e.[DepartmentID] = d.[DepartmentID]
WHERE e.[Salary] > 1500
ORDER BY d.[DepartmentID] ASC