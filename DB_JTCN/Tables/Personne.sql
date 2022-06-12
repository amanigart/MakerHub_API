CREATE TABLE [dbo].[Personne]
(
	idPersonne INT NOT NULL PRIMARY KEY IDENTITY,
	nom VARCHAR(50) NOT NULL,
	prenom VARCHAR(50) NOT NULL,
	email VARCHAR(150),
	telephone VARCHAR(15) NOT NULL,
	idAdresse INT,

	CONSTRAINT FK_personne_idadresse FOREIGN KEY (idAdresse) REFERENCES Adresse (idAdresse)
)
