CREATE TABLE [dbo].[Tarif]
(
	idTarif INT NOT NULL PRIMARY KEY IDENTITY,
	prix FLOAT NOT NULL,
	duree VARCHAR(25) NOT NULL
)
