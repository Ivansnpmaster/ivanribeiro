CREATE TABLE [dbo].[Diary]
(
	[codigo] INT NOT NULL PRIMARY KEY, 
    [data] DATE NOT NULL, 
    [conteudo] VARCHAR(MAX) NOT NULL
)