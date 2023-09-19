use BD;
-- 2)
CREATE TABLE mytemp (
	rid BIGINT /*IDENTITY (1, 1)*/ NOT NULL,
	at1 INT NULL,
	at2 INT NULL,
	at3 INT NULL,
	lixo varchar(100) NULL
);

--a)
CREATE CLUSTERED INDEX idxRid on mytemp(rid)

--b)
-- Record the Start Time
DECLARE @start_time DATETIME, @end_time DATETIME;
SET @start_time = GETDATE();
PRINT @start_time

-- Generate random records
DECLARE @val as int = 1;
DECLARE @nelem as int = 50000;

SET nocount ON

WHILE @val <= @nelem
BEGIN

	DBCC DROPCLEANBUFFERS; -- need to be sysadmin

	INSERT mytemp (rid, at1, at2, at3, lixo)
	SELECT cast((RAND()*@nelem*40000) as int), cast((RAND()*@nelem) as int),
			cast((RAND()*@nelem) as int), cast((RAND()*@nelem) as int),
			'lixo...lixo...lixo...lixo...lixo...lixo...lixo...lixo...lixo';
	SET @val = @val + 1;
END

PRINT 'Inserted ' + str(@nelem) + ' total records'

-- Duration of Insertion Process
SET @end_time = GETDATE();
PRINT 'Milliseconds used: ' + CONVERT(VARCHAR(20), DATEDIFF(MILLISECOND,
		@start_time, @end_time));


SELECT * FROM sys.dm_db_index_physical_stats (DB_ID(), OBJECT_ID('mytemp'), NULL, NULL, 'DETAILED') as S

-- Fragmenta��o: 98,96%
-- Ocupa��o: 67,66%
-- 69087 ms

-- c) 1.
DELETE FROM mytemp;

ALTER INDEX ALL on mytemp REBUILD WITH (FILLFACTOR=65)

-- Record the Start Time
DECLARE @start_time DATETIME, @end_time DATETIME;
SET @start_time = GETDATE();
PRINT @start_time

-- Generate random records
DECLARE @val as int = 1;
DECLARE @nelem as int = 50000;

SET nocount ON

WHILE @val <= @nelem
BEGIN

	DBCC DROPCLEANBUFFERS; -- need to be sysadmin

	INSERT mytemp (rid, at1, at2, at3, lixo)
	SELECT cast((RAND()*@nelem*40000) as int), cast((RAND()*@nelem) as int),
			cast((RAND()*@nelem) as int), cast((RAND()*@nelem) as int),
			'lixo...lixo...lixo...lixo...lixo...lixo...lixo...lixo...lixo';
	SET @val = @val + 1;
END

PRINT 'Inserted ' + str(@nelem) + ' total records'

-- Duration of Insertion Process
SET @end_time = GETDATE();
PRINT 'Milliseconds used: ' + CONVERT(VARCHAR(20), DATEDIFF(MILLISECOND,
		@start_time, @end_time));

SELECT * FROM sys.dm_db_index_physical_stats (DB_ID(), OBJECT_ID('mytemp'), NULL, NULL, 'DETAILED') as S

-- Fragmenta��o: 98,69%
-- Ocupa��o: 69.34%
-- 70633 ms

-- c) 2.
DELETE FROM mytemp;
ALTER INDEX ALL on mytemp REBUILD WITH (FILLFACTOR=80)

-- Record the Start Time
DECLARE @start_time DATETIME, @end_time DATETIME;
SET @start_time = GETDATE();
PRINT @start_time

-- Generate random records
DECLARE @val as int = 1;
DECLARE @nelem as int = 50000;

SET nocount ON

WHILE @val <= @nelem
BEGIN

	DBCC DROPCLEANBUFFERS; -- need to be sysadmin

	INSERT mytemp (rid, at1, at2, at3, lixo)
	SELECT cast((RAND()*@nelem*40000) as int), cast((RAND()*@nelem) as int),
			cast((RAND()*@nelem) as int), cast((RAND()*@nelem) as int),
			'lixo...lixo...lixo...lixo...lixo...lixo...lixo...lixo...lixo';
	SET @val = @val + 1;
END

PRINT 'Inserted ' + str(@nelem) + ' total records'

-- Duration of Insertion Process
SET @end_time = GETDATE();
PRINT 'Milliseconds used: ' + CONVERT(VARCHAR(20), DATEDIFF(MILLISECOND,
		@start_time, @end_time));


