CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [age] TINYINT NOT NULL, 
    [name] VARCHAR(50) NOT NULL, 
    [surname] VARCHAR(50) NOT NULL, 
    [email] NCHAR(25) NOT NULL
)

