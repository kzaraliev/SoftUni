CREATE PROC usp_AnimalsWithOwnersOrNot
		(@AnimalName VARCHAR(30))
AS
BEGIN
IF (SELECT OwnerId FROM Animals
			WHERE Name = @AnimalName) IS NULL
	BEGIN 
		SELECT Name, 'For adoption' AS OwnerName
			FROM Animals
			WHERE Name = @AnimalName
	END
	ELSE
	BEGIN
		SELECT a.Name, o.Name as OwnerName
			FROM Animals AS a
			JOIN Owners AS o ON o.Id = a.OwnerId
			WHERE a.Name = @AnimalName
	END
END