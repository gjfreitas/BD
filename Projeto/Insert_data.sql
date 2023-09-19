-- Insert data
use Projeto
--Pessoas
INSERT INTO POLICE.PESSOA(nome,Ncc,Bdate,morada,sexo)VALUES('Joao Pires Lima','123456789','1980-01-03','Rua Primeira','M')
INSERT INTO POLICE.PESSOA(nome,Ncc,Bdate,morada,sexo)VALUES('Paula Vasco Silva','987456321','1972-10-30','Rua Direita 43','F')
INSERT INTO POLICE.PESSOA(nome,Ncc,Bdate,morada,sexo)VALUES('Ines Couto Souto','963852741','1985-05-12','Rua de Cima 144','F')
INSERT INTO POLICE.PESSOA(nome,Ncc,Bdate,morada,sexo)VALUES('Rui Moreira Porto','741852963','1970-12-12','Rua Zig Zag 235','M')
INSERT INTO POLICE.PESSOA(nome,Ncc,Bdate,morada,sexo)VALUES('Manuel Zeferico Polaco','951742368','1990-06-05','Rua da Beira Rio 1135','M')
INSERT INTO POLICE.PESSOA(nome,Ncc,Bdate,morada,sexo)VALUES('Carolina Pascoinho Amaral','147852369','2001-06-03','Rua Figueira da Foz 6','F')
INSERT INTO POLICE.PESSOA(nome,Ncc,Bdate,morada,sexo)VALUES('Gonçalo Jorge Loureiro de Freitas','159483267','2001-11-29','Rua Figueira da Foz 9','M')
INSERT INTO POLICE.PESSOA(nome,Ncc,Bdate,morada,sexo)VALUES('Nuno Vianna Capão','102063010','2001-01-01','Rua Porto Brasil','M')
INSERT INTO POLICE.PESSOA(nome,Ncc,Bdate,morada,sexo)VALUES('Vasco Vieira Costa','977460202','2001-01-02','Rua das Boas Notas','M')
INSERT INTO POLICE.PESSOA(nome,Ncc,Bdate,morada,sexo)VALUES('Tiago Alvim Santos','955840303','2000-01-03','Rua Local 3','M')
INSERT INTO POLICE.PESSOA(nome,Ncc,Bdate,morada,sexo)VALUES('José Pedro Mendes','955488303','2000-03-19','Rua de Ovar','M')
INSERT INTO POLICE.PESSOA(nome,Ncc,Bdate,morada,sexo)VALUES('João Vasco Santos Vieitas','250400699','2001-10-27','Rua da Barquinha','M')

--Policias
INSERT INTO POLICE.POLICIA(id,cc,lugar,Ntelefone)VALUES('101','123456789','Agente','919191123')
INSERT INTO POLICE.POLICIA(id,cc,lugar,Ntelefone)VALUES('50','987456321','Comissário','919191456')
INSERT INTO POLICE.POLICIA(id,cc,lugar,Ntelefone)VALUES('33','741852963','Agente coordenador','919191789')
INSERT INTO POLICE.POLICIA(id,cc,lugar,Ntelefone)VALUES('6','159483267','Director Nacional','910456752')
INSERT INTO POLICE.POLICIA(id,cc,lugar,Ntelefone)VALUES('9','147852369','Director Nacional Adjunto','936825714')
INSERT INTO POLICE.POLICIA(id,cc,lugar,Ntelefone)VALUES('19','955488303','Aspirante a Oficial','935842167')
INSERT INTO POLICE.POLICIA(id,cc,lugar,Ntelefone)VALUES('14','250400699','Superintendente','932154789')



--Equipa
INSERT INTO POLICE.EQUIPA(PPid,Eid)VALUES('50','1')
INSERT INTO POLICE.EQUIPA(PPid,Eid)VALUES('6','2')
INSERT INTO POLICE.EQUIPA(PPid,Eid)VALUES('6','3')


-- Adicionar Equipas aos Policias
UPDATE POLICE.POLICIA
SET IDEquipa = '1'
WHERE id = '101'

UPDATE POLICE.POLICIA
SET IDEquipa = '2'
WHERE id = '6'

UPDATE POLICE.POLICIA
SET IDEquipa = '2'
WHERE id = '9'

