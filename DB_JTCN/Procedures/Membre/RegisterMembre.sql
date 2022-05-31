CREATE PROCEDURE [dbo].[RegisterMembre]
	@sexe VARCHAR(15),
	@dateNaiss DATE,
	@groupeSanguin VARCHAR(3),
	@autoriseImage BIT,
	@presences INT,
	@idPersonne INT
AS
BEGIN
	INSERT INTO Membre (sexe, dateNaissance, groupeSanguin, autoriseImage, basePresences, idPersonne)
	OUTPUT inserted.idMembre
	VALUES (@sexe, @dateNaiss, @groupeSanguin, @autoriseImage, @presences, @idPersonne)
END
