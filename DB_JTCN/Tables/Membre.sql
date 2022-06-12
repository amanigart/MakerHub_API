CREATE TABLE [dbo].[Membre]
(
	idMembre INT NOT NULL PRIMARY KEY IDENTITY,
	dateInscription DATE NOT NULL,
	photo VARCHAR(200),
	sexe VARCHAR(15) NOT NULL,
	dateNaissance DATE NOT NULL,
	groupeSanguin VARCHAR(3),
	autoriseImage BIT NOT NULL,
	basePresencesRequises INT NOT NULL DEFAULT 0,
	basePresencesTotal INT NOT NULL DEFAULT 0,
	estActif BIT DEFAULT 1,
	idPersonne INT NOT NULL,
	idUtilisateur INT,

	CONSTRAINT FK_membre_idpersonne FOREIGN KEY (idPersonne) REFERENCES Personne (idPersonne),
	CONSTRAINT FK_membre_idUtilisateur FOREIGN KEY (idUtilisateur) REFERENCES AppUtilisateur (idUtilisateur)
)