UPDATE POLICE.POLICIA
SET IDEquipa = '2'
WHERE id = '14'


--Suspeitos
INSERT INTO POLICE.SUSPEITO(cc,NCrimesEfetuados)VALUES('963852741','2')
INSERT INTO POLICE.SUSPEITO(cc,NCrimesEfetuados)VALUES('955840303','6')
INSERT INTO POLICE.SUSPEITO(cc,NCrimesEfetuados)VALUES('977460202','9')
INSERT INTO POLICE.SUSPEITO(cc,NCrimesEfetuados)VALUES('951742368','0')

-- Crime
INSERT INTO POLICE.CRIME(codigo,localizacao,tipo)VALUES('15','Aveiro','Grave')
INSERT INTO POLICE.CRIME(codigo,localizacao,tipo)VALUES('29','Santarem','Grave')
INSERT INTO POLICE.CRIME(codigo,localizacao,tipo)VALUES('3','Aveiro','Muito Grave')
INSERT INTO POLICE.CRIME(codigo,localizacao,tipo)VALUES('12','Aveiro','Leve')

--Adicionar Crimes aos Suspeitos
INSERT INTO POLICE.CRIMESUSP(SuspCC,CrimeCod)VALUES('963852741','15')
INSERT INTO POLICE.CRIMESUSP(SuspCC,CrimeCod)VALUES('977460202','29')
INSERT INTO POLICE.CRIMESUSP(SuspCC,CrimeCod)VALUES('955840303','3')
INSERT INTO POLICE.CRIMESUSP(SuspCC,CrimeCod)VALUES('951742368','12')


--Detenção
INSERT INTO POLICE.DETENCAO(codigo,DataBD,DATADetencao,CrimeCodigo,EquipaID,PoliciaInfID,Ncriminosos)VALUES('10','2022-05-10','2022-05-09','15','1','33','3')
INSERT INTO POLICE.DETENCAO(codigo,DataBD,DATADetencao,CrimeCodigo,EquipaID,PoliciaInfID,Ncriminosos)VALUES('16','2022-06-13','2022-06-20','29','2','101','2')
INSERT INTO POLICE.DETENCAO(codigo,DataBD,DATADetencao,CrimeCodigo,EquipaID,PoliciaInfID,Ncriminosos)VALUES('13','2022-05-10','2022-05-09','3','2','33','1')
INSERT INTO POLICE.DETENCAO(codigo,DataBD,DATADetencao,CrimeCodigo,EquipaID,PoliciaInfID,Ncriminosos)VALUES('23','2022-05-02','2022-05-06','12','1','101','1')

INSERT INTO POLICE.DETENCAO(codigo,DATADetencao,CrimeCodigo,EquipaID,PoliciaInfID,Ncriminosos)VALUES('2','2022-05-06','3','2','101','1')



--Adicionar Detenção aos Suspeitos
INSERT INTO POLICE.DETSUSP(SuspCC,DetCodigo)VALUES('963852741','10')
INSERT INTO POLICE.DETSUSP(SuspCC,DetCodigo)VALUES('977460202','16')
INSERT INTO POLICE.DETSUSP(SuspCC,DetCodigo)VALUES('955840303','16')
INSERT INTO POLICE.DETSUSP(SuspCC,DetCodigo)VALUES('955840303','23')


--Veiculos
INSERT INTO POLICE.VEICULOS(EquipaID,matricula,categoria,CrimeCodigo,DetCod)VALUES('2','XQ-33-XQ','Blindado','3','16')
INSERT INTO POLICE.VEICULOS(EquipaID,matricula,categoria,CrimeCodigo,DetCod)VALUES('1','GU-41-GU','Normal','15','16')


SELECT * FROM POLICE.SUSPEITO
SELECT * FROM POLICE.CRIME
SELECT * FROM POLICE.POLICIA
SELECT * FROM POLICE.DETENCAO
SELECT * FROM POLICE.DETSUSP
SELECT * FROM POLICE.CRIMESUSP
SELECT * FROM POLICE.EQUIPA
SELECT * FROM POLICE.PESSOA
SELECT * FROM POLICE.VEICULOS

SELECT POLICE.EQUIPA.Eid FROM POLICE.EQUIPA
GROUP BY Eid

SELECT id FROM POLICE.POLICIA