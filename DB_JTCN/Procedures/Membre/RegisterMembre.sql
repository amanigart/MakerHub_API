CREATE PROCEDURE [dbo].[RegisterMembre]
	@photo VARCHAR(200),
	@dateInscription DATE,
	@sexe VARCHAR(15),
	@dateNaiss DATE,
	@groupeSanguin VARCHAR(3),
	@autoriseImage BIT,
	@presences INT,
	@presencesTotal INT,
	@idPersonne INT
AS
BEGIN
	INSERT INTO Membre (photo, dateInscription, sexe, dateNaissance, groupeSanguin, autoriseImage, basePresencesRequises, basePresencesTotal, idPersonne)
	OUTPUT inserted.idMembre
	VALUES (NULL, @dateInscription, @sexe, @dateNaiss, @groupeSanguin, @autoriseImage, @presences, @presencesTotal, @idPersonne)
END
