create procedure CalculatePaySlip @EmployeeID int as
begin
declare @salary decimal (10,2)
declare @hra decimal (10,2)
declare @da decimal (10,2)
declare @pf decimal (10,2)
declare @it decimal (10,2)
declare @deduction decimal (10,2)
declare @grossSalary decimal (10,2)
declare @netSalary decimal (10,2)
select @salary = salary from EMP where empno = @EmployeeID
set @hra = 0.1*@salary
set @da = 0.2*@salary
set @pf = 0.08*@salary
set @it = 0.05*@salary
set @deduction = @pf + @it
set @grossSalary = @salary + @hra + @da
set @netSalary = @grossSalary - @deduction
print 'Employee ID: ' + cast(@EmployeeID as varchar(20))
print 'Salary: ' + cast(@salary as varchar(20))
print 'HRA: ' + cast(@hra as varchar(20))
print 'DA: ' + cast(@da as varchar(20))
print 'PF: ' + cast(@pf as varchar(20))
print 'IT: ' + cast(@it as varchar(20))
print 'Deduction: ' + cast(@deduction as varchar(20))
print 'Gross Salary: ' + cast(@grossSalary as varchar(20))
print 'Net Salary: ' + cast(@netSalary as varchar(20))
end

exec CalculatePaySlip @EmployeeID = 7369;
