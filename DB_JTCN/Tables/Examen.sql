CREATE TABLE [dbo].[Examen]
(
	idExamen INT NOT NULL PRIMARY KEY IDENTITY,
	dateExamen DATE,
	statusExamen VARCHAR(15) NOT NULL,
	idMembre INT NOT NULL,
	idCeinture INT NOT NULL,

	CONSTRAINT FK_examen_idmembre FOREIGN KEY (idMembre) REFERENCES Membre (idMembre),
	CONSTRAINT FK_examen_idceinture FOREIGN KEY (idCeinture) REFERENCES Ceinture (idCeinture)
)
