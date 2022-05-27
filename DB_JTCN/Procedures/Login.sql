CREATE PROCEDURE [dbo].[Login]
	@login VARCHAR(100),
	@passwd VARCHAR(200) 
AS
BEGIN
	-- Throw exception custom si login n'existe pas dans table AppUtilisateur
	IF NOT EXISTS (SELECT [login] FROM AppUtilisateur WHERE [login] = @login)
		THROW 51000, 'Login incorrect.', 1

	DECLARE @secretKey VARCHAR(200)
	SET @secretKey = [dbo].GetSecretKey()
	
	DECLARE @salt VARCHAR(100)
	SET @salt = (SELECT salt FROM dbo.Salt 
				 WHERE idUtilisateur = (SELECT idUtilisateur FROM AppUtilisateur
										 WHERE [login] = @login))

	DECLARE @passwdHash VARBINARY(64)
	SET @passwdHash = HASHBYTES('SHA2_512', CONCAT(@salt, @secretKey, @passwd, @salt))

	-- Throw exception custom si login existe mais que mot de passe incorrect
	IF NOT EXISTS (SELECT [login] FROM AppUtilisateur WHERE [login] = @login AND passwd = @passwdHash)
		THROW 51001, 'Mot de passe incrorrect.', 1

	-- Sortir utilisateur si login + passwd corrects
	SELECT idUtilisateur, [login]
	FROM AppUtilisateur 
	WHERE [login] = @login AND passwd = @passwdHash
END