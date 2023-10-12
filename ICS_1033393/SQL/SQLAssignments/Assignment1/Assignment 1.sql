use InfiniteDB;

create table Clients(
Client_ID int primary key,
Cname varchar(40) not null,
Caddress varchar(30),
Cemail varchar(30) unique,
Cphone varchar(20),
-- business type of client like manufacturer, reseller, consultant, professional, etc.
Business varchar(20) not null 
);

create table EEmployees(
Deptno int,
Empno int primary key,
Ename varchar(20),
Job varchar(20),
Salary int check (salary>0),
);

Alter table EEmployees
add constraint ForeignKeyConstraint
foreign key (Deptno) references departments(Deptno);

create table Departments(
Deptno int primary key,
Dname varchar(15) not null,
Loc varchar(20),
);


create table Projects(
Project_ID int primary key,
Descr varchar(30) not null,
Startdate date,
Planned_End_Date date,
Actual_End_Date date,
check (Actual_End_Date > Planned_End_Date),
Budget int check(Budget > 0),
Client_ID int
);

create table EmpProjectTasks(
Project_ID int,
Emp_no int, 
Startdate date,
End_date date,
Task varchar(25) not null,
Status_ varchar(15) not null
primary key(Project_ID, Emp_no),
foreign key(Project_ID) references Projects(Project_ID),
foreign key(Emp_no) references EEmployees(Empno)
);

insert into Clients (Client_ID, Cname, Caddress, Cemail, Cphone, Business) Values
(1001, 'ACME Utilities', 'Noida', 'contact@acmeutil.com', '9567880032', 'Manufacturing'),
(1002, 'Trackon Consultants', 'Mumbai', 'consult@trackon.com', '8734210090', 'Consultant'),
(1003, 'MoneySaver Distributors', 'Kolkata', 'save@moneysaver.com', '7799886655', 'Reseller'),
(1004, 'Lawful Corp', 'Chennai', 'justice@lawful.com', '9210342219', 'Professional');

insert into EEmployees (Empno, Ename, Job, Salary, Deptno) values
(7001, 'Sandeep', 'Analyst', 25000, 10),
(7002, 'Rajesh', 'Designer', 30000, 10),
(7003, 'Madhav', 'Developer', 40000, 20),
(7004, 'Manoj', 'Developer', 40000, 20),
(7005, 'Abhay', 'Designer', 35000, 10),
(7006, 'Uma', 'Tester', 30000, 30),
(7007, 'Gita', 'Tech. Writer', 30000, 40),
(7008, 'Priya', 'Tester', 35000, 30),
(7009, 'Nutan', 'Developer', 45000, 20),
(7010, 'Smita', 'Analyst', 20000, 10),
(7011, 'Anand', 'Project Mgr', 65000, 10);

insert into Departments (Deptno, Dname, Loc) values
(10, 'Design', 'Pune'),
(20, 'Development', 'Pune'),
(30, 'Testing', 'Mumbai'),
(40, 'Document', 'Mumbai');

insert into Projects (Project_ID, Descr, Startdate, Planned_End_Date, Actual_End_Date, Budget, Client_ID) values
(401, 'Inventory', '01-Apr-11', '01-Oct-11', '31-OCt-11', 150000, 1001),
(402, 'Accounting', '01-Jan-12', '01-Oct-11', null, 500000, 1002),
(403, 'Payroll', '01-Oct-11', '31-Dec-11', null, 75000, 1003),
(404, 'Contact Mgmt', '01-Nov-11', '31-Dec-11', null, 50000, 1004);

insert into EmpProjectTasks (Project_ID, Emp_no, Startdate, End_date, Task, Status_) Values
(401, 7001, '01-Apr-11', '20-Apr-11', 'System Analysis', 'Completed'),
(401, 7002, '21-Apr-11', '30-May-11', 'System Design', 'Completed'),
(401, 7003, '01-Jun-11', '15-Jul-11', 'Coding', 'Completed'),
(401, 7004, '18-Jul-11', '01-Sep-11', 'Coding', 'Completed'),
(401, 7006, '03-Sep-11', '15-Sep-11', 'Testing', 'Completed'),
(401, 7009, '18-Sep-11', '05-Oct-11', 'Code Change', 'Completed'),
(401, 7008, '06-Oct-11', '16-Oct-11', 'Testing', 'Completed'),
(401, 7007, '06-Oct-11', '11-Oct-11', 'Documentation', 'Completed'),
(401, 7011, '22-Oct-11', '31-Oct-11', 'Sign off', 'Completed'),
(402, 7010, '01-Aug-11', '20-Aug-11', 'System Analysis', 'Completed'),
(402, 7002, '22-Aug-11', '30-Sep-11', 'System Design', 'Completed'),
(402, 7004, '01-Oct-11', null, 'Coding', 'In Progress');

select * from Clients;
select * from EEmployees;
select * from Departments;
select * from Projects;
select * from EmpProjectTasks;

select *
from EEmployees
join Departments on EEmployees.Deptno = Departments.Deptno
join EmpProjectTasks on EEmployees.Empno = EmpProjectTasks.Emp_no;

select *
from Projects
join EmpProjectTasks on Projects.Project_ID = EmpProjectTasks.Project_ID
join Clients on Projects.Client_ID = Clients.Client_ID;