SELECT * FROM sys.dm_db_index_physical_stats (DB_ID(), OBJECT_ID('mytemp'), NULL, NULL, 'DETAILED') as S

-- Fragmenta��o: 99.07%
-- Ocupa��o: 67.50%
-- 79007 ms


-- c) 3.
DELETE FROM mytemp;
ALTER INDEX ALL on mytemp REBUILD WITH (FILLFACTOR=90)

-- Record the Start Time
DECLARE @start_time DATETIME, @end_time DATETIME;
SET @start_time = GETDATE();
PRINT @start_time

-- Generate random records
DECLARE @val as int = 1;
DECLARE @nelem as int = 50000;

SET nocount ON

WHILE @val <= @nelem
BEGIN

	DBCC DROPCLEANBUFFERS; -- need to be sysadmin

	INSERT mytemp (rid, at1, at2, at3, lixo)
	SELECT cast((RAND()*@nelem*40000) as int), cast((RAND()*@nelem) as int),
			cast((RAND()*@nelem) as int), cast((RAND()*@nelem) as int),
			'lixo...lixo...lixo...lixo...lixo...lixo...lixo...lixo...lixo';
	SET @val = @val + 1;
END

PRINT 'Inserted ' + str(@nelem) + ' total records'

-- Duration of Insertion Process
SET @end_time = GETDATE();
PRINT 'Milliseconds used: ' + CONVERT(VARCHAR(20), DATEDIFF(MILLISECOND,
		@start_time, @end_time));

SELECT * FROM sys.dm_db_index_physical_stats (DB_ID(), OBJECT_ID('mytemp'), NULL, NULL, 'DETAILED') as S

-- Fragmenta��o: 99.05%
-- Ocupa��o: 69.17%
-- 70850 ms


-- d) 1.

DROP TABLE mytemp;
CREATE TABLE mytemp (
	rid BIGINT IDENTITY (1, 1) NOT NULL,
	at1 INT NULL,
	at2 INT NULL,
	at3 INT NULL,
	lixo varchar(100) NULL
);

CREATE CLUSTERED INDEX ixRid on mytemp(rid) WITH (FILLFACTOR=65)

DECLARE @start_time DATETIME, @end_time DATETIME;
SET @start_time = GETDATE();
PRINT @start_time

-- Generate random records
DECLARE @val as int = 1;
DECLARE @nelem as int = 50000;

SET nocount ON

WHILE @val <= @nelem
BEGIN

	DBCC DROPCLEANBUFFERS; -- need to be sysadmin

	INSERT mytemp (at1, at2, at3, lixo)
	SELECT cast((RAND()*@nelem) as int),
			cast((RAND()*@nelem) as int), cast((RAND()*@nelem) as int),
			'lixo...lixo...lixo...lixo...lixo...lixo...lixo...lixo...lixo';
	SET @val = @val + 1;
END

PRINT 'Inserted ' + str(@nelem) + ' total records'


-- Duration of Insertion Process
SET @end_time = GETDATE();
PRINT 'Milliseconds used: ' + CONVERT(VARCHAR(20), DATEDIFF(MILLISECOND,
		@start_time, @end_time));



SELECT * FROM sys.dm_db_index_physical_stats (DB_ID(), OBJECT_ID('mytemp'), NULL, NULL, 'DETAILED') as S


-- Fragmenta��o: 32.23%
-- Ocupa��o: 70.32%
-- 83620 ms


-- d) 2.

ALTER INDEX ALL on mytemp REBUILD WITH (FILLFACTOR=80)

DECLARE @start_time DATETIME, @end_time DATETIME;
SET @start_time = GETDATE();
PRINT @start_time

-- Generate random records
DECLARE @val as int = 1;
DECLARE @nelem as int = 50000;

SET nocount ON

WHILE @val <= @nelem
BEGIN

	DBCC DROPCLEANBUFFERS; -- need to be sysadmin

	INSERT mytemp (at1, at2, at3, lixo)
	SELECT cast((RAND()*@nelem) as int),
			cast((RAND()*@nelem) as int), cast((RAND()*@nelem) as int),
			'lixo...lixo...lixo...lixo...lixo...lixo...lixo...lixo...lixo';
	SET @val = @val + 1;
END

PRINT 'Inserted ' + str(@nelem) + ' total records'


