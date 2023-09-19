use Projeto;


CREATE PROCEDURE remov_person @NCC varchar(30) AS
BEGIN
	DELETE FROM POLICE.CRIMESUSP WHERE SuspCC=@NCC;
	DELETE FROM POLICE.DETSUSP WHERE SuspCC=@NCC;
	DELETE FROM POLICE.SUSPEITO WHERE cc=@NCC;
	-- Meter null o policia principal na equipa que o policia chefiava
	UPDATE POLICE.EQUIPA SET PPid=null WHERE PPid=(SELECT id FROM POLICE.PESSOA JOIN POLICE.POLICIA as P ON Ncc=P.cc WHERE cc=@NCC);
	-- A detenção por cascade fica com PoliciaInf pelo que não é preciso fazer nada
	DELETE FROM POLICE.POLICIA WHERE cc=@NCC;
	DELETE FROM POLICE.PESSOA WHERE Ncc=@NCC; -- Apaga a pessoa
END


--EXEC remov_person 12345 

CREATE PROCEDURE remov_susp @NCC varchar(30) AS
BEGIN
	DELETE FROM POLICE.CRIMESUSP WHERE SuspCC=@NCC;
	DELETE FROM POLICE.DETSUSP WHERE SuspCC=@NCC;
	DELETE FROM POLICE.SUSPEITO WHERE cc=@NCC;
END

--EXEC remov_susp 12345 


CREATE PROCEDURE remov_policia @ID varchar(30) AS
BEGIN
		-- Meter null o policia principal na equipa a que o policia pertencia
		UPDATE POLICE.EQUIPA SET PPid=null WHERE PPid=@ID;
		-- A detenção por cascade fica com PoliciaInf pelo que não é preciso fazer nada
		DELETE FROM POLICE.POLICIA WHERE id=@ID;
END

--EXEC remov_policia 1


-- SP para adicionar a equipa ao policia
CREATE PROCEDURE add_E_P @ID VARCHAR(30), @EID VARCHAR(30) AS
BEGIN

	IF NOT EXISTS (SELECT Eid FROM POLICE.EQUIPA WHERE Eid=@EID)
	BEGIN
		RAISERROR('Não há equipas com esse ID', 16, 1);
	END
	ELSE IF NOT EXISTS (SELECT id FROM POLICE.POLICIA WHERE id=@ID)
	BEGIN
		RAISERROR('Não há policias com esse ID', 16, 1);
	END
	ELSE
	BEGIN
		UPDATE POLICE.POLICIA
		SET IDEquipa = @EID
		WHERE id = @ID
	END
END


-- SP para associar uma equipa a um policia que não tenha equipa associdada
-- A equipa associada é sempre aquela que tem menos elementos (policias) e a ordem de inserção é por ordem ascendente do ID do Policia
CREATE PROCEDURE AddPol_To_Equipa
AS
BEGIN
	DECLARE @ID as varchar(30), @EID as varchar(30);

	WHILE EXISTS (SELECT TOP 1 id FROM POLICE.POLICIA  WHERE IDEquipa is null)
	BEGIN
		SET @ID = (SELECT TOP 1 id FROM POLICE.POLICIA  WHERE IDEquipa is null)
		SET @EID = (SELECT TOP 1 IDEquipa
					FROM POLICE.POLICIA
					WHERE IDEquipa is not null
					GROUP BY IDEquipa
					ORDER BY count(IDEquipa) ASC)

		UPDATE POLICE.POLICIA
		SET IDEquipa = @EID
		WHERE id = @ID
	END
END


-- SP para inserir todas as detenções por inserir, com o dia de hoje
CREATE PROCEDURE Inser_Det
AS
BEGIN
	DECLARE @cod AS VARCHAR(30)
	WHILE EXISTS (SELECT * FROM POLICE.DETENCAO WHERE DataBD is null)
		BEGIN
			SET @cod = (SELECT TOP 1 codigo FROM POLICE.DETENCAO WHERE DataBD is null)
			UPDATE POLICE.DETENCAO
			SET DataBD = GETDATE()
			WHERE codigo = @cod
	END
END

