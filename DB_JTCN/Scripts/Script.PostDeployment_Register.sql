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

-- Enregistrement des tarifs
EXEC RegisterTarif 5, 'cours';
EXEC RegisterTarif 55, 'trimestre';
EXEC RegisterTarif 150, 'année';

-- Enregistrement des disciplines
EXEC RegisterDiscipline 'jiu-jitsu';
EXEC RegisterDiscipline 'taï-jitsu';

-- Enregistrement de ceintures
EXEC RegisterCeinture 'blanche', NULL, 0, 1;
EXEC RegisterCeinture 'blanche', NULL, 0, 2;
EXEC RegisterCeinture 'jaune', NULL, 25, 1;
EXEC RegisterCeinture 'jaune', NULL, 25, 2;
EXEC RegisterCeinture 'orange', NULL, 50, 1;
EXEC RegisterCeinture 'orange', NULL, 50, 2;
EXEC RegisterCeinture 'verte', NULL, 100, 1;
EXEC RegisterCeinture 'verte', NULL, 100, 2;
EXEC RegisterCeinture 'bleue', NULL, 150, 1;
EXEC RegisterCeinture 'bleue', NULL, 150, 2;
EXEC RegisterCeinture 'marron', NULL, 250, 1;
EXEC RegisterCeinture 'marron', NULL, 250, 2;
EXEC RegisterCeinture 'noire', NULL, 350, 1;
EXEC RegisterCeinture 'noire', NULL, 350, 2;



-- Enregistrement d'un gestionnaire
EXEC RegisterAdresse 'Rue de la dame', '21', 5100, 'Jambes';
EXEC RegisterPersonne 'Baugniet', 'Kristopher', 'kb@mail.com', '0472154863', 1;
EXEC RegisterMembre NULL, '2010-09-1', 'homme', '1989-10-21', 'AB+', 1, 34, 1024, 1;
EXEC RegisterGestionnaire 1;
EXEC RegisterAppUtilisateur 'admin', 'admin', 1;
EXEC RegisterCeintureMembre 1, 1, '2010-09-1';
EXEC RegisterCeintureMembre 1, 2, '2010-09-1';
EXEC RegisterCeintureMembre 1, 3, '2010-12-15';
EXEC RegisterCeintureMembre 1, 4, '2010-12-15';
EXEC RegisterCotisation '2021-09-1', '2022-09-1', 1, 3, 1;
-- Enregistrement de son contact
EXEC RegisterPersonne 'Baugniet', 'Marc', 'mb@mail.com', '0478541236', 1;
EXEC RegisterContact 1, 2, 'père';

-- Enregistrement d'un membre
EXEC RegisterAdresse 'Place Chanoine Descamps', '14/6', 5000, 'Namur';
EXEC RegisterPersonne 'Manigart', 'Adrien', 'adm@mail.com', '0471777126', 2;
EXEC RegisterMembre NULL, '2020-08-15', 'homme', '1985-04-23', NULL, 1, 0, 186, 3;
EXEC RegisterAppUtilisateur 'membre', 'membre', 2; 
EXEC RegisterCeintureMembre 2, 1, '2020-08-15';
EXEC RegisterCeintureMembre 2, 2, '2020-08-15';
EXEC RegisterCotisation '2021-10-14', '2022-10-14', 1, 3, 2;
-- Enregistrement de son contact
EXEC RegisterAdresse 'Rue du Bon Dieu', '21', 5100, 'Jambes';
EXEC RegisterPersonne 'Manigart', 'Justine', 'jm@mail.com', '0478541569', 3;
EXEC RegisterContact 2, 4, 'soeur';

-- Enregistrement d'un membre MINEUR
EXEC RegisterAdresse 'Rue de la Dame', '46', 5100, 'Jambes';
EXEC RegisterPersonne 'Verschaeren', 'Anna', 'av@mail.com', '0471587126', NULL;
EXEC RegisterMembre NULL, '2021-10-12', 'femme', '2008-03-13', 'A+', 1, 7, 18, 5;
EXEC RegisterAppUtilisateur 'membre3', 'membre', 3; 
EXEC RegisterCeintureMembre 3, 1, '2021-10-12';
EXEC RegisterCeintureMembre 3, 2, '2021-10-12';
EXEC RegisterCotisation '2021-09-15', '2022-09-15', 1, 3, 3;
-- Enregistrement de son contact
EXEC RegisterAdresse 'rue Henry Blès', '5', '5000', 'Salzinnes';
EXEC RegisterPersonne 'Verschaeren', 'Paul', 'pv@mail.com', '081308541', 4;
EXEC RegisterContact 3, 6, 'père';
-- Enregistrement de son référent 
EXEC RegisterReferent 3, 6, 'père'; 




