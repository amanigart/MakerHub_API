CREATE TRIGGER [MemberDeleteTrigger]
ON [dbo].[Membre]
INSTEAD OF DELETE

AS
BEGIN

    UPDATE Membre
    SET estActif = 0
    WHERE idMembre IN (SELECT idMembre FROM deleted)
		
END