-- SP para retornar pessoas com base na sua faixa etária e a que classe pertencem (pessoas,suspeitos,policias)
CREATE PROCEDURE Faixa_etaria (@OPT varchar(30), @Categoria varchar(30)) AS
BEGIN

	IF (UPPER(@OPT)!='PESSOA' AND UPPER(@OPT)!='SUSPEITO' AND UPPER(@OPT)!='POLICIA')
	BEGIN
		RAISERROR('Não é uma opção válida! Opcões Válidas: PESSOA, SUSPEITO, POLICIA ', 16, 1);
	END
	ELSE IF (UPPER(@Categoria)!='JOVEM' AND UPPER(@Categoria)!='ADULTO' AND UPPER(@Categoria)!='IDOSO')
	BEGIN
		RAISERROR('Não é uma categoria válida! Categorias Válidas: JOVEM (-25), ADULTO (25-66), IDOSO(+66) ', 16, 1);
	END
	ELSE
	BEGIN
		IF (UPPER(@OPT)='PESSOA')
		BEGIN 
			IF (UPPER(@Categoria)='JOVEM')
			BEGIN
				SELECT * FROM POLICE.PESSOA WHERE DATEDIFF(hour,Bdate,GETDATE())/8766 < 25;
			END
			ELSE IF (UPPER(@Categoria)='ADULTO')
			BEGIN
				SELECT * FROM POLICE.PESSOA WHERE DATEDIFF(hour,Bdate,GETDATE())/8766 > 25 AND DATEDIFF(hour,Bdate,GETDATE())/8766 < 66;
			END
			ELSE IF (UPPER(@Categoria)='IDOSO')
			BEGIN
				SELECT * FROM POLICE.PESSOA WHERE DATEDIFF(hour,Bdate,GETDATE())/8766 > 66;
			END
		END

		ELSE IF (UPPER(@OPT)='SUSPEITO')
		BEGIN 
			IF (UPPER(@Categoria)='JOVEM')
			BEGIN
				SELECT nome, Ncc, Bdate, morada, sexo, NCrimesEfetuados FROM POLICE.PESSOA NATURAL JOIN POLICE.SUSPEITO ON Ncc=cc WHERE DATEDIFF(hour,Bdate,GETDATE())/8766 < 25;
			END
			ELSE IF (UPPER(@Categoria)='ADULTO')
			BEGIN
				SELECT nome, Ncc, Bdate, morada, sexo, NCrimesEfetuados FROM POLICE.PESSOA NATURAL JOIN POLICE.SUSPEITO ON Ncc=cc WHERE DATEDIFF(hour,Bdate,GETDATE())/8766 > 25 AND DATEDIFF(hour,Bdate,GETDATE())/8766 < 66;
			END
			ELSE IF (UPPER(@Categoria)='IDOSO')
			BEGIN
				SELECT nome, Ncc, Bdate, morada, sexo, NCrimesEfetuados FROM POLICE.PESSOA NATURAL JOIN POLICE.SUSPEITO ON Ncc=cc WHERE DATEDIFF(hour,Bdate,GETDATE())/8766 > 66;
			END
		END

		ELSE IF (UPPER(@OPT)='POLICIA')
		BEGIN 
			IF (UPPER(@Categoria)='JOVEM')
			BEGIN
				SELECT nome, Ncc, Bdate, morada, sexo, id, lugar as 'Lugar na Hieraquia', Ntelefone, IDEquipa FROM POLICE.PESSOA JOIN POLICE.POLICIA ON Ncc=cc WHERE DATEDIFF(hour,Bdate,GETDATE())/8766 < 25;
			END
			ELSE IF (UPPER(@Categoria)='ADULTO')
			BEGIN
				SELECT nome, Ncc, Bdate, morada, sexo, id, lugar as 'Lugar na Hieraquia', Ntelefone, IDEquipa FROM POLICE.PESSOA JOIN POLICE.POLICIA ON Ncc=cc WHERE DATEDIFF(hour,Bdate,GETDATE())/8766 > 25 AND DATEDIFF(hour,Bdate,GETDATE())/8766 < 66;
			END
			ELSE IF (UPPER(@Categoria)='IDOSO')
			BEGIN
				SELECT nome, Ncc, Bdate, morada, sexo, id, lugar as 'Lugar na Hieraquia', Ntelefone, IDEquipa FROM POLICE.PESSOA JOIN POLICE.POLICIA ON Ncc=cc WHERE DATEDIFF(hour,Bdate,GETDATE())/8766 > 66;
			END
		END
	END
END


