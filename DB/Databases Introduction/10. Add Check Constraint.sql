ALTER TABLE [Users]
ADD CONSTRAINT Check_Password 
	CHECK (LEN([Password]) >= 5)