--use p8g4;

--CREATE SCHEMA SNS;
--go
/* 
DROP TABLE SSN.EFETUA;
DROP TABLE SSN.CONTEM;
DROP TABLE SSN.FARMACO;
DROP TABLE SSN.PRESCRICAO;
DROP TABLE SSN.COMPFARM;
DROP TABLE SSN.FARMACIA;
DROP TABLE SSN.PACIENTE; 
DROP TABLE SSN.ESPECIALIDADE;
DROP TABLE SSN.MEDICO;
 */
 
CREATE TABLE SNS.MEDICO (
    n_id_medico        INT,
    nome				VARCHAR(30) NOT NULL,
    PRIMARY KEY(n_id_medico),
);

CREATE TABLE SNS.ESPECIALIDADE (
    id_medico				INT,
    especialidade            VARCHAR(30) NOT NULL,
    PRIMARY KEY(especialidade),
	FOREIGN KEY(id_medico) REFERENCES SNS.MEDICO(n_id_medico),
);


CREATE TABLE SNS.FARMACIA (
    nif				INT NOT NULL,
    endereco        VARCHAR(30) NOT NULL,
    telefone        VARCHAR(9),
    PRIMARY KEY(nif),
	UNIQUE(Telefone),
);

CREATE TABLE SNS.PACIENTE (
    n_utente				INT NOT NULL,
    nome					VARCHAR(30) NOT NULL,
    data_nasc				DATE NOT NULL,
	endereço				VARCHAR(30) NOT NULL,
    PRIMARY KEY(n_utente),
);

CREATE TABLE SNS.COMPFARM (
    n_registo_nac			INT NOT NULL,
	nome					VARCHAR(30) NOT NULL,
    endereco				VARCHAR(30) NOT NULL,
    telefone				VARCHAR(9),
    PRIMARY KEY(n_registo_nac),
	UNIQUE(nome),
);

CREATE TABLE SNS.FARMACO (
	formula				VARCHAR(50) NOT NULL,
	nome_comerc			VARCHAR(30) NOT NULL,
    n_compfarm			INT,
    PRIMARY KEY(formula),
	FOREIGN KEY(n_compfarm) REFERENCES SNS.COMPFARM(n_registo_nac),
);

CREATE TABLE SNS.PRESCRICAO (
    num					INT NOT NULL,
	id_pac				INT,
    id_farm				INT,
    dataa				DATE NOT NULL,
	data_process		DATE,
    PRIMARY KEY(num),
	FOREIGN KEY(id_pac) REFERENCES SNS.PACIENTE(n_utente),
	FOREIGN KEY(id_farm) REFERENCES SNS.FARMACIA(nif),
);


CREATE TABLE SNS.CONTEM (
	farmaco			VARCHAR(50),
    n_prescricao    INT,
    PRIMARY KEY(n_prescricao),
    FOREIGN KEY(farmaco) REFERENCES SNS.FARMACO(formula),
	FOREIGN KEY(n_prescricao) REFERENCES SNS.PRESCRICAO(num),
);

CREATE TABLE SNS.EFETUA (
    id_med				INT,
    n_prescricao		INT,
    PRIMARY KEY(n_prescricao, id_med),
    FOREIGN KEY(id_med) REFERENCES SNS.MEDICO(n_id_medico),
	FOREIGN KEY(n_prescricao) REFERENCES SNS.PRESCRICAO(num),
);