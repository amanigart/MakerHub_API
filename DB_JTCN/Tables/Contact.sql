CREATE TABLE [dbo].[Contact]
(
	id INT NOT NULL PRIMARY KEY IDENTITY,
	idMembre INT NOT NULL,
	idContact INT NOT NULL,
	lienAvecMembre VARCHAR(50) NOT NULL,

	CONSTRAINT FK_contact_idmembre FOREIGN KEY (idMembre) REFERENCES Personne (idPersonne),
	CONSTRAINT FK_contact_idcontact FOREIGN KEY (idContact) REFERENCES Personne (idPersonne)
)
