CREATE TABLE [dbo].[Ceinture]
(
	idCeinture INT NOT NULL PRIMARY KEY IDENTITY,
	couleur VARCHAR(50) NOT NULL,
	nbPresencesRequis INT NOT NULL,
	idDiscipline INT NOT NULL,

	CONSTRAINT FK_ceinture_iddiscipline FOREIGN KEY (idDiscipline) REFERENCES Discipline (idDiscipline)
)
