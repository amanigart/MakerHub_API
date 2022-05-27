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

EXEC RegisterAppUtilisateur 'admin', 'admin';
EXEC RegisterAppUtilisateur 'demo', 'demo'; 

INSERT INTO Gestionnaire (prenom, nom, email, telephone, idUtilisateur)
VALUES ('Kristopher', 'Baugniet', 'kb@mail.com', '0472154863', 1);
