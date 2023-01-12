USE [master]

BACKUP DATABASE [SoftUni]
	TO DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\Backup\SoftUniDB.bak' 

GO

DROP DATABASE [SoftUni]

GO

RESTORE DATABASE [SoftUni] 
	FROM DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\Backup\SoftUniDB.bak'