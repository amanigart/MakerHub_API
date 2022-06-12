CREATE TABLE [dbo].[CeintureMembre]
(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	dateObtention DATE NOT NULL,
	idMembre INT NOT NULL,
	idCeinture INT NOT NULL,

	CONSTRAINT FK_ceinturemembre_idmembre FOREIGN KEY (idMembre) REFERENCES Membre (idMembre),
	CONSTRAINT FK_ceinturemembre_idceinture FOREIGN KEY (idCeinture) REFERENCES Ceinture (idCeinture)
)
