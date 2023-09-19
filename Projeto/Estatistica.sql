use Projeto;

-- SP para ver o nº de crimes detidos por equipa
CREATE PROCEDURE det_por_equipa AS
BEGIN
	SELECT Eid, count(codigo) as 'Detenções' FROM POLICE.DETENCAO JOIN POLICE.EQUIPA ON EquipaID=Eid GROUP BY Eid ORDER BY Eid
END

--EXEC det_por_equipa

-- SP para ver o nº de crimes por localização
CREATE PROCEDURE crimes_local AS
BEGIN
	SELECT localizacao, count(localizacao) as 'Nº Crimes' FROM POLICE.CRIME GROUP BY localizacao ORDER BY count(localizacao) DESC
END

-- SP para ver idade média dos policias
CREATE PROCEDURE idade_media_pol AS
BEGIN
	SELECT avg(DATEDIFF(hour,Bdate,GETDATE())/8766) as IDMed  FROM POLICE.PESSOA JOIN POLICE.POLICIA ON Ncc=cc
END

-- SP para ver idade média dos suspeitos
CREATE PROCEDURE idade_media_susp AS
BEGIN
	SELECT avg(DATEDIFF(hour,Bdate,GETDATE())/8766) as IDMed  FROM POLICE.PESSOA JOIN POLICE.SUSPEITO ON Ncc=cc
END


-- SP para ver idade média das pessoa
CREATE PROCEDURE idade_media_people AS
BEGIN
	SELECT avg(DATEDIFF(hour,Bdate,GETDATE())/8766) as IDMed  FROM POLICE.PESSOA
END

-- SP para ver o número de policias por equipa
CREATE PROCEDURE police_equipa AS
BEGIN	
	SELECT IDEquipa, count(id) AS 'Número de Policias'  FROM POLICE.POLICIA GROUP BY IDEquipa
END


-- SP para dado o codigo da detenção mostrar o nome e o nºcc de todos os criminosos
CREATE PROCEDURE det_codigo_nome @COD as VARCHAR(90) AS
BEGIN
	IF NOT EXISTS (SELECT codigo FROM POLICE.DETENCAO WHERE codigo=@COD)
	BEGIN
		RAISERROR('Não há detenções com esse ID', 16, 1);
		--ROLLBACK TRAN;
	END
	ELSE
	BEGIN
		SELECT nome, Ncc FROM POLICE.PESSOA JOIN POLICE.SUSPEITO ON Ncc=cc JOIN POLICE.DETSUSP as D ON cc=D.SuspCC WHERE D.DetCodigo=@COD
	END
END

-- SP para dado um policia se é chefe
CREATE PROCEDURE equipa_chefe @ID as VARCHAR(90) AS
BEGIN
	
	DECLARE @EID as VARCHAR(30)
	
	IF NOT EXISTS (SELECT id FROM POLICE.POLICIA WHERE id=@ID)
	BEGIN
		RAISERROR('Não há policias com esse ID', 16, 1);
		--ROLLBACK TRAN;
	END
	ELSE
	BEGIN
		IF NOT EXISTS (SELECT Eid as 'IDEquipa' FROM POLICE.EQUIPA WHERE PPid=@ID)
		BEGIN
			SET @EID = 'NOT EXISTS'
			SELECT @EID as 'ID Equipa'
		END
		ELSE
		BEGIN
			SELECT Eid as 'ID Equipa' FROM POLICE.EQUIPA WHERE PPid=@ID
		END
	END

END


-- SP para ver o nº de policias com esse lugar
CREATE PROCEDURE policias_lugar @LUGAR as VARCHAR(90) AS
BEGIN
	IF NOT EXISTS (SELECT lugar FROM POLICE.POLICIA WHERE UPPER(lugar)=UPPER(@LUGAR))
	BEGIN
		RAISERROR('Esse lugar não pertence a base de dados! Ver https://pt.wikipedia.org/wiki/Hierarquia_policial_de_Portugal', 16, 1);
		--ROLLBACK TRAN;
	END
	ELSE
	BEGIN
		SELECT count(lugar) as 'Nº lugar' FROM POLICE.POLICIA WHERE UPPER(lugar)=UPPER(@lugar)
	END
END


-- SP para ver o nº de veiculos usados numa determinada detenção
CREATE PROCEDURE crimes_veiculos @CODIGO as VARCHAR(30)  AS
BEGIN
	IF NOT EXISTS (SELECT count(DetCod) as count FROM POLICE.VEICULOS GROUP BY DetCod HAVING DetCod=@CODIGO)
	BEGIN
		RAISERROR('Não há detenções com esse codigo', 16, 1);
		--ROLLBACK TRAN;
	END
	ELSE
	BEGIN
		SELECT count(DetCod) as count FROM POLICE.VEICULOS GROUP BY DetCod HAVING DetCod=@CODIGO
	END
END

-- SP para ver os suspeitos ainda não detidos e o crime ao qual estão associados
CREATE PROCEDURE Suspeitos_n_Detidos  AS
BEGIN
	SELECT nome,Ncc, C.codigo as 'Codigo'
	FROM POLICE.PESSOA
	JOIN POLICE.SUSPEITO ON Ncc=cc
	JOIN POLICE.CRIMESUSP AS CS ON cc=CS.SuspCC
	JOIN POLICE.CRIME AS C ON CS.CrimeCod=C.codigo
	LEFT OUTER JOIN POLICE.DETSUSP AS D ON cc=D.SuspCC
	WHERE D.SuspCC is null
END

-- SP para ver as detenções por inserir na BD
CREATE PROCEDURE Det_N_inseridos  AS
BEGIN
	DECLARE @DET as VARCHAR(30)
	DECLARE @DDET as DATE
	IF NOT EXISTS (SELECT * FROM POLICE.DETENCAO WHERE DataBD is null)
	BEGIN
		SET @DET = 'NOT EXISTS'
		SET @DDET = GETDATE()
		SELECT @DET as 'Codigo', @DDET as 'Data de Detenção'
	END
	ELSE
	BEGIN
		SELECT codigo as 'Codigo', DataDetencao as 'Data de Detenção' FROM POLICE.DETENCAO WHERE DataBD is null
	END

END

-- SP para ver os polciias que mais dados inserem na BD
CREATE PROCEDURE Poli_inserem  AS
BEGIN
	SELECT nome,Ncc,id, count(id) as COUNT FROM POLICE.PESSOA JOIN POLICE.POLICIA ON Ncc=cc JOIN POLICE.DETENCAO ON id=PoliciaInfID GROUP BY id,nome,Ncc ORDER BY COUNT DESC
END

