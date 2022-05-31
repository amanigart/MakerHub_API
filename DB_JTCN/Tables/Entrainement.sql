CREATE TABLE [dbo].[Entrainement]
(
	idEntrainement INT NOT NULL PRIMARY KEY IDENTITY,
	dateEntrainement DATETIME2(7) NOT NULL,
	idGestionnaire INT NOT NULL,
	idHoraire INT,

	CONSTRAINT FK_entrainement_idgestionnaire FOREIGN KEY (idGestionnaire) REFERENCES Gestionnaire (idGestionnaire),
	CONSTRAINT FK_entrainement_idhoraire FOREIGN KEY (idHoraire) REFERENCES Horaire (idHoraire)
)
