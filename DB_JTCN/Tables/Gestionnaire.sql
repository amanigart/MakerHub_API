CREATE TABLE [dbo].[Gestionnaire]
(
	idGestionnaire INT NOT NULL PRIMARY KEY IDENTITY,
	prenom VARCHAR(50) NOT NULL,
	nom VARCHAR(50) NOT NULL,
	email VARCHAR(100) NOT NULL,
	telephone VARCHAR(15) NOT NULL,
	idUtilisateur INT NOT NULL,
	
	CONSTRAINT FK_id_utilisateur FOREIGN KEY (idUtilisateur) REFERENCES AppUtilisateur (idUtilisateur)
)
