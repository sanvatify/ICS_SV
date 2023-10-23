create procedure addEmployee
@empname varchar(35), 
@empsal int,
@emptype char(1),
@empstatus varchar(50)
as 
begin
declare @empno int;
select @empno = isnull(max(empno),0)+1 from Employee;
insert into Employee(empno, empname, empsal, emptype, empstatus)
values (@empno, @empname, @empsal, @emptype, @empstatus);
select @empno as newEmployeeNumber;
end;

declare @newEmpNo int;
exec addEmployee 
@empname = 'Sanidhya Vatsa',
@empsal = 30000.40,
@emptype = 'F',
@empstatus = 'Active';
exec addEmployee 
@empname = 'Himesh Reshamiya',
@empsal = 26000.40,
@emptype = 'F',
@empstatus = 'Active';
exec addEmployee 
@empname = 'Arijit Khan',
@empsal = 30200.50,
@emptype = 'P',
@empstatus = 'Active';

