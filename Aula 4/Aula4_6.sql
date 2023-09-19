--use p8g4;

--CREATE SCHEMA ATL;
--go


/* 
DROP TABLE ATL.ENTLEV;
DROP TABLE ATL.FREQUENTA;
DROP TABLE ATL.TEMDISP;
DROP TABLE ATL.TEMDISP;
DROP TABLE ATL.ALUNO;
DROP TABLE ATL.ATIVIDADE;
DROP TABLE ATL.TURMA;
DROP TABLE ATL.PESSAUT; 
DROP TABLE ATL.PROFESSOR;
DROP TABLE ATL.ADULTO; 
 */


CREATE TABLE ATL.ADULTO (
	ncc			INT	NOT NULL,
	data_nasc	DATE NOT NULL,
	morada		VARCHAR(30),
	telefone	INT NOT NULL,
	nome		VARCHAR(30) NOT NULL,
	email		VARCHAR(30),
	PRIMARY KEY(ncc),
	UNIQUE (email,telefone),		--outra chave_candidata
);

CREATE TABLE ATL.PROFESSOR (
	n_id			INT NOT NULL,
	n_cc			INT NOT NULL,
	PRIMARY KEY(n_cc),
	FOREIGN KEY(n_cc) REFERENCES ATL.ADULTO(ncc),
	UNIQUE(n_id),
);

CREATE TABLE ATL.PESSAUT (  --Pessoas com autorização
	n_cc			INT	NOT NULL,
	rel_aluno		VARCHAR(30) NOT NULL,
	PRIMARY KEY(n_cc),
	FOREIGN KEY(n_cc) REFERENCES ATL.ADULTO(ncc),
);


CREATE TABLE ATL.TURMA (
	prof_id				INT,
	turma_id			INT NOT NULL,
	ano_letivo			DATE NOT NULL,
	n_max_alunos		INT,
	escolaridade		INT,
	designacao			VARCHAR(30) NOT NULL,
	PRIMARY KEY(turma_id),
	FOREIGN KEY(prof_id) REFERENCES ATL.PROFESSOR(n_id),
);

CREATE TABLE ATL.ATIVIDADE (
	identificador			INT,
	custo					MONEY NOT NULL,
	designacao			VARCHAR(30) NOT NULL,
	PRIMARY KEY(identificador),
);



CREATE TABLE ATL.ALUNO (
	aluno_cc				INT NOT NULL,
	id_turma				INT,
	cc_respons				INT,
	morada					VARCHAR(30) NOT NULL,
	data_nasc				DATE NOT NULL,
	nome				VARCHAR(30) NOT NULL,
	PRIMARY KEY(aluno_cc),
	FOREIGN KEY(id_turma) REFERENCES ATL.TURMA(turma_id),
	FOREIGN KEY(cc_respons) REFERENCES ATL.PESSAUT(n_cc),
);


CREATE TABLE ATL.TEMDISP (		--tem disponivel
	id_turma				INT,
	id_atividade			INT,
	PRIMARY KEY(id_turma,id_atividade),
	FOREIGN KEY(id_turma) REFERENCES ATL.TURMA(turma_id),
	FOREIGN KEY(id_atividade) REFERENCES ATL.ATIVIDADE(identificador),
);

CREATE TABLE ATL.FREQUENTA (
	id_atividade		INT,
	aluno_id			INT,
	PRIMARY KEY(id_atividade, aluno_id),	
	FOREIGN KEY(id_atividade) REFERENCES ATL.ATIVIDADE(identificador),
	FOREIGN KEY(aluno_id) REFERENCES ATL.ALUNO(aluno_cc),
);


CREATE TABLE ATL.ENTLEV	 (		-- entrega/levanta
	resp_id				INT,
	aluno_id			INT,
	PRIMARY KEY(aluno_id,resp_id),
	FOREIGN KEY(resp_id) REFERENCES ATL.PESSAUT(n_cc),
	FOREIGN KEY(aluno_id) REFERENCES ATL.ALUNO(aluno_cc),
);