-- Duration of Insertion Process
SET @end_time = GETDATE();
PRINT 'Milliseconds used: ' + CONVERT(VARCHAR(20), DATEDIFF(MILLISECOND,
		@start_time, @end_time));



SELECT * FROM sys.dm_db_index_physical_stats (DB_ID(), OBJECT_ID('mytemp'), NULL, NULL, 'DETAILED') as S

-- Fragmenta��o: 13.77%
-- Ocupa��o: 84.75%
-- 60203 ms


-- d) 3.

ALTER INDEX ALL on mytemp REBUILD WITH (FILLFACTOR=90)

DECLARE @start_time DATETIME, @end_time DATETIME;
SET @start_time = GETDATE();
PRINT @start_time

-- Generate random records
DECLARE @val as int = 1;
DECLARE @nelem as int = 50000;

SET nocount ON

WHILE @val <= @nelem
BEGIN

	DBCC DROPCLEANBUFFERS; -- need to be sysadmin

	INSERT mytemp (at1, at2, at3, lixo)
	SELECT cast((RAND()*@nelem) as int),
			cast((RAND()*@nelem) as int), cast((RAND()*@nelem) as int),
			'lixo...lixo...lixo...lixo...lixo...lixo...lixo...lixo...lixo';
	SET @val = @val + 1;
END

PRINT 'Inserted ' + str(@nelem) + ' total records'


-- Duration of Insertion Process
SET @end_time = GETDATE();
PRINT 'Milliseconds used: ' + CONVERT(VARCHAR(20), DATEDIFF(MILLISECOND,
		@start_time, @end_time));


SELECT * FROM sys.dm_db_index_physical_stats (DB_ID(), OBJECT_ID('mytemp'), NULL, NULL, 'DETAILED') as S

-- Fragmenta��o: 19.86%
-- Ocupa��o: 93.08%
-- 66380 ms

-- e) 1.
-- Sem �ndices

DROP INDEX ixRid on mytemp

DECLARE @start_time DATETIME, @end_time DATETIME;
SET @start_time = GETDATE();
PRINT @start_time

-- Generate random records
DECLARE @val as int = 1;
DECLARE @nelem as int = 50000;

SET nocount ON

WHILE @val <= @nelem
BEGIN

	DBCC DROPCLEANBUFFERS; -- need to be sysadmin

	INSERT mytemp (at1, at2, at3, lixo)
	SELECT cast((RAND()*@nelem) as int),
			cast((RAND()*@nelem) as int), cast((RAND()*@nelem) as int),
			'lixo...lixo...lixo...lixo...lixo...lixo...lixo...lixo...lixo';
	SET @val = @val + 1;
END

PRINT 'Inserted ' + str(@nelem) + ' total records'


-- Duration of Insertion Process
SET @end_time = GETDATE();
PRINT 'Milliseconds used: ' + CONVERT(VARCHAR(20), DATEDIFF(MILLISECOND,
		@start_time, @end_time));


-- 94376 ms

-- e) 2.
-- Com �ndices
CREATE INDEX ix1 on mytemp(rid)
CREATE INDEX ix2 on mytemp(at1)
CREATE INDEX ix3 on mytemp(at2)
CREATE INDEX ix4 on mytemp(at3)
CREATE INDEX ix5 on mytemp(lixo)

DELETE FROM mytemp;

DECLARE @start_time DATETIME, @end_time DATETIME;
SET @start_time = GETDATE();
PRINT @start_time

-- Generate random records
DECLARE @val as int = 1;
DECLARE @nelem as int = 50000;

SET nocount ON

WHILE @val <= @nelem
BEGIN

	DBCC DROPCLEANBUFFERS; -- need to be sysadmin

	INSERT mytemp (at1, at2, at3, lixo)
	SELECT cast((RAND()*@nelem) as int),
			cast((RAND()*@nelem) as int), cast((RAND()*@nelem) as int),
			'lixo...lixo...lixo...lixo...lixo...lixo...lixo...lixo...lixo';
	SET @val = @val + 1;
END

PRINT 'Inserted ' + str(@nelem) + ' total records'


-- Duration of Insertion Process
SET @end_time = GETDATE();
PRINT 'Milliseconds used: ' + CONVERT(VARCHAR(20), DATEDIFF(MILLISECOND,
		@start_time, @end_time));


-- 152190 ms


--Adicionar �ndices em todos os atributos cria um overhead, pelo que a inser��o com os �ndices todos � substancialmente mais lenta que a inser��o sem os �ndices.
