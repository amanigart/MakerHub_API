CREATE TABLE [dbo].[Presence]
(
	idPresence INT NOT NULL PRIMARY KEY IDENTITY,
	idEntrainement INT NOT NULL,
	idMembre INT NOT NULL,

	CONSTRAINT FK_presence_identrainment FOREIGN KEY (idEntrainement) REFERENCES Entrainement (idEntrainement),
	CONSTRAINT FK_presence_idmembre FOREIGN KEY (idMembre) REFERENCES Membre (idMembre)
)
