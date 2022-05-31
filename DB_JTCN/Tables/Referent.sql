CREATE TABLE [dbo].[Referent]
(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	idMembre INT NOT NULL,
	idReferent INT NOT NULL,
	lienAvecMembre VARCHAR(50) NOT NULL,

	CONSTRAINT FK_referent_idmembre FOREIGN KEY (idMembre) REFERENCES Personne (idPersonne),
	CONSTRAINT FK_referent_idreferent FOREIGN KEY (idReferent) REFERENCES Personne (idPersonne)
)
