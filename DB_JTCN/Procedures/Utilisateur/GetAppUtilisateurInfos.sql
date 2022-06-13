CREATE PROCEDURE [dbo].[GetAppUtilisateurInfos]
	@idUtilisateur INT
AS
BEGIN

	SELECT p.prenom, p.nom, p.email
	FROM Membre m
	JOIN Personne p ON (p.idPersonne = m.idPersonne)
	WHERE m.idUtilisateur = @idUtilisateur

END
