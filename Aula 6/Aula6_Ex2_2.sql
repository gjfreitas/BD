
--5.2 - Sistema de Gestão de Stocks – Módulo de Encomendas

--a)
SELECT F.nif, F.nome
FROM ENCOMENDAS.FORNECEDOR as F LEFT OUTER JOIN ENCOMENDAS.ENCOMENDA as E ON F.nif=E.f_nif
WHERE E.n_encomenda IS NULL

--b)
SELECT I.codProd, avg(I.unidades) as Avg_Unidades
FROM ENCOMENDAS.ITEM as I
GROUP BY I.codProd;


--c)
SELECT avg(temp.Avg_Prod) as Avg_Prod
FROM ( SELECT I.numEnc, count(I.codProd) as Avg_Prod
	   FROM ENCOMENDAS.ITEM as I
	   GROUP BY I.numEnc) as temp

--d)
SELECT F.nome, P.nome as Products,sum(I.unidades) as Quantidade
FROM (ENCOMENDAS.PRODUTO as P JOIN 
								(ENCOMENDAS.ITEM as I JOIN
														(ENCOMENDAS.FORNECEDOR as F JOIN ENCOMENDAS.Encomenda as E ON F.nif = E.f_nif)
														ON I.numEnc = E.n_encomenda)
								ON P.codigo = I.codProd)
GROUP BY F.nome, P.nome

