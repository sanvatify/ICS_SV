create table Employee (
empno int primary key, 
empname varchar(35) not null,
empsal int check (empsal > 25000),
emptype char(1) check (emptype in ('F','P')),
empstatus varchar(50),
)

