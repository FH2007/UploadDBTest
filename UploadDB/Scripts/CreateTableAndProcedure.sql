CREATE TABLE Words ( id INTEGER NOT NULL IDENTITY(1,1) PRIMARY KEY, word VARCHAR(20), Count integer )
go
CREATE PROCEDURE InsertWords (@word varchar(20), @Count integer)
as
BEGIN
    IF EXISTS (SELECT id FROM dbo.Words WHERE Word=@word ) 		
		UPDATE dbo.Words SET Count = Count + @Count where Word=@word;		
	else
		INSERT INTO dbo.Words (Word, Count) VALUES(@word, @Count);
END;