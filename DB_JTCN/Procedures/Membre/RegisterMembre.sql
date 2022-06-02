CREATE PROCEDURE [dbo].[RegisterMembre]
	@photo VARCHAR(200),
	@sexe VARCHAR(15),
	@dateNaiss DATE,
	@groupeSanguin VARCHAR(3),
	@autoriseImage BIT,
	@presences INT,
	@idPersonne INT
AS
BEGIN
	INSERT INTO Membre (photo, sexe, dateNaissance, groupeSanguin, autoriseImage, basePresences, idPersonne)
	OUTPUT inserted.idMembre
	VALUES (@photo, @sexe, @dateNaiss, @groupeSanguin, @autoriseImage, @presences, @idPersonne)
END
