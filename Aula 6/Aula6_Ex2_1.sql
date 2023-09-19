
--5.1

--a)
/*
SELECT Pname, Fname, Minit, Lname, Ssn
FROM COMPANY.project JOIN COMPANY.works_on ON Pnumber=Pno JOIN COMPANY.employee ON Essn=Ssn;
*/
SELECT E.Fname, E.Minit, E.Lname, P.Pname, E.Ssn
FROM COMPANY.project as P JOIN COMPANY.works_on as WO ON P.Pnumber=WO.Pno JOIN COMPANY.employee as E ON WO.Essn=E.Ssn;

--b)
SELECT E.Fname, E.Minit, E.Lname
FROM COMPANY.employee as E JOIN (
	SELECT MGR.Ssn
	FROM COMPANY.EMPLOYEE as MGR
	WHERE MGR.Fname='Carlos' AND MGR.Minit='D' AND MGR.Lname='Gomes'						
	) AS temp
ON Super_ssn=temp.Ssn;

--c)
SELECT P.Pname, sum([Hours]) as n_hours
FROM COMPANY.project as P JOIN COMPANY.works_on as WO ON P.Pnumber=WO.Pno
GROUP BY P.Pname;

--d)π Fname, Minit, Lname, Ssn (π Fname, Minit, Lname, Ssn (σ Dno=3 (employee)) ⨝ Ssn=works_on.Essn (πPno, Essn (σ Hours>20 (works_on)) ⨝ Pno=Pnumber π Pnumber (σ Pname='Aveiro Digital' (project))))
SELECT E.Fname, E.Minit, E.Lname
FROM COMPANY.WORKS_ON as WO JOIN COMPANY.PROJECT as P ON WO.Pno=P.Pnumber JOIN COMPANY.EMPLOYEE as E ON E.Ssn=WO.Essn
WHERE WO.[Hours]>20 and P.Pname='Aveiro Digital'

--e)
SELECT E.Fname,E.Minit,E.Lname
FROM COMPANY.employee as E
	LEFT OUTER JOIN COMPANY.works_on as WO ON E.SSN=WO.ESSN
WHERE WO.Pno IS NULL;

--f)
SELECT D.Dname, avg(E.Salary) as AVG_Salary
FROM COMPANY.department as D
	JOIN COMPANY.employee as E ON D.Dnumber=E.Dno
WHERE E.SEX='F'
GROUP BY D.Dname;

--g)
SELECT E.Fname,E.Minit,E.Lname, count(Dep.Essn) as N_Dependentes
FROM COMPANY.employee as E
	JOIN COMPANY.[dependent] as Dep ON E.Ssn=Dep.Essn
GROUP BY E.Fname,E.Minit,E.Lname
HAVING count(Dep.Essn)>2;

--h)
SELECT E.Ssn, E.Fname, E.Minit, E.Lname
FROM COMPANY.employee as E JOIN COMPANY.department as D ON E.Ssn=D.Mgr_ssn
	LEFT OUTER JOIN COMPANY.[dependent] as DEP ON E.Ssn=DEP.Essn
WHERE DEP.Essn IS NULL

--i)
SELECT DISTINCT E.Fname, E.Minit,E.Lname,E.[Address]
FROM (((COMPANY.works_on as WO JOIN COMPANY.employee as E ON E.Ssn=WO.Essn) join COMPANY.Project as P ON WO.Pno=P.Pnumber) JOIN COMPANY.Dept_location as DL ON E.Dno=DL.Dnumber)
WHERE P.Plocation='Aveiro' and DL.Dlocation!='Aveiro'
