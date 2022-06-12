CREATE PROCEDURE [dbo].[UpdateMembre]
	@idMembre INT,
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

	UPDATE Membre
	SET photo = @photo,
		dateInscription = @dateInscription,
		sexe = @sexe,
		dateNaissance = @dateNaiss,
		groupeSanguin = @groupeSanguin,
		autoriseImage = @autoriseImage,
		basePresencesRequises = @presences,
		basePresencesTotal = @presencesTotal,
		idPersonne = @idPersonne

END