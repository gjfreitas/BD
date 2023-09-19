use Projeto;

-- UDF para que dado um Policia retorne o seu nome, cc e todas as detenções que ele inseriu
CREATE FUNCTION DETENCOES (@ID varchar(30)) RETURNS TABLE
AS
	RETURN(SELECT nome,Ncc, DataBD, EquipaID, CrimeCodigo, Ncriminosos, DataDetencao
			FROM POLICE.PESSOA
			JOIN POLICE.POLICIA ON Ncc=cc
		    JOIN POLICE.DETENCAO ON id=PoliciaInfID
			WHERE POLICIA.id=@ID);
GO


-- UDF para que dado um Policia retorne nome, cc e todas as equipas das quais é policia principal
CREATE FUNCTION P_PRINCIPAL (@ID varchar(30)) RETURNS TABLE
AS
	RETURN(SELECT nome,Ncc, Eid as 'IDEquipa'
			FROM POLICE.PESSOA
			JOIN POLICE.POLICIA ON Ncc=cc
		    JOIN POLICE.EQUIPA ON id=PPid
			WHERE EQUIPA.PPid=@ID);
GO


-- UDF para que dado um Suspeito retorne nome e todas os crimes dos quais está associado
CREATE FUNCTION SuspCrimes (@CC varchar(30)) RETURNS TABLE
AS
	RETURN(SELECT nome, codigo, localizacao, tipo
			FROM POLICE.PESSOA
			JOIN POLICE.SUSPEITO ON Ncc=cc
			JOIN POLICE.CRIMESUSP ON cc=SuspCC
		    JOIN POLICE.CRIME ON CrimeCod=codigo
			WHERE CRIMESUSP.SuspCC=@CC);
GO




