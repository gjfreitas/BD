
--5.3 - Sistema de Prescrição Eletrónica de Medicamentos

--a)
SELECT P.numUtente, P.nome
FROM PRESCRICAO.PACIENTE as P RIGHT OUTER JOIN PRESCRICAO.PRESCRICOES as Presc ON P.numUtente=Presc.numUtente
GROUP BY P.numUtente, P.nome;


--b)
SELECT M.especialidade, count(M.especialidade) as N_Prescricoes
FROM PRESCRICAO.MEDICO as M JOIN PRESCRICAO.PRESCRICOES as Presc ON M.numSNS=Presc.numMedico
GROUP BY M.especialidade;

--c)
SELECT F.nome, count(F.nome) as N_prescricoes
FROM PRESCRICAO.FARMACIA as F JOIN PRESCRICAO.PRESCRICOES as P ON F.nome=P.farmacia
GROUP BY F.nome;
		

--d)
SELECT F.nome, F.formula
FROM PRESCRICAO.FARMACO as F LEFT OUTER JOIN PRESCRICAO.PRESC_FARMACO as PF  ON F.nome = PF.nomeFarmaco
Where F.numRegFarm = 906 AND PF.numPresc IS NULL;

--e)
SELECT P.farmacia, FM.nome, COUNT(FM.nome) AS numFarmacosVendidos
	FROM (
		(PRESCRICAO.PRESCRICOES as P LEFT JOIN PRESCRICAO.PRESC_FARMACO as PF
			ON P.numPresc=PF.numPresc) LEFT JOIN PRESCRICAO.FARMACEUTICA as FM
				ON PF.numRegFarm=FM.numReg
	)
	WHERE P.farmacia IS NOT NULL
	GROUP BY P.farmacia, FM.nome
	ORDER BY P.farmacia

--f)
SELECT PA.nome, PA.numUtente, count(M.numSNS) AS NumMedicos
FROM PRESCRICAO.MEDICO as M JOIN
							(PRESCRICAO.PACIENTE as PA JOIN PRESCRICAO.PRESCRICOES as PRESC ON PA.numUtente = PRESC.numUtente)
							ON M.numSNS = PRESC.numMedico
GROUP BY PA.nome,PA.numUtente
HAVING count(M.numSNS) > 1;



