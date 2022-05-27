CREATE TABLE [dbo].[Salt]
(
	idUtilisateur INT NOT NULL,
	salt VARCHAR(100) NOT NULL,

	CONSTRAINT pk_salt PRIMARY KEY (idUtilisateur, salt),
	CONSTRAINT fk_salt_idUser FOREIGN KEY (idUtilisateur) REFERENCES AppUtilisateur (idUtilisateur)
)
