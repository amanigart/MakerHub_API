CREATE TABLE [dbo].[Salt]
(
	idSalt INT NOT NULL PRIMARY KEY IDENTITY,
	idUtilisateur INT NOT NULL,
	salt VARCHAR(100) NOT NULL,

	CONSTRAINT FK_salt_idutilisateur FOREIGN KEY (idUtilisateur) REFERENCES AppUtilisateur (idUtilisateur)
)
