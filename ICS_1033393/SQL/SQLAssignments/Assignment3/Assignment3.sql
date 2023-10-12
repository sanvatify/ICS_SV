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

--Retrieve a list of MANAGERS. 
select ename from EMP where job = 'Manager';

--Find out the names and salaries of all employees earning more than 1000 per month
select ename, salary from EMP where salary > 1000;

--Display the names and salaries of all employees except JAMES. 
select ename, salary from EMP where ename <> 'James';

--Find out the details of employees whose names begin with ‘S’. 
select * from EMP where ename like 'S%';

--Find out the names of all employees that have ‘A’ anywhere in their name. 
select ename from EMP where ename like '%A%';

--Find out the names of all employees that have ‘L’ as their third character in their name
select ename from EMP where ename like '__L%';

--Compute daily salary of JONES. 
select ename, salary/30 as 'Daily Salary' from EMP;

--Calculate the total monthly salary of all employees.
select sum(salary) as 'Total Monthly Salary' from EMP;

--Print the average annual salary . 
select avg(salary)*12 as 'Average Annual Salary' from EMP;

--Select the name, job, salary, department number of all employees except SALESMAN from department number 30. 
select ename, job, salary, deptno from EMP where deptno = 30 and job <> 'Salesman';

--List unique departments of the EMP table. 
select distinct deptno from EMP;

--List the name and salary of employees who earn more than 1500 and are in department 10 or 30. Label the columns Employee and Monthly Salary respectively.
select ename as 'Employee', salary as 'Monthly Salary' from EMP where (salary > 1500) and (deptno = 10 or deptno = 30);

--Display the name, job, and salary of all the employees whose job is MANAGER or ANALYST and their salary is not equal to 1000, 3000, or 5000.
select ename, job, salary from EMP where (job in('Manager', 'Analyst')) and (salary not in (1000,3000,5000));

--Display the name, salary and commission for all employees whose commission amount is greater than their salary increased by 10%. 
select ename, salary, comm from EMP where comm>(salary*0.1);

--Display the name of all employees who have two Ls in their name and are in department 30 or their manager is 7782. 
select ename from EMP where (ename like '%L%L%' and deptno = 30) or mgr_id = 7782;

--Display the names of employees with experience of over 30 years and under 40 yrs. Count the total number of employees. 
select ename from EMP where DATEDIFF(year, hire_date, getdate()) between 30 and 39;
select count(ename) as 'Number Of Employees' from EMP where DATEDIFF(year, hire_date, getdate()) between 30 and 39;

--Retrieve the names of departments in ascending order and their employees in descending order. 
select d.dname, e.ename from DEPT d
left join EMP e on d.deptno = e.deptno
order by d.dname asc, e.ename desc;

--Find out experience of MILLER.
select datediff(year, hire_date, getdate()) as 'Experience' from EMP where ename = 'Miller';