--use Projeto;


-- Trigger para n�o ser possivel inserir um agente (dos 3 tipos de agente) quando este j� tem uma idade superior a 60 anos
CREATE TRIGGER Agente_Over_insert ON POLICE.POLICIA
AFTER INSERT
AS
BEGIN
	DECLARE @ID as varchar(30);
	SELECT @ID=id FROM inserted;

	DECLARE @LUGAR as varchar(90);
	SET @LUGAR=(SELECT lugar FROM POLICE.PESSOA JOIN POLICE.POLICIA ON Ncc=cc GROUP BY lugar,id HAVING id=@ID);
	
	DECLARE @BDATE as Date;
	SET @BDATE=(SELECT Bdate FROM POLICE.PESSOA JOIN POLICE.POLICIA ON Ncc=cc GROUP BY Bdate,id HAVING id=@ID);

	IF DATEDIFF(hour,@BDATE,GETDATE())/8766 > 60 AND  (UPPER(@LUGAR) = 'AGENTE' OR UPPER(@LUGAR) = 'AGENTE PRINCIPAL' OR UPPER(@LUGAR) = 'AGENTE COORDENADOR')
	BEGIN
		RAISERROR('N�o � possivel inserir um tipo de Agente com essa idade!', 16, 1);
		ROLLBACK TRAN;
	END
END

CREATE TRIGGER Agente_Over_update ON POLICE.PESSOA
AFTER UPDATE
AS
BEGIN
	DECLARE @CC as varchar(30);
	SELECT @CC=Ncc FROM inserted;

	DECLARE @LUGAR as varchar(90);
	SET @LUGAR=(SELECT lugar FROM POLICE.PESSOA JOIN POLICE.POLICIA ON Ncc=cc GROUP BY lugar,Ncc HAVING Ncc=@CC);
	
	DECLARE @BDATE as Date;
	SELECT @BDATE=Bdate from inserted;

	IF DATEDIFF(hour,@BDATE,GETDATE())/8766 > 60 AND  (UPPER(@LUGAR) = 'AGENTE' OR UPPER(@LUGAR) = 'AGENTE PRINCIPAL' OR UPPER(@LUGAR) = 'AGENTE COORDENADOR')
	BEGIN
		RAISERROR('N�o � possivel inserir um tipo de Agente com essa idade!', 16, 1);
		ROLLBACK TRAN;
	END
END

-- Trigger para n�o ser possivel atribuir um veiculo 'blindado' para um crime do tipo 'leve'
CREATE TRIGGER Veiculo_Bli_CLeve ON POLICE.VEICULOS
AFTER INSERT, UPDATE
AS
BEGIN

	IF EXISTS(SELECT categoria, tipo FROM POLICE.VEICULOS JOIN POLICE.CRIME ON CrimeCodigo=codigo
			  GROUP BY categoria, tipo
			  HAVING UPPER(tipo) = 'LEVE' AND UPPER(categoria) = 'BLINDADO')
	BEGIN
		RAISERROR('N�o � possivel atribuir um carro do tipo blindado para um crime do tipo leve!', 16, 1);
		ROLLBACK TRAN;
	END
END

-- Trigger para n�o ser possivel atribuir codigo de deten��o a um suspeito se j� houver Ncriminosos com esse c�digo
CREATE TRIGGER NcriminososCount ON POLICE.DETSUSP
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @count AS INT;
	DECLARE @NC AS INT;
	--DECLARE @CC AS VARCHAR(30);
	DECLARE @COD AS VARCHAR(30);

	--SELECT @CC=SuspCC FROM inserted;
	SELECT @COD=DetCodigo FROM inserted;

	SET @count = (SELECT COUNT(DetCodigo) as Count FROM POLICE.DETSUSP	GROUP BY DetCodigo	 HAVING DetCodigo=@COD);

	SET @NC = (SELECT Ncriminosos FROM POLICE.DETSUSP JOIN POLICE.DETENCAO ON DetCodigo=codigo GROUP BY codigo, Ncriminosos HAVING codigo=@COD)

	IF @NC < @count
	BEGIN
		RAISERROR('J� foram adicionados todos os criminosos dessa deten��o (Ncriminosos(DetCod) = Ncriminosos_inseridos(DetCod))!', 16, 1);
		ROLLBACK TRAN;
	END
END


-- Trigger para n�o deixar introduzir um lugar hieraquico que n�o exista
CREATE TRIGGER lugar_hier ON POLICE.POLICIA
AFTER Insert, UPDATE
AS
BEGIN
	DECLARE @ID as varchar(30);
	SELECT @ID=id FROM inserted;

	DECLARE @LUGAR as varchar(90);
	SELECT @LUGAR=lugar FROM inserted;

	IF (UPPER(@LUGAR)!='AGENTE' AND UPPER(@LUGAR)!='AGENTE PRINCIPAL' AND UPPER(@LUGAR)!='AGENTE COORDENADOR' AND UPPER(@LUGAR)!='CHEFE' AND UPPER(@LUGAR)!='CHEFE PRINCIPAL'
	AND UPPER(@LUGAR)!='CHEFE COORDENADOR' AND UPPER(@LUGAR)!='ASPIRANTE A OFICIAL' AND UPPER(@LUGAR)!='SUBCOMISSARIO' AND UPPER(@LUGAR)!='COMISS�RIO' AND UPPER(@LUGAR)!='SUBINTENDENTE' AND UPPER(@LUGAR)!='INTENDENTE'
	AND UPPER(@LUGAR)!='SUPERINTENDENTE' AND UPPER(@LUGAR)!='SUPERINTENDENTE-CHEFE' AND UPPER(@LUGAR)!='DIRECTOR NACIONAL ADJUNTO' AND UPPER(@LUGAR)!='DIRECTOR NACIONAL')
	BEGIN
		RAISERROR('Essa lugar n�o existe na hieraquia portuguesa! Ver https://pt.wikipedia.org/wiki/Hierarquia_policial_de_Portugal', 16, 1);
		ROLLBACK TRAN;
	END
END

-- Trigger para n�o deixar atribuir um sexo diferente de M e F
CREATE TRIGGER P_sexo ON POLICE.PESSOA
AFTER Insert, UPDATE
AS
BEGIN
	DECLARE @SEXO as varchar(30);
	SELECT @SEXO=sexo FROM inserted;


	IF (UPPER(@SEXO)!='M' AND UPPER(@SEXO)!='F')
	BEGIN
		RAISERROR('S� pode inserir como sexo as op��es: (M/m)asculino e (F/f)eminino', 16, 1);
		ROLLBACK TRAN;
	END
END

-- Trigger para n�o deixar atribuir uma data de inser��o antes da data de deten��o ou uma data que ainda n�o aconteceu
CREATE TRIGGER DataInser ON POLICE.DETENCAO
AFTER Insert, UPDATE
AS
BEGIN
	DECLARE @Data AS DATE;
	SELECT @DATA=DataBD FROM inserted;

	DECLARE @DataDet AS DATE;
	SELECT @DataDet=DataDetencao FROM inserted;


	IF (DATEDIFF(hour, @DataDet, @DATA)) < 0
	BEGIN
		RAISERROR('N�o pode inserir a deten��o antes desta acontecer', 16, 1);
		ROLLBACK TRAN;
	END

	ELSE IF (DATEDIFF(hour, @DATA, GETDATE())) < 0
	BEGIN
		RAISERROR('N�o pode inserir uma data superior a do dia dia hoje!', 16, 1);
		ROLLBACK TRAN;
	END

END


