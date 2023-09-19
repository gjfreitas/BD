use Aulas;

--Aula 9

/* Apagar Procedures
DROP PROCEDURE remov_func;
DROP PROCEDURE gestores;
*/

--a) Devemos eliminar primeiro todas as dependências e só depois o employee
-- (há que ter em atenção a ordem dos deletes mas pode-se por exemplo eliminar primeiro do Works_On e só depois do Dependent)

CREATE PROCEDURE remov_func @SSN char(9) AS
BEGIN
	DELETE FROM COMPANY.[DEPENDENT] WHERE Essn=@SSN;
	DELETE FROM COMPANY.WORKS_ON WHERE Essn=@SSN;
	UPDATE COMPANY.DEPARTMENT SET Mgr_ssn= NULL WHERE Mgr_ssn=@SSN;
	UPDATE COMPANY.EMPLOYEE SET Super_ssn = null WHERE @SSN = Super_ssn;
	DELETE FROM COMPANY.EMPLOYEE WHERE Ssn=@SSN;

END

INSERT INTO COMPANY.EMPLOYEE VALUES('Gonçalo','J','Freitas','20011129' ,'2001-11-29','Fig da Foz','M',1500.00,NULL,NULL)
SELECT * FROM COMPANY.EMPLOYEE
EXEC remov_func 20011129 
SELECT * FROM COMPANY.EMPLOYEE

--b) DROP PROCEDURE gestores;
CREATE PROCEDURE gestores (@Ssn char(9) OUTPUT, @Fname varchar(15) OUTPUT, @Lname varchar(15) OUTPUT, @diff int OUTPUT)
AS
BEGIN
	-- Gestores
	SELECT Ssn, Fname, Lname, COMPANY.DEPARTMENT.Mgr_start_date
	FROM COMPANY.EMPLOYEE JOIN COMPANY.DEPARTMENT ON Ssn=Mgr_ssn;
	
	--Apenas o mais antigo (TOP 1 dá return ao primeiro da table)
	SELECT TOP 1  @Ssn=Ssn, @Fname=Fname, @Lname=Lname, @diff=DATEDIFF(year, Mgr_start_date, GETDATE())
	FROM COMPANY.EMPLOYEE JOIN COMPANY.DEPARTMENT ON Ssn=Mgr_ssn
	ORDER BY Mgr_start_date;

END

DECLARE @Ssn char(9);
DECLARE @Fname varchar(15);
DECLARE @Lname varchar(15);
DECLARE @diff int;
EXEC gestores @Ssn OUTPUT, @Fname OUTPUT, @Lname OUTPUT, @diff OUTPUT;
SELECT @Ssn as Ssn, @Fname as Fname, @Lname as Lname, @diff as 'Anos como Gestor';

--c) Slide 64 - Aula SQL Programming
CREATE TRIGGER gest_unico ON COMPANY.DEPARTMENT
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @Ssn as char(9);
	SELECT @Ssn=Mgr_ssn FROM inserted;
	IF EXISTS(SELECT Mgr_ssn FROM COMPANY.DEPARTMENT WHERE Mgr_ssn=@Ssn)
	BEGIN
		RAISERROR('Funcionário já gere um departamento!', 16, 1);
		ROLLBACK TRAN;
	END
END

-- Tentativa ( o func Ssn = 21312332 (carlos gomes) já gere um departemento (investigação)
UPDATE COMPANY.DEPARTMENT SET Mgr_ssn='21312332 ' WHERE Dname='Logistica'

--d)
CREATE TRIGGER funcSalary ON COMPANY.EMPLOYEE
INSTEAD OF INSERT, UPDATE
AS
BEGIN
	DECLARE @SALARY AS DECIMAL(10,2); --Salario do Chefe
	DECLARE @E_SALARY AS DECIMAL(10,2);--Salario do Empregado
	DECLARE @E_Dno AS INT; -- Departamento do Empregado

	SELECT @E_Dno = Dno FROM inserted
	SELECT @E_SALARY = Salary FROM inserted 

	SELECT @SALARY = Salary
	FROM COMPANY.EMPLOYEE JOIN COMPANY.DEPARTMENT ON Ssn = Mgr_ssn
	WHERE Dnumber = @E_Dno

	IF(@E_SALARY > @SALARY) -- Se o Salario do Empregado for maior, passa a ser o seu Salario-1
		SET @E_SALARY = @SALARY-1;

	DECLARE @IsUpdate AS INT;
	SELECT @IsUpdate = COUNT(*) FROM DELETED;
	IF(@IsUpdate = 0) -- Insert
	BEGIN
		INSERT INTO COMPANY.EMPLOYEE
		SELECT Fname, Minit, Lname, Ssn, Bdate, [Address], Sex, @E_SALARY,Super_ssn,Dno
		FROM inserted;
	END
	ELSE-- Update
	BEGIN
		UPDATE COMPANY.EMPLOYEE
		SET Fname = inserted.Fname, Minit = inserted.Minit, Lname = inserted.Lname, Bdate = inserted.Bdate, [Address]=inserted.[Address], Sex=inserted.Sex, Salary = @E_SALARY, Super_ssn = inserted.Super_ssn, Dno = @E_Dno
		FROM inserted
		WHERE COMPANY.EMPLOYEE.Ssn = inserted.Ssn
	END
END

go



INSERT INTO COMPANY.EMPLOYEE VALUES ('Nuno', 'V', 'Capão', 123456789, '2027-10-19', 'Brasil', 'M', NULL, NULL, 2);
UPDATE COMPANY.EMPLOYEE
SET Salary=14500
WHERE Ssn = 123456789


SELECT * FROM COMPANY.EMPLOYEE;
DELETE FROM COMPANY.EMPLOYEE WHERE Ssn=123456789;
