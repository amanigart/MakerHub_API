CREATE PROCEDURE [dbo].[UpdateMembre]
	@idMembre INT,
	@photo VARCHAR(200),
	@sexe VARCHAR(15),
	@dateNaiss DATE,
	@groupeSanguin VARCHAR(3),
	@autoriseImage BIT,
	@presences INT,
	@idPersonne INT
AS
BEGIN

	UPDATE Membre
	SET photo = @photo,
		sexe = @sexe,
		dateNaissance = @dateNaiss,
		groupeSanguin = @groupeSanguin,
		autoriseImage = @autoriseImage,
		basePresences = @presences,
		idPersonne = @idPersonne

END