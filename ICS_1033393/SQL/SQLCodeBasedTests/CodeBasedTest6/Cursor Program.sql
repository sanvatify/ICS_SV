declare @empno int;
declare @salary numeric(10,2);
declare employeeCursor cursor for select empno, salary from EMP where deptno = 30;
open employeeCursor;
fetch next from employeeCursor into @empno, @salary;
while @@FETCH_STATUS = 0
begin
set @salary = @salary * 1.15;
update EMP 
set salary = @salary where empno = @empno;
fetch next from employeeCursor into @empno, @salary;
end;
close employeeCursor;
deallocate employeeCursor;