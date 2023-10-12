create table EMP(
empno int primary key,
ename varchar(30) not null,
job varchar(20) not null,
mgr_id int,
hire_date date not null,
salary int not null,
comm int,
deptno int not null
);

create table DEPT(
deptno int not null,
dname varchar(20) not null,
loc varchar(20) not null
);

insert into EMP (empno, ename, job, mgr_id, hire_date, salary, comm, deptno) values
(7369, 'SMITH', 'CLERK', 7902, '17-DEC-80', 800, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '20-FEB-81', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '22-FEB-81', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '02-APR-81', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '28-SEP-81', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '01-MAY-81', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '09-JUN-81', 2450, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '19-APR-87', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '17-NOV-81', 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '08-SEP-81', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '23-MAY-87', 1100, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, '03-DEC-81', 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '03-DEC-81', 3000, NULL, 20),
(7934, 'MILLER', 'CLERK', 7782, '23-JAN-82', 1300, NULL, 10);

insert into DEPT (deptno, dname, loc) values
(10, 'ACCOUNTING', 'NEW YORK'),
(20, 'RESEARCH', 'DALLAS'),
(30, 'SALES', 'CHICAGO'),
(40, 'OPERATIONS', 'BOSTON');

--List all employees whose name begins with 'A'.
select *
from EMP
join DEPT on EMP.deptno = DEPT.deptno;

--list all employees whose name begins with 'A'
select * from EMP where ename like 'A%';

--Select all those employees who don't have a manager.
select * from EMP where mgr_id is null;

--List employee name, number and salary for those employees who earn in the range 1200 to 1400. 
select * from EMP where salary between 1200 and 1400;

--Give all the employees in the RESEARCH department a 10% pay rise. Verify that this has been done by listing all their details before and after the rise.
select * from EMP where deptno = 20;
update EMP set salary = salary * 1.1 where deptno = 20;
select * from EMP where deptno = 20;

--Find the number of CLERKS employed. Give it a descriptive heading.
select count(*) as 'Number Of Clerks' from EMP where job = 'CLERK';

--Find the average salary for each job type and the number of people employed in each job.
select job, avg(salary) as 'Average Salary', count(*) as 'Number Of Employees' from EMP group by job;

-- List the employees with the lowest and highest salary. 
select * from EMP where salary = (select min(salary) from EMP) or salary = (select max(salary) from EMP);

--List full details of departments that don't have any employees.
select * from DEPT where deptno not in (select deptno from EMP);

--Get the names and salaries of all the analysts earning more than 1200 who are based in department 20. Sort the answer by ascending order of name.
select ename, salary from EMP where job = 'Analyst' and salary>1200 and deptno = 20
order by ename;

--For each department, list its name and number together with the total salary paid to employees in that department. 
select d.dname, d.deptno, sum(e.salary) as 'Total Salary' from DEPT d
left join EMP e on d.deptno = e.deptno
group by d.dname, d.deptno;

--Find out salary of both MILLER and SMITH.
select ename, salary from EMP where ename in ('MILLER', 'SMITH');

--Find out the names of the employees whose name begin with ‘A’ or ‘M’. 
select ename from EMP where ename like 'A%' or ename like 'M%';

--Compute yearly salary of SMITH. 
select ename, salary * 12 as 'Yearly Salary' from EMP where ename = 'SMITH';

--List the name and salary for all employees whose salary is not in the range of 1500 and 2850. 
select ename, salary from EMP where salary < 1500 or salary > 2850;

--Find all managers who have more than 2 employees reporting to them
select m.ename as 'Manager Name', count(e.empno) as 'Number Of Direct Reports' from EMP m
left join emp e on m.empno = e.mgr_id where e.job = 'EMPLOYEE'
group by m.ename having count(e.empno) > 2;


