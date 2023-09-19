--use p8g4;

--CREATE SCHEMA FLIGHTS_RES;
--go;


/* Para apagar as tables
DROP TABLE FLIGHTS_RES.SEAT;
DROP TABLE FLIGHTS_RES.LEG_INSTANCE;
DROP TABLE FLIGHTS_RES.FARE;
DROP TABLE FLIGHTS_RES.FLIGHT_LEG;
DROP TABLE FLIGHTS_RES.CAN_LAND;
DROP TABLE FLIGHTS_RES.FLIGHT;
DROP TABLE FLIGHTS_RES.AIRPLANE; 
DROP TABLE FLIGHTS_RES.APTYPE;
DROP TABLE FLIGHTS_RES.AIRPORT;
 */

CREATE TABLE FLIGHTS_RES.AIRPORT (
	aeroporto_codigo		INT NOT NULL,
	cidade					VARCHAR(30) NOT NULL,
	estado					VARCHAR(30) NOT NULL,
	nome					VARCHAR(30) NOT NULL,
	PRIMARY KEY(aeroporto_codigo)
);


CREATE TABLE FLIGHTS_RES.APTYPE(
	nome				VARCHAR(30),
	max_lugares			INT NOT NULL,
	companhia			VARCHAR(30),
	PRIMARY KEY(nome)
);


CREATE TABLE FLIGHTS_RES.AIRPLANE(
	aviao_id			INT NOT NULL,
	total_lugares		INT NOT NULL,
	tipo				VARCHAR(30),
	PRIMARY KEY(aviao_id),
	FOREIGN KEY(tipo) REFERENCES FLIGHTS_RES.APTYPE(nome)
);


CREATE TABLE FLIGHTS_RES.FLIGHT(		
	numero					INT	NOT NULL,
	airline					VARCHAR(30) NOT NULL,
	dia_semana				VARCHAR(30) NOT NULL,		--ENUM("DOM","SEG","TER","QUA","QUI","SEX","SAB") 
	PRIMARY KEY(numero)
);


CREATE TABLE FLIGHTS_RES.CAN_LAND(
	aviao_codigo			INT,
	tipo_nome				VARCHAR(30),
	PRIMARY KEY(aviao_codigo,tipo_nome),
	FOREIGN KEY(aviao_codigo) REFERENCES FLIGHTS_RES.AIRPORT(aeroporto_codigo),
	FOREIGN KEY(tipo_nome) REFERENCES FLIGHTS_RES.APTYPE(nome)
);

CREATE TABLE FLIGHTS_RES.FLIGHT_LEG(
	numero_leg						INT NOT NULL,
	numero_voo						INT	NOT NULL,
	schedule_dep_time				DATE,
	schedule_arr_time				DATE,
	number							INT				NOT NULL,
	dep_airport						INT				NOT NULL,
	arr_airport						INT				NOT NULL,					
	PRIMARY KEY(number,dep_airport,arr_airport,numero_leg),
	FOREIGN KEY(numero_voo) REFERENCES FLIGHTS_RES.FLIGHT(numero),
	FOREIGN KEY(dep_airport) REFERENCES FLIGHTS_RES.AIRPORT(aeroporto_codigo),
	FOREIGN KEY(arr_airport) REFERENCES FLIGHTS_RES.AIRPORT(aeroporto_codigo),
);

CREATE TABLE FLIGHTS_RES.FARE(
	codigo			INT NOT NULL,
	numero_voo		INT,
	amount			MONEY,
	restricoes		VARCHAR(30),
	PRIMARY KEY(codigo,numero_voo),
	FOREIGN KEY(numero_voo) REFERENCES FLIGHTS_RES.FLIGHT(numero)
);

CREATE TABLE FLIGHTS_RES.LEG_INSTANCE(
	leg_date		DATE NOT NULL,
	leg_no			INT NOT NULL,
	number_flight	INT NOT NULL,
	available_seats	INT	default 0,
	airplane_id		INT NOT NULL,
	dep_airport		INT NOT NULL,
	dep_time		TIME NOT NULL,
	arr_airport		INT NOT NULL,
	arr_time		TIME NOT NULL,
	PRIMARY KEY(leg_date, leg_no, number_flight,airplane_id,arr_airport,dep_airport),
	FOREIGN KEY(number_flight,dep_airport,arr_airport,leg_no) references FLIGHTS_RES.FLIGHT_LEG(number,dep_airport,arr_airport,numero_leg),
	FOREIGN KEY(airplane_id) references FLIGHTS_RES.AIRPLANE(aviao_id)
);

CREATE TABLE FLIGHTS_RES.SEAT(
	numero_banco			INT NOT NULL,
	leg_date				DATE NOT NULL,
	numero_leg_voo			INT,
	numero_voo				INT,
	nome_cliente			VARCHAR(30) NOT NULL,
	numero_cliente			INT NOT NULL,
	dep_airport				INT,					--
	arr_airport				INT,	
	airplane_id				INT				NOT NULL--
	PRIMARY KEY(numero_banco,leg_date,numero_leg_voo,numero_voo,arr_airport,dep_airport),
	FOREIGN KEY(leg_date,numero_leg_voo,numero_voo,airplane_id,arr_airport,dep_airport) REFERENCES FLIGHTS_RES.LEG_INSTANCE(leg_date, leg_no, number_flight,airplane_id,arr_airport,dep_airport),

);