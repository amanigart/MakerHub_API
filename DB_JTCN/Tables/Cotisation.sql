CREATE TABLE [dbo].[Cotisation]
(
	idCotisation INT NOT NULL PRIMARY KEY IDENTITY,
	dateDebut DATE NOT NULL,
	dateFin DATE NOT NULL,
	estPaye BIT NOT NULL,
	estArchive BIT NOT NULL DEFAULT 0,
	idTarif INT NOT NULL,
	idMembre INT NOT NULL,

	CONSTRAINT FK_cotisation_idtarif FOREIGN KEY (idTarif) REFERENCES Tarif (idTarif),
	CONSTRAINT FK_cotisation_idmembre FOREIGN KEY (idMembre) REFERENCES Membre (idMembre)
)
