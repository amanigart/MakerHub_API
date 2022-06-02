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

-- Enregistrement des disciplines
EXEC RegisterDiscipline 'Jiu Jitsu';
EXEC RegisterDiscipline 'Taï Jitsu';

-- Enregistrement de ceinutres
EXEC RegisterCeinture 'Blanche', NULL, 0, 1;
EXEC RegisterCeinture 'Blanche', NULL, 0, 2;
EXEC RegisterCeinture 'Jaune', NULL, 25, 1;
EXEC RegisterCeinture 'Jaune', NULL, 25, 2;

-- Enregistrement d'un gestionnaire
EXEC RegisterAdresse 'Rue de la dame', '21', 5100, 'Jambes';
EXEC RegisterPersonne 'Baugniet', 'Kristopher', 'kb@mail.com', '0472154863', 1;
EXEC RegisterMembre NULL, 'homme', '1989-10-21', 'AB+', 1, 1024, 1;
EXEC RegisterGestionnaire 1;
EXEC RegisterAppUtilisateur 'admin', 'admin', 1;
EXEC RegisterCeintureMembre 1, 1;
EXEC RegisterCeintureMembre 1, 2;
EXEC RegisterCeintureMembre 1, 3;
EXEC RegisterCeintureMembre 1, 4;

-- Enregistrement d'un membre
EXEC RegisterAdresse 'Place Chanoine Descamps', '14/6', 5000, 'Namur';
EXEC RegisterPersonne 'Manigart', 'Adrien', 'adm@mail.com', '0471777126', 2;
EXEC RegisterMembre NULL, 'homme', '1985-04-23', NULL, 1, 57, 2;
EXEC RegisterAppUtilisateur 'membre', 'membre', 2; 
EXEC RegisterCeintureMembre 2, 1;
EXEC RegisterCeintureMembre 2, 2;
GO
