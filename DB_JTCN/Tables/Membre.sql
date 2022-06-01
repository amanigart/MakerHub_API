CREATE TABLE [dbo].[Membre]
(
	idMembre INT NOT NULL PRIMARY KEY IDENTITY,
	sexe VARCHAR(15) NOT NULL,
	dateNaissance DATE NOT NULL,
	groupeSanguin VARCHAR(3),
	autoriseImage BIT NOT NULL,
	basePresences INT NOT NULL,
	estActif BIT DEFAULT 0,
	idPersonne INT NOT NULL,
	idUtilisateur INT,

	CONSTRAINT FK_membre_idpersonne FOREIGN KEY (idPersonne) REFERENCES Personne (idPersonne),
	CONSTRAINT FK_membre_idUtilisateur FOREIGN KEY (idUtilisateur) REFERENCES AppUtilisateur (idUtilisateur)
)
