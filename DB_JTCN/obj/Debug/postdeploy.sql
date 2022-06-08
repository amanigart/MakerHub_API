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

-- Enregistrement des horaires
EXEC RegisterHoraire 'mercredi', '18h00', '19h00';
EXEC RegisterHoraire 'vendredi', '20h00', '22h00';
EXEC RegisterHoraire 'samedi', '09h30', '11h00';

-- Enregistrement des disciplines
EXEC RegisterDiscipline 'jiu-jitsu';
EXEC RegisterDiscipline 'taï-jitsu';

-- Enregistrement de ceinutres
EXEC RegisterCeinture 'blanche', NULL, 0, 1;
EXEC RegisterCeinture 'blanche', NULL, 0, 2;
EXEC RegisterCeinture 'jaune', NULL, 25, 1;
EXEC RegisterCeinture 'jaune', NULL, 25, 2;
EXEC RegisterCeinture 'orange', NULL, 50, 1;
EXEC RegisterCeinture 'orange', NULL, 50, 2;



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
-- Enregistrement de son contact
EXEC RegisterPersonne 'Baugniet', 'Marc', 'mb@mail.com', '0478541236', 1;
EXEC RegisterContact 1, 2, 'père';

-- Enregistrement d'un membre
EXEC RegisterAdresse 'Place Chanoine Descamps', '14/6', 5000, 'Namur';
EXEC RegisterPersonne 'Manigart', 'Adrien', 'adm@mail.com', '0471777126', 2;
EXEC RegisterMembre NULL, 'homme', '1985-04-23', NULL, 1, 57, 3;
EXEC RegisterAppUtilisateur 'membre', 'membre', 2; 
EXEC RegisterCeintureMembre 2, 1;
EXEC RegisterCeintureMembre 2, 2;
-- Enregistrement de son contact
EXEC RegisterAdresse 'Rue du Bon Dieu', '21', 5100, 'Jambes';
EXEC RegisterPersonne 'Manigart', 'Justine', 'jm@mail.com', '0478541569', 3;
EXEC RegisterContact 2, 4, 'soeur';

-- Enregistrement d'un membre MINEUR
EXEC RegisterAdresse 'Rue de la Dame', '46', 5100, 'Jambes';
EXEC RegisterPersonne 'Verschaeren', 'Anna', 'av@mail.com', '0471587126', 4;
EXEC RegisterMembre NULL, 'femme', '2008-03-13', 'A+', 1, 18, 5;
EXEC RegisterAppUtilisateur 'membre', 'membre', 3; 
EXEC RegisterCeintureMembre 3, 1;
EXEC RegisterCeintureMembre 3, 2;
-- Enregistrement de son contact
EXEC RegisterPersonne 'Verschaeren', 'Paul', 'pv@mail.com', '081308541', 4;
EXEC RegisterContact 3, 6, 'père';
-- Enregistrement de son référent 
EXEC RegisterReferent 3, 6, 'père'; 






-- Enregistrement d'un membre
EXEC RegisterAdresse 'Place Chanoine Descamps', '14/6', 5000, 'Namur';
EXEC RegisterPersonne 'Huysen', 'Serge', 'adm@mail.com', '0471777126', 2;
EXEC RegisterMembre NULL, 'homme', '1985-04-23', NULL, 1, 57, 7;
EXEC RegisterAppUtilisateur 'membre', 'membre', 2; 
EXEC RegisterCeintureMembre 4, 5;
EXEC RegisterCeintureMembre 4, 6;
-- Enregistrement de son contact
EXEC RegisterAdresse 'Rue de l''Adresse', '22', 1000, 'Bruxelles';
EXEC RegisterPersonne 'De Contact', 'Personne', 'pc@mail.com', '081388841', 6;
EXEC RegisterContact 4, 8, 'inconnu';

-- Enregistrement d'un membre
EXEC RegisterAdresse 'Place Chanoine Descamps', '14/6', 5000, 'Namur';
EXEC RegisterPersonne 'Kulaksis', 'Konstantin', 'adm@mail.com', '0471777126', 2;
EXEC RegisterMembre NULL, 'homme', '1985-04-23', NULL, 1, 57, 9;
EXEC RegisterAppUtilisateur 'membre', 'membre', 2; 
EXEC RegisterCeintureMembre 5, 1;
EXEC RegisterCeintureMembre 5, 2;
EXEC RegisterCeintureMembre 5, 3;
EXEC RegisterCeintureMembre 5, 4;
EXEC RegisterCeintureMembre 5, 5;
EXEC RegisterCeintureMembre 5, 6;
-- Enregistrement de son contact
EXEC RegisterContact 5, 8, 'inconnu';

-- Enregistrement d'un membre
EXEC RegisterAdresse 'Place Chanoine Descamps', '14/6', 5000, 'Namur';
EXEC RegisterPersonne 'Maniet', 'Guillaume', 'adm@mail.com', '0471777126', 2;
EXEC RegisterMembre NULL, 'homme', '1985-04-23', NULL, 1, 57, 10;
EXEC RegisterAppUtilisateur 'membre', 'membre', 2; 
EXEC RegisterCeintureMembre 6, 3;
EXEC RegisterCeintureMembre 6, 4;
-- Enregistrement de son contact
EXEC RegisterContact 6, 8, 'inconnu';
GO