-- Enregistrement d'un membre
--EXEC RegisterAdresse 'Place Chanoine Descamps', '14/6', 5000, 'Namur';
EXEC RegisterPersonne 'Huysen', 'Serge', 'adm@mail.com', '0471777126', 2;
EXEC RegisterMembre NULL, '2001-09-15', 'homme', '1985-04-23', NULL, 1, 21, 157, 7;
EXEC RegisterAppUtilisateur 'membre4', 'membre', 4; 
EXEC RegisterCeintureMembre 4, 5, '2001-09-15';
EXEC RegisterCeintureMembre 4, 6, '2001-09-15';
EXEC RegisterCotisation '2021-10-14', '2022-10-14', 1, 3, 4;
-- Enregistrement de son contact
EXEC RegisterAdresse 'Rue de l''Adresse', '22', 1000, 'Bruxelles';
EXEC RegisterPersonne 'De Contact', 'Personne', 'pc@mail.com', '081388841', 6;
EXEC RegisterContact 4, 8, 'inconnu';

-- Enregistrement d'un membre
--EXEC RegisterAdresse 'Place Chanoine Descamps', '14/6', 5000, 'Namur';
EXEC RegisterPersonne 'Kulaksis', 'Konstantin', 'adm@mail.com', '0471777126', 2;
EXEC RegisterMembre NULL, '2014-09-5', 'homme', '1996-04-23', NULL, 1, 21, 157, 9;
EXEC RegisterAppUtilisateur 'membre5', 'membre', 5; 
EXEC RegisterCeintureMembre 5, 1, '2014-09-5';
EXEC RegisterCeintureMembre 5, 2, '2014-09-5';
EXEC RegisterCeintureMembre 5, 3, '2015-09-5';
EXEC RegisterCeintureMembre 5, 4, '2015-09-5';
EXEC RegisterCeintureMembre 5, 5, '2016-09-5';
EXEC RegisterCeintureMembre 5, 6, '2016-09-5';
EXEC RegisterCotisation '2021-09-14', '2022-09-14', 0, 3, 5;
-- Enregistrement de son contact
EXEC RegisterContact 5, 8, 'inconnu';

-- Enregistrement d'un membre
--EXEC RegisterAdresse 'Place Chanoine Descamps', '14/6', 5000, 'Namur';
EXEC RegisterPersonne 'Maniet', 'Guillaume', 'adm@mail.com', '0471777126', 2;
EXEC RegisterMembre NULL, '2012-09-6', 'homme', '2000-04-23', NULL, 1, 23, 157, 10;
EXEC RegisterAppUtilisateur 'membre6', 'membre', 6; 
EXEC RegisterCeintureMembre 6, 3,'2012-09-6';
EXEC RegisterCeintureMembre 6, 4, '2012-09-6';
EXEC RegisterCotisation '2022-03-04', '2022-03-04', 1, 3, 6;
-- Enregistrement de son contact
EXEC RegisterContact 6, 8, 'inconnu';

-- Enregistrement d'un membre
--EXEC RegisterAdresse 'Place Chanoine Descamps', '14/6', 5000, 'Namur';
EXEC RegisterPersonne 'Kulaksis', 'Konstantin', 'adm@mail.com', '0471777126', 2;
EXEC RegisterMembre NULL, '2014-02-05', 'homme', '1992-04-23', NULL, 1, 21, 157, 11;
EXEC RegisterAppUtilisateur 'membre7', 'membre', 7; 
EXEC RegisterCeintureMembre 7, 1, '2014-09-5';
EXEC RegisterCeintureMembre 7, 2, '2014-09-5';
EXEC RegisterCeintureMembre 7, 3, '2015-09-5';
EXEC RegisterCeintureMembre 7, 4, '2015-09-5';
EXEC RegisterCeintureMembre 7, 5, '2016-09-5';
EXEC RegisterCeintureMembre 7, 6, '2016-09-5';
EXEC RegisterCeintureMembre 7, 7, '2017-09-5';
EXEC RegisterCotisation '2021-09-14', '2022-09-14', 0, 3, 5;
-- Enregistrement de son contact
EXEC RegisterContact 7, 8, 'inconnu';

-- Enregistrement d'un membre
--EXEC RegisterAdresse 'Place Chanoine Descamps', '14/6', 5000, 'Namur';
EXEC RegisterPersonne 'Grazziani', 'Giovanni', 'gg@mail.com', '0471798126', 2;
EXEC RegisterMembre NULL, '2012-01-18', 'homme', '1999-04-23', NULL, 1, 23, 657, 12;
EXEC RegisterAppUtilisateur 'membre8', 'membre', 8; 
EXEC RegisterCeintureMembre 8, 3,'2012-09-6';
EXEC RegisterCeintureMembre 8, 4, '2012-09-6';
EXEC RegisterCotisation '2022-03-04', '2022-03-04', 1, 3, 6;
-- Enregistrement de son contact
EXEC RegisterContact 8, 8, 'inconnu';
