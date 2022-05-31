/*
Script de déploiement pour DB_MakerHub

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DB_MakerHub"
:setvar DefaultFilePrefix "DB_MakerHub"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Détectez le mode SQLCMD et désactivez l'exécution du script si le mode SQLCMD n'est pas pris en charge.
Pour réactiver le script une fois le mode SQLCMD activé, exécutez ce qui suit :
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Le mode SQLCMD doit être activé de manière à pouvoir exécuter ce script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Création de la base de données $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Impossible de modifier les paramètres de base de données. Vous devez être administrateur système pour appliquer ces paramètres.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Impossible de modifier les paramètres de base de données. Vous devez être administrateur système pour appliquer ces paramètres.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Création de Table [dbo].[Adresse]...';


GO
CREATE TABLE [dbo].[Adresse] (
    [idAdresse]  INT           IDENTITY (1, 1) NOT NULL,
    [rue]        VARCHAR (100) NOT NULL,
    [numero]     VARCHAR (15)  NOT NULL,
    [codePostal] INT           NOT NULL,
    [ville]      VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([idAdresse] ASC)
);


GO
PRINT N'Création de Table [dbo].[AppUtilisateur]...';


GO
CREATE TABLE [dbo].[AppUtilisateur] (
    [idUtilisateur] INT            IDENTITY (1, 1) NOT NULL,
    [login]         VARCHAR (100)  NOT NULL,
    [passwd]        VARBINARY (64) NOT NULL,
    PRIMARY KEY CLUSTERED ([idUtilisateur] ASC)
);


GO
PRINT N'Création de Table [dbo].[Ceinture]...';


GO
CREATE TABLE [dbo].[Ceinture] (
    [idCeinture]        INT          IDENTITY (1, 1) NOT NULL,
    [couleur]           VARCHAR (50) NOT NULL,
    [nbPresencesRequis] INT          NOT NULL,
    [idDiscipline]      INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([idCeinture] ASC)
);


GO
PRINT N'Création de Table [dbo].[Contact]...';


GO
CREATE TABLE [dbo].[Contact] (
    [id]             INT          IDENTITY (1, 1) NOT NULL,
    [idMembre]       INT          NOT NULL,
    [idContact]      INT          NOT NULL,
    [lienAvecMembre] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Création de Table [dbo].[Discipline]...';


GO
CREATE TABLE [dbo].[Discipline] (
    [idDiscipline] INT          IDENTITY (1, 1) NOT NULL,
    [nom]          VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([idDiscipline] ASC)
);


GO
PRINT N'Création de Table [dbo].[Entrainement]...';


GO
CREATE TABLE [dbo].[Entrainement] (
    [idEntrainement]   INT           IDENTITY (1, 1) NOT NULL,
    [dateEntrainement] DATETIME2 (7) NOT NULL,
    [idGestionnaire]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([idEntrainement] ASC)
);


GO
PRINT N'Création de Table [dbo].[Examen]...';


GO
CREATE TABLE [dbo].[Examen] (
    [idExamen]     INT          IDENTITY (1, 1) NOT NULL,
    [dateExamen]   DATE         NULL,
    [statusExamen] VARCHAR (15) NOT NULL,
    [idMembre]     INT          NOT NULL,
    [idCeinture]   INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([idExamen] ASC)
);


GO
PRINT N'Création de Table [dbo].[Gestionnaire]...';


GO
CREATE TABLE [dbo].[Gestionnaire] (
    [idGestionnaire] INT IDENTITY (1, 1) NOT NULL,
    [idMembre]       INT NOT NULL,
    PRIMARY KEY CLUSTERED ([idGestionnaire] ASC)
);


GO
PRINT N'Création de Table [dbo].[Membre]...';


GO
CREATE TABLE [dbo].[Membre] (
    [idMembre]      INT          IDENTITY (1, 1) NOT NULL,
    [sexe]          VARCHAR (15) NOT NULL,
    [dateNaissance] DATE         NOT NULL,
    [groupeSanguin] VARCHAR (3)  NULL,
    [autoriseImage] BIT          NOT NULL,
    [basePresences] INT          NOT NULL,
    [estActif]      BIT          NULL,
    [idPersonne]    INT          NOT NULL,
    [idUtilisateur] INT          NULL,
    PRIMARY KEY CLUSTERED ([idMembre] ASC)
);


GO
PRINT N'Création de Table [dbo].[MembreCeinture]...';


GO
CREATE TABLE [dbo].[MembreCeinture] (
    [id]         INT IDENTITY (1, 1) NOT NULL,
    [idMembre]   INT NOT NULL,
    [idCeinture] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Création de Table [dbo].[Personne]...';


GO
CREATE TABLE [dbo].[Personne] (
    [idPersonne] INT           IDENTITY (1, 1) NOT NULL,
    [nom]        VARCHAR (50)  NOT NULL,
    [prenom]     VARCHAR (50)  NOT NULL,
    [email]      VARCHAR (150) NOT NULL,
    [telephone]  VARCHAR (15)  NOT NULL,
    [idAdresse]  INT           NULL,
    PRIMARY KEY CLUSTERED ([idPersonne] ASC)
);


GO
PRINT N'Création de Table [dbo].[Presence]...';


GO
CREATE TABLE [dbo].[Presence] (
    [idPresence]     INT IDENTITY (1, 1) NOT NULL,
    [idEntrainement] INT NOT NULL,
    [idMembre]       INT NOT NULL,
    PRIMARY KEY CLUSTERED ([idPresence] ASC)
);


GO
PRINT N'Création de Table [dbo].[Referent]...';


GO
CREATE TABLE [dbo].[Referent] (
    [id]             INT          IDENTITY (1, 1) NOT NULL,
    [idMembre]       INT          NOT NULL,
    [idReferent]     INT          NOT NULL,
    [lienAvecMembre] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
PRINT N'Création de Table [dbo].[Salt]...';


GO
CREATE TABLE [dbo].[Salt] (
    [idSalt]        INT           IDENTITY (1, 1) NOT NULL,
    [idUtilisateur] INT           NOT NULL,
    [salt]          VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([idSalt] ASC)
);


GO
PRINT N'Création de Contrainte par défaut contrainte sans nom sur [dbo].[Membre]...';


GO
ALTER TABLE [dbo].[Membre]
    ADD DEFAULT 0 FOR [estActif];


GO
PRINT N'Création de Clé étrangère [dbo].[FK_ceinture_iddiscipline]...';


GO
ALTER TABLE [dbo].[Ceinture]
    ADD CONSTRAINT [FK_ceinture_iddiscipline] FOREIGN KEY ([idDiscipline]) REFERENCES [dbo].[Discipline] ([idDiscipline]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_contact_idmembre]...';


GO
ALTER TABLE [dbo].[Contact]
    ADD CONSTRAINT [FK_contact_idmembre] FOREIGN KEY ([idMembre]) REFERENCES [dbo].[Personne] ([idPersonne]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_contact_idcontact]...';


GO
ALTER TABLE [dbo].[Contact]
    ADD CONSTRAINT [FK_contact_idcontact] FOREIGN KEY ([idContact]) REFERENCES [dbo].[Personne] ([idPersonne]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_entrainement_idgestionnaire]...';


GO
ALTER TABLE [dbo].[Entrainement]
    ADD CONSTRAINT [FK_entrainement_idgestionnaire] FOREIGN KEY ([idGestionnaire]) REFERENCES [dbo].[Gestionnaire] ([idGestionnaire]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_examen_idmembre]...';


GO
ALTER TABLE [dbo].[Examen]
    ADD CONSTRAINT [FK_examen_idmembre] FOREIGN KEY ([idMembre]) REFERENCES [dbo].[Membre] ([idMembre]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_examen_idceinture]...';


GO
ALTER TABLE [dbo].[Examen]
    ADD CONSTRAINT [FK_examen_idceinture] FOREIGN KEY ([idCeinture]) REFERENCES [dbo].[Ceinture] ([idCeinture]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_gestionnaire_idmembre]...';


GO
ALTER TABLE [dbo].[Gestionnaire]
    ADD CONSTRAINT [FK_gestionnaire_idmembre] FOREIGN KEY ([idMembre]) REFERENCES [dbo].[Membre] ([idMembre]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_membre_idpersonne]...';


GO
ALTER TABLE [dbo].[Membre]
    ADD CONSTRAINT [FK_membre_idpersonne] FOREIGN KEY ([idPersonne]) REFERENCES [dbo].[Personne] ([idPersonne]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_membre_idUtilisateur]...';


GO
ALTER TABLE [dbo].[Membre]
    ADD CONSTRAINT [FK_membre_idUtilisateur] FOREIGN KEY ([idUtilisateur]) REFERENCES [dbo].[AppUtilisateur] ([idUtilisateur]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_membreceinture_idmembre]...';


GO
ALTER TABLE [dbo].[MembreCeinture]
    ADD CONSTRAINT [FK_membreceinture_idmembre] FOREIGN KEY ([idMembre]) REFERENCES [dbo].[Membre] ([idMembre]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_membreceinture_idceinture]...';


GO
ALTER TABLE [dbo].[MembreCeinture]
    ADD CONSTRAINT [FK_membreceinture_idceinture] FOREIGN KEY ([idCeinture]) REFERENCES [dbo].[Ceinture] ([idCeinture]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_personne_idadresse]...';


GO
ALTER TABLE [dbo].[Personne]
    ADD CONSTRAINT [FK_personne_idadresse] FOREIGN KEY ([idAdresse]) REFERENCES [dbo].[Adresse] ([idAdresse]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_presence_identrainment]...';


GO
ALTER TABLE [dbo].[Presence]
    ADD CONSTRAINT [FK_presence_identrainment] FOREIGN KEY ([idEntrainement]) REFERENCES [dbo].[Entrainement] ([idEntrainement]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_presence_idmembre]...';


GO
ALTER TABLE [dbo].[Presence]
    ADD CONSTRAINT [FK_presence_idmembre] FOREIGN KEY ([idMembre]) REFERENCES [dbo].[Membre] ([idMembre]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_referent_idmembre]...';


GO
ALTER TABLE [dbo].[Referent]
    ADD CONSTRAINT [FK_referent_idmembre] FOREIGN KEY ([idMembre]) REFERENCES [dbo].[Personne] ([idPersonne]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_referent_idreferent]...';


GO
ALTER TABLE [dbo].[Referent]
    ADD CONSTRAINT [FK_referent_idreferent] FOREIGN KEY ([idReferent]) REFERENCES [dbo].[Personne] ([idPersonne]);


GO
PRINT N'Création de Clé étrangère [dbo].[FK_salt_idutilisateur]...';


GO
ALTER TABLE [dbo].[Salt]
    ADD CONSTRAINT [FK_salt_idutilisateur] FOREIGN KEY ([idUtilisateur]) REFERENCES [dbo].[AppUtilisateur] ([idUtilisateur]);


GO
PRINT N'Création de Fonction [dbo].[GetSecretKey]...';


GO
CREATE FUNCTION [dbo].[GetSecretKey]
()
RETURNS VARCHAR(200)
AS
BEGIN
	RETURN '1 H4v3 N0 1d34 Wh4t 1 4m D01ng'
END
GO
PRINT N'Création de Procédure [dbo].[CheckIfIsGestionnaire]...';


GO
CREATE PROCEDURE [dbo].[CheckIfIsGestionnaire]
	@id INT
AS
BEGIN

	-- récupérer idMembre correspondant à utilisateur
	DECLARE @idMembre INT
	SET @idMembre = (SELECT idMembre FROM Membre WHERE idUtilisateur = @id)

	-- vérifier si gestionnaire avec cet idMembre existe
	IF NOT EXISTS (SELECT idGestionnaire FROM Gestionnaire WHERE idMembre = @idMembre)
		SELECT CAST(0 AS BIT)
	ELSE
		SELECT CAST(1 AS BIT)

END
GO
PRINT N'Création de Procédure [dbo].[GetGestionnaireById]...';


GO
CREATE PROCEDURE [dbo].[GetGestionnaireById]
	@id int
AS
BEGIN
	--IF NOT EXISTS (SELECT idGestionnaire FROM Gestionnaire WHERE idGestionnaire = @id)
	--	THROW 51002, 'Gestionnaire inexistant', 1;

	SELECT idGestionnaire FROM Gestionnaire WHERE idGestionnaire = @id
END
GO
PRINT N'Création de Procédure [dbo].[Login]...';


GO
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
GO
PRINT N'Création de Procédure [dbo].[RegisterAdresse]...';


GO
CREATE PROCEDURE [dbo].[RegisterAdresse]
	@rue VARCHAR(100),
	@numero VARCHAR(15),
	@cp INT,
	@ville VARCHAR(100)
AS
BEGIN
	INSERT INTO Adresse (rue, numero, codePostal, ville)
	OUTPUT inserted.idAdresse
	VALUES (@rue, @numero, @cp, @ville)
END
GO
PRINT N'Création de Procédure [dbo].[RegisterAppUtilisateur]...';


GO
CREATE PROCEDURE [dbo].[RegisterAppUtilisateur]
	@login VARCHAR(100),
	@passwd VARCHAR(100),
	@idMembre INT
AS 
BEGIN
	SET NOCOUNT ON

	DECLARE @tempIdUtilisateurTable TABLE (id INT)

	DECLARE @secretKey VARCHAR(200)
	SET @secretKey = [dbo].GetSecretKey()

	DECLARE @salt VARCHAR(100)
	SET @salt = CONCAT(NEWID(), NEWID(), NEWID())

	DECLARE @passwdHash VARBINARY(64)
	SET @passwdHash = HASHBYTES('SHA2_512', CONCAT(@salt, @secretKey, @passwd, @salt))

	INSERT INTO [dbo].AppUtilisateur ([login], passwd)
	OUTPUT inserted.idUtilisateur INTO @tempIdUtilisateurTable(id)
	VALUES (@login, @passwdHash)

	INSERT INTO [dbo].Salt (idUtilisateur, salt)
	VALUES ((SELECT id FROM @tempIdUtilisateurTable), @salt)

	UPDATE [dbo].Membre 
	SET idUtilisateur = (SELECT id FROM @tempIdUtilisateurTable)
	WHERE idMembre = @idMembre
END
GO
PRINT N'Création de Procédure [dbo].[RegisterContact]...';


GO
CREATE PROCEDURE [dbo].[RegisterContact]
	@idMembre INT,
	@idContact INT,
	@lienMembre VARCHAR(50)
AS
BEGIN
	INSERT INTO Contact (idMembre, idContact, lienAvecMembre)
	VALUES (@idMembre, @idContact, @lienMembre)
END
GO
PRINT N'Création de Procédure [dbo].[RegisterGestionnaire]...';


GO
CREATE PROCEDURE [dbo].[RegisterGestionnaire]
	@idMembre INT
AS
BEGIN
	INSERT INTO Gestionnaire (idMembre)
	OUTPUT inserted.idGestionnaire
	VALUES (@idMembre)
END
GO
PRINT N'Création de Procédure [dbo].[RegisterMembre]...';


GO
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
GO
PRINT N'Création de Procédure [dbo].[RegisterPersonne]...';


GO
CREATE PROCEDURE [dbo].[RegisterPersonne]
	@nom VARCHAR(50),
	@prenom VARCHAR(50),
	@email VARCHAR(150),
	@tel VARCHAR(15),
	@idAdresse INT
AS
BEGIN
	INSERT INTO Personne (nom, prenom, email, telephone, idAdresse)
	OUTPUT inserted.idPersonne
	VALUES (@nom, @prenom, @email, @tel, @idAdresse)
END
GO
/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

-- Enregistrement d'un gestionnaire
EXEC RegisterAdresse 'Rue de la dame', '21', 5100, 'Jambes';
EXEC RegisterPersonne 'Baugniet', 'Kristopher', 'kb@mail.com', '0472154863', 1;
EXEC RegisterMembre 'homme', '1989-10-21', 'AB+', 1, 1024, 1;
EXEC RegisterGestionnaire 1;
EXEC RegisterAppUtilisateur 'admin', 'admin', 1;

-- Enregistrement d'un membre
EXEC RegisterAdresse 'Place Chanoine Descamps', '14/6', 5000, 'Namur';
EXEC RegisterPersonne 'Manigart', 'Adrien', 'adm@mail.com', '0471777126', 2;
EXEC RegisterMembre 'homme', '1985-04-23', NULL, 1, 57, 2;
EXEC RegisterAppUtilisateur 'membre', 'membre', 2; 
GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Mise à jour terminée.';


GO
