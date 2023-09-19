use Aulas;

-- Aula 9

--e) Crie uma UDF que, para determinado funcionário (ssn), devolva o nome e localização
--   dos projetos em que trabalha

CREATE FUNCTION Name_Local (@Ssn char(9)) RETURNS TABLE
AS
	RETURN(SELECT Pname, Plocation
			FROM COMPANY.EMPLOYEE
			JOIN COMPANY.WORKS_ON ON Ssn=Essn
		    JOIN COMPANY.PROJECT ON Pno=Pnumber
			WHERE EMPLOYEE.SSN=@Ssn);
GO

/* SELECT Pname e Plocation para cada SSN
SELECT Ssn, Pname, Plocation
FROM COMPANY.EMPLOYEE JOIN COMPANY.WORKS_ON ON Ssn=Essn JOIN COMPANY.PROJECT ON Pno=Pnumber
*/
SELECT * FROM Name_Local('183623612') -- Aveiro Digital, Aveiro e Dicoogle, Aveiro

--f) Crie uma UDF que, para determinado departamento (dno), retorne os funcionários
--   com um vencimento superior à média dos vencimentos desse departamento;


CREATE FUNCTION Func_Dept (@dno int) RETURNS TABLE
AS
	RETURN(SELECT Ssn, Fname, Lname, Salary
		   FROM COMPANY.EMPLOYEE as E
		   WHERE DNO=@dno AND Salary>(
		       SELECT AVG(Salary)
			   FROM COMPANY.EMPLOYEE
			   WHERE Dno=@dno)
		   );
GO
/* SELECT Ssn e Salary para aqueles com salarios maior que a média do departamento 2
SELECT Ssn, Salary
FROM COMPANY.EMPLOYEE as E
WHERE DNO='2' AND Salary>(
			SELECT AVG(Salary)
			FROM COMPANY.EMPLOYEE
			WHERE Dno='2')
*/

SELECT * FROM COMPANY.EMPLOYEE WHERE Dno='3'
SELECT * FROM Func_Dept(3)


--g) Slide 26 - SQL Programming

CREATE FUNCTION employeeDeptHighAverage(@dno int) RETURNS @table TABLE (pname varchar(15), number int, plocation varchar(15), dnum int, budget decimal(10,2), totalbudget decimal(10,2))
AS
BEGIN
	--Cursor
	DECLARE @pname as varchar(15), @number as int, @plocation as varchar(15), @dnum as int, @budget as decimal(10,2), @totalbudget as decimal(10,2);

	DECLARE C CURSOR FAST_FORWARD
	FOR SELECT Pname, Pnumber, Plocation, Dnumber, Sum(Salary*[Hours]/40)
		FROM COMPANY.DEPARTMENT 
			 JOIN COMPANY.PROJECT ON Dnumber=Dnum
			 JOIN COMPANY.WORKS_ON ON Pnumber=Pno
			 JOIN COMPANY.EMPLOYEE ON Essn=Ssn
		WHERE Dnumber=@dno
		GROUP BY Pname, Pnumber, Plocation, Dnumber;

	OPEN C;

	FETCH C INTO @pname, @number, @plocation, @dnum, @budget;
	SELECT @totalbudget = 0;

	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @totalbudget += @budget;
		INSERT INTO @table VALUES (@pname, @number, @plocation, @dnum, @budget, @totalbudget)
		FETCH C INTO @pname, @number, @plocation, @dnum, @budget;
	END

	CLOSE C;

	DEALLOCATE C;

	return;
END

/*
SELECT Pname, Pnumber, Plocation, Dnum, Salary
FROM COMPANY.DEPARTMENT JOIN COMPANY.PROJECT ON Dnumber=Dnum JOIN COMPANY.WORKS_ON ON Pnumber=Pno JOIN COMPANY.EMPLOYEE ON Essn=Ssn
*/
SELECT * FROM COMPANY.DEPARTMENT JOIN COMPANY.PROJECT ON Dnumber=Dnum
WHERE Dnumber=3

SELECT * FROM employeeDeptHighAverage(3)


--h)
CREATE TRIGGER DeleteDepartment ON COMPANY.DEPARTMENT
INSTEAD OF DELETE 
AS
BEGIN

	IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_SCHEMA = 'COMPANY' AND TABLE_NAME = 'DEPARTMENT_DELETED'))
		BEGIN
			CREATE TABLE COMPANY.DEPARTMENT_DELETED (Dname varchar(15) NOT NULL, Dnumber int PRIMARY KEY, Mgr_ssn char(9), Mgr_start_date date);
		END

	DELETE FROM COMPANY.PROJECT WHERE Dnum in (SELECT Dnumber FROM deleted);
	UPDATE COMPANY.EMPLOYEE SET Dno=NULL WHERE DNO IN (SELECT Dnumber FROM deleted);
	INSERT INTO COMPANY.DEPARTMENT_DELETED SELECT * FROM DELETED;
	DELETE FROM COMPANY.DEPARTMENT WHERE Dnumber IN (SELECT Dnumber FROM deleted);

END

go

SELECT * FROM COMPANY.DEPARTMENT;
DELETE FROM COMPANY.DEPARTMENT WHERE Dnumber=5;
SELECT * FROM COMPANY.DEPARTMENT_DELETED;
INSERT INTO COMPANY.DEPARTMENT VALUES ('Desporto',5,NULL,NULL)



CREATE TRIGGER DeleteDepartment2 ON COMPANY.DEPARTMENT
AFTER DELETE 
AS
BEGIN

	IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES
		WHERE TABLE_SCHEMA = 'COMPANY' AND TABLE_NAME = 'DEPARTMENT_DELETEDVV'))
			CREATE TABLE COMPANY.DEPARTMENT_DELETEDVV (Dname varchar(15) NOT NULL, Dnumber int PRIMARY KEY, Mgr_ssn char(9), Mgr_start_date date);
			INSERT INTO DEPARTMENT_DELETEDVV SELECT * FROM DELETED;

END

SELECT * FROM COMPANY.DEPARTMENT;
DELETE FROM COMPANY.DEPARTMENT WHERE Dnumber=5;
SELECT * FROM COMPANY.DEPARTMENT_DELETEDVV;
INSERT INTO COMPANY.DEPARTMENT VALUES ('Desporto',5,NULL,NULL)

/*
A vantagem de usar um trigger INSTEAD OF é que podemos eliminar todas as dependências do departamento antes de o eliminar efetivamente
*/

--i)
/*
	Uma Stored Procedure é uma batch armazenada com um nome, que tem como vantagem não ser necessário recompilar
	o código sempre que o procedimento é invocado. Os procedimentos são guardados em cache na primeira vez
	que são executados, sendo que posteriormente não é necessário aceder à memória.
	Os Stored procedures podem ter argumentos de entrada e podem retornar valores escalares. (slide 31)

	As UDF's possuem os mesmos benefícios das store procedures. São igualmente compilados e otimizados. (slide 46)
	As UDF's obrigatoriamente retornam sempre um valor, que pode ser escalar ou uma tabela, e podem aceitar argumentos de entrada. (slide 48)

	Os stored procedures podem alterar o estado da base de dados com insert's, update's e delete's e suportam o uso de blocos try... catch
	o mesmo não acontece com as UDF's. (slide 50) 

	No caso de ser necessário alterar tabelas da base de dados, o mais adequado seria usar um procedure.
	Se fosse necessário retornar uma tabela, o mais adequado seria usar UDF's.

*/