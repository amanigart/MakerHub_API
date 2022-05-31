CREATE TABLE [dbo].[Gestionnaire]
(
	idGestionnaire INT NOT NULL PRIMARY KEY IDENTITY,
	idMembre INT NOT NULL,
	
	CONSTRAINT FK_gestionnaire_idmembre FOREIGN KEY (idMembre) REFERENCES Membre (idMembre)
)
