use Projeto

-- Uma vista com todas as pessoas que nasceram em 1900
CREATE VIEW PESSOAS_SECXX AS
	SELECT *
	FROM POLICE.PESSOA
	WHERE Bdate LIKE '19__-__-__'
	WITH CHECK OPTION;

-- Uma vista com todas as pessoas que são Agentes...
CREATE VIEW AGENTES AS
	SELECT nome,Ncc,id,lugar
	FROM POLICE.PESSOA JOIN POLICE.POLICIA ON Ncc=cc
	WHERE LUGAR LIKE '%Agente%'
	WITH CHECK OPTION;

-- Uma vista com todos os crimes em aveiro, com nome e CC do suspeito, codigo e tipo de crime, equipa responsável pela detenção e data e número de criminosos
CREATE VIEW Crimes_Aveiro AS
	SELECT nome as 'Nome Suspeito', Ncc, CRIME.codigo as 'Código do Crime', tipo, localizacao, DET.codigo as 'Código de Detenção', EquipaID, DataDetencao,Ncriminosos
	FROM  POLICE.PESSOA 
	JOIN POLICE.SUSPEITO as S ON Ncc=cc 
	JOIN POLICE.CRIMESUSP as CS ON cc=CS.SuspCC
	JOIN POLICE.CRIME ON CS.CrimeCod = CRIME.codigo
	JOIN POLICE.DETSUSP as D ON S.cc = D.SuspCC 
	JOIN POLICE.DETENCAO as DET ON DET.codigo = D.DetCodigo
	WHERE localizacao LIKE '%Aveiro%'
	WITH CHECK OPTION